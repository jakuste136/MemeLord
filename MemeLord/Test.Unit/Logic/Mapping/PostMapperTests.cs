using System;
using FluentAssertions;
using MemeLord.Logic.Dto;
using MemeLord.Logic.Mapping;
using MemeLord.Models;
using NUnit.Framework;

namespace Test.Unit.Logic.Mapping
{
    public class PostMapperTests
    {
        [Test]
        public void Can_Map_From_Post_To_PostDto()
        {
            // arrange
            var post = new Post
            {
                CreationDate = new DateTime(10, 1, 1),
                Id = 1,
                Image = "image",
                Rating = 1,
                Title = "Title"
            };

            // act
            var sut = new Mapper<Post, PostDto>();
            var result = sut.Map(post);

            // assert
            var expectedResult = new PostDto
            {
                CreationDate = new DateTime(10, 1, 1),
                Image = "image",
                Rating = 1,
                Title = "Title"
            };

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}