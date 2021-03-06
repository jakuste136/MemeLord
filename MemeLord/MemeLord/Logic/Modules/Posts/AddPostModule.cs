﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MemeLord.Configuration;
using MemeLord.Logic.Extensions;
using MemeLord.Logic.Repository;
using MemeLord.Models;
using CloudinaryConfiguration = MemeLord.Configuration.CloudinaryConfiguration;

namespace MemeLord.Logic.Modules.Posts
{
    public interface IAddPostModule
    {
        HttpResponseMessage AddPost(HttpRequestMessage request);
    }

    public class AddPostModule : IAddPostModule
    {
        private readonly CloudinaryConfiguration _cloudinaryConfiguration;
        private readonly PathsConfiguration _pathsConfiguration;
        private readonly IPostRepository _postRepository;

        public AddPostModule(IPostRepository postRepository, CloudinaryConfiguration cloudinaryConfiguration, PathsConfiguration pathsConfiguration)
        {
            _postRepository = postRepository;
            _cloudinaryConfiguration = cloudinaryConfiguration;
            _pathsConfiguration = pathsConfiguration;
        }

        public HttpResponseMessage AddPost(HttpRequestMessage request)
        {
            var httpRequest = HttpContext.Current.Request;

            var image = httpRequest.Files["image"];

            if (!CheckIfFileIsValid(image, out var message))
                return request.CreateResponse(HttpStatusCode.BadRequest, message);

            var dataUri = ConvertImageToBase64String(image);

            var imageUri = UploadToCludinary(dataUri);

            var userId = ClaimsPrincipalWrapper.GetFromClaim(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return request.CreateResponse(HttpStatusCode.ExpectationFailed, message);

            var post = new Post
            {
                CreationDate = DateTime.Now,
                Image = imageUri.ToString(),
                Op = new User
                {
                    Id = Convert.ToInt32(userId)
                },
                Title = httpRequest.Form.Get("title")
            };

            _postRepository.AddPost(post);

            return request.CreateResponse(HttpStatusCode.OK, message);
        }

        private static bool CheckIfFileIsValid(HttpPostedFile file, out string message)
        {
            if (file == null || file.ContentLength <= 0)
            {
                message = "Nie wybrano obrazka";
                return false;
            }

            var allowedFileExtensions = new List<string> {".jpg", ".gif", ".png", ".jpeg"};
            var extension = file.FileName.Substring(file.FileName.LastIndexOf('.')).ToLower();
            if (!allowedFileExtensions.Contains(extension))
            {
                message = "Nieobsługiwalny format pliku";
                return false;
            }

            var maxContentLength = 1 * 1024 * 1024;
            if (file.ContentLength > maxContentLength)
            {
                message = "Za duży obrazek";
                return false;
            }

            message = "Dodano obrazek";
            return true;
        }

        private static string ConvertImageToBase64String(HttpPostedFile image)
        {
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                image.InputStream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            return "data:" + image.ContentType + ";base64," + Convert.ToBase64String(bytes);
        }

        private Uri UploadToCludinary(string dataUri)
        {
            var account = new Account(
                _cloudinaryConfiguration.CloudName,
                _cloudinaryConfiguration.ApiKey,
                _cloudinaryConfiguration.ApiSecret
            );

            var cloudinary = new Cloudinary(account);

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(dataUri),
                Transformation = new Transformation().Width(1000).FetchFormat("auto"),
                Folder = _pathsConfiguration.MemeFolderName
            };

            var uploadResult = cloudinary.Upload(uploadParams);
            return uploadResult.Uri;
        }
    }
}