using System;
using FluentAssertions;
using MemeLord.Logic.Dto;
using MemeLord.Logic.Mapping;
using MemeLord.Models;
using NUnit.Framework;
using Test.Unit.TestUtils;
using System.Collections.Generic;

namespace Test.Unit.Logic.Mapping
{
    public class PostMapperTests
    {
        [Test]
        public void Can_Map_From_Post_To_PostDto()
        {
            //ARRANGE
            var post = new Post
            {
                Op = new User { Username = "username" },
                CreationDate = new DateTime(2015, 1, 1),
                Image = "image",
                Rating = 1,
                Title = "title",
                DeletionDate = new DateTime(2016, 1, 1)
            };

            //ACT
            var sut = new Mapper<Post, PostDto>();
            var result = sut.Map(post);

            //ASSERT
            result.ShouldHavePropertyCount(6);

            var expectedResult = new PostDto
            {
                Username = "username",
                CreationDate = new DateTime(2015, 1, 1),
                Image = "image",
                Rating = 1,
                Title = "title",
                DeletionDate = new DateTime(2016, 1, 1)
            };

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void Can_Map_From_Posts_Collection_To_PostDtos_Collection()
        {
            //ARRANGE
            var postsList = new List<Post>
            {
                new Post
                {
                    Op = new User { Username = "username" },
                    CreationDate = new DateTime(2015, 1, 1),
                    Image = "image",
                    Rating = 1,
                    Title = "title",
                    DeletionDate = new DateTime(2016, 1, 1)
                }
            };

            //ACT
            var sut = new Mapper<Post, PostDto>();
            var result = sut.MapList(postsList);

            //ASSERT
            var expectedResult = new List<PostDto>
            {
                new PostDto
                {
                    Username = "username",
                    CreationDate = new DateTime(2015, 1, 1),
                    Image = "image",
                    Rating = 1,
                    Title = "title",
                    DeletionDate = new DateTime(2016, 1, 1)
                }
            };
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}