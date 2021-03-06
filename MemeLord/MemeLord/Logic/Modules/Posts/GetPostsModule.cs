﻿using MemeLord.DataObjects.Dto;
using MemeLord.DataObjects.Response.Posts;
using MemeLord.Logic.Mapping;
using MemeLord.Logic.Repository;
using MemeLord.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MemeLord.Logic.Modules.Posts
{
    public interface IGetPostsModule
    {
        GetPostsResponse GetPosts(int lastId, int count);
        GetPostsResponse GetUserPosts(int lastId, int count, string authorName);
        PostDto GetPost(int id);
        GetPostsResponse GetTopPosts(int lastId, int count);
    }

    public class GetPostsModule : IGetPostsModule
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostMapper _postMapper;

        public GetPostsModule(IPostRepository postRepository, IPostMapper postMapper)
        {
            _postRepository = postRepository;
            _postMapper = postMapper;
        }

        public GetPostsResponse GetPosts(int lastId, int count)
        {
            var posts = _postRepository.GetPosts(lastId, count);
            
            var postDtos = _postMapper.Map(posts);

            return new GetPostsResponse
            {
                LastId = GetLastId(posts),
                PostsList = postDtos
            };
        }

        public GetPostsResponse GetTopPosts(int lastId, int count)
        {
            var topPosts = _postRepository.GetTopPosts(lastId, count);

            var postDtos = _postMapper.Map(topPosts);

            return new GetPostsResponse
            {
                LastId = GetLastId(topPosts),
                PostsList = postDtos
            };
        }

        public PostDto GetPost(int id)
        {
            var post = _postRepository.GetPostById(id);
            return _postMapper.Map(post);
        }

        private static int GetLastId(List<Post> posts)
        {
            return posts.Count == 0 ? 0 : posts.Last().Id;
        }

        public GetPostsResponse GetUserPosts(int lastId, int count, string authorName)
        {
            var posts = _postRepository.GetUserPosts(lastId, count, authorName);

            var postDtos = _postMapper.Map(posts);

            return new GetPostsResponse
            {
                LastId = GetLastId(posts),
                PostsList = postDtos
            };
        }
    }
}