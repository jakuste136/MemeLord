using System;
using System.Collections.Generic;
using MemeLord.DataObjects.Dto;
using MemeLord.Models;
using Test.Unit.TestUtils;
using FluentAssertions;
using MemeLord.Logic.Mapping.CommentMapping;

namespace Test.Unit.Logic.Mapping.CommentMapping
{
    class MasterCommentMapperTests
    {
        public void Can_Map_From_Comment_To_CommentDto()
        {
            //ARRANGE
            var comment = new Comment
            {
                Post = new Post(),
                MasterComment = null,
                Answers = new List<Comment>
                {
                    new Comment
                    {
                        Post = new Post(),
                        MasterComment = null, //will be comment
                        Answers = null,
                        User = new User {Username = "username"},
                        Rating = 1,
                        DeletionDate = new DateTime(2014, 1, 1),
                        CreationDate = new DateTime(2013, 1, 1),
                        Text = "text"
                    }
                },
                User = new User {Username = "username"},
                Rating = 1,
                DeletionDate = new DateTime(2014, 1, 1),
                CreationDate = new DateTime(2013, 1, 1),
                Text = "text"
            };
            comment.Answers[0].MasterComment = comment;

            //ACT
            var sutChild = new AnswerCommentMapper();
            var sut = new MasterCommentMapper(sutChild);
            var result = sut.Map(comment);

            //ASSERT
            result.ShouldHavePropertyCount(5);

            var expectedResult = new CommentDto
            {
                Username = "username",
                Rating = 1,
                Answers = new List<CommentDto>
                {
                    new CommentDto
                    {
                        Username = "username",
                        Rating = 1,
                        Answers = null,
                        CreationDate = new DateTime(2013, 1, 1),
                        Text = "text"
                    }
                },
                CreationDate = new DateTime(2013, 1, 1),
                Text = "text"
            };
            result.Should().BeEquivalentTo(expectedResult);
        }

        public void Can_Map_From_Comments_Collection_To_CommentDtos_Collection()
        {
            //ARRANGE
            var commentsList = new List<Comment>
            {
                new Comment
                {
                    Post = new Post(),
                    MasterComment = null,
                    Answers = new List<Comment>
                    {
                        new Comment
                        {
                            Post = new Post(),
                            MasterComment = new Comment(),
                            Answers = null,
                            User = new User {Username = "username"},
                            Rating = 1,
                            DeletionDate = new DateTime(2014, 1, 1),
                            CreationDate = new DateTime(2013, 1, 1),
                            Text = "text"
                        }
                    },
                    User = new User {Username = "username"},
                    Rating = 1,
                    DeletionDate = new DateTime(2014, 1, 1),
                    CreationDate = new DateTime(2013, 1, 1),
                    Text = "text"
                }
            };

            //ACT
            var sutChild = new AnswerCommentMapper();
            var sut = new MasterCommentMapper(sutChild);
            var result = sut.Map(commentsList);

            //ASSERT
            var expectedResult = new List<CommentDto>
            {
                new CommentDto
                {
                    Username = "username",
                    Rating = 1,
                    Answers = new List<CommentDto>
                    {
                        new CommentDto
                        {
                            Username = "username",
                            Rating = 1,
                            Answers = null,
                            CreationDate = new DateTime(2013, 1, 1),
                            Text = "text"
                        }
                    },
                    CreationDate = new DateTime(2013, 1, 1),
                    Text = "text"
                }
            };
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
