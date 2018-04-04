using System;
using System.Collections.Generic;
using MemeLord.Models;
using Test.Unit.TestUtils;
using FluentAssertions;
using MemeLord.DataObjects.Request;
using NUnit.Framework;
using MemeLord.Logic.Mapping.CommentMapping;

namespace Test.Unit.Logic.Mapping.CommentMapping
{
    class NewCommentMapperTests
    {
        [Test]
        public void Can_Map_From_AddCommentRequest_To_Comment()
        {
            //ARRANGE
            var commentRequest = new AddCommentRequest
            {
                PostId = 1,
                MasterCommentId = 1,
                UserId = 1,
                Rating = 1,
                CreationDate = new DateTime(2013, 1, 1),
                Text = "text"
            };

            //ACT
            var sut = new NewCommentMapper();
            var result = sut.Map(commentRequest);

            //ASSERT
            result.ShouldHavePropertyCount(9);

            var expectedResult = new Comment
            {
                Post = new Post {Id = 1},
                MasterComment = new Comment {Id = 1},
                Answers = null,
                User = new User {Id = 1},
                Rating = 1,
                CreationDate = new DateTime(2013, 1, 1),
                DeletionDate = null,
                Text = "text"
            };
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void Can_Map_From_AddCommentRequests_Collection_To_Comments_Collection()
        {
            //ARRANGE
            var commentRequestList = new List<AddCommentRequest>
            {
                new AddCommentRequest
                {
                    PostId = 1,
                    MasterCommentId = 1,
                    UserId = 1,
                    Rating = 1,
                    CreationDate = new DateTime(2013, 1, 1),
                    Text = "text"
                }
            };

            //ACT
            var sut = new NewCommentMapper();
            var result = sut.Map(commentRequestList);

            //ASSERT
            var expectedResult = new List<Comment>
            {
                new Comment
                {
                    Post = new Post {Id = 1},
                    MasterComment = new Comment {Id = 1},
                    Answers = null,
                    User = new User {Id = 1},
                    Rating = 1,
                    CreationDate = new DateTime(2013, 1, 1),
                    DeletionDate = null,
                    Text = "text"
                }
            };
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
