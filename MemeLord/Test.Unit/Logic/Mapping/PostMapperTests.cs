using System;
using FluentAssertions;
using MemeLord.Logic.Dto;
using MemeLord.Logic.Mapping;
using MemeLord.Models;
using NUnit.Framework;
using Test.Unit.TestUtils;

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
                CreationDate = new DateTime(2015, 1, 1),
                Image = "image",
                Rating = 1,
                Title = "Title",
                DeletionDate = new DateTime(2016, 1, 1),
            };

            // act
            var sut = new Mapper<Post, PostDto>();
            var result = sut.Map(post);

            // assert
            result.ShouldHavePropertyCount(5);

            var expectedResult = new PostDto
            {
                CreationDate = new DateTime(2015, 1, 1),
                Image = "image",
                Rating = 1,
                Title = "Title",
                DeletionDate = new DateTime(2016, 1, 1)
            };
            
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}