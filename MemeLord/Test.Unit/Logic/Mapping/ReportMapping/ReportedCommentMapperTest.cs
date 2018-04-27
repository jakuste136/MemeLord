using System;
using System.Collections.Generic;
using MemeLord.DataObjects.Dto.ReportDtos;
using MemeLord.Models;
using FluentAssertions;
using NUnit.Framework;
using MemeLord.Logic.Mapping.Reports;

namespace Test.Unit.Logic.Mapping.ReportMapping
{
    class ReportedCommentMapperTest
    {
        [Test]
        public void Can_Map_From_Report_To_ReportDto()
        {
            //ARRANGE
            var report = new Report
            {
                Comment = new Comment
                {
                    Id = 1,
                    User = new User { Username = "user" },
                    Text = "text",
                    CreationDate = new DateTime(2013, 1, 1)
                },
                Post = null,
                Reporter = new User(),
                ReportDate = new DateTime(2015, 1, 1),
                ReportType = new ReportType
                {
                    Id = 1,
                    Description = "jeden"
                }
            };
            //ACT
            var reportedCommentMapper = new ReportedCommentMapper();
            var result = reportedCommentMapper.Map(report);
            //ASSERT
            var expectedResult = new ReportedCommentDto
            {
                Username = "user",
                Text = "text",
                CreationDate = new DateTime(2013, 1, 1),
                Description = "jeden",
                CommentId = 1
            };
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void Can_Map_From_Report_List_To_ReportedPostDtos()
        {
            //ARRANGE
            var reports = new List<Report>
            {
                new Report
                {
                    Comment = new Comment
                {
                    Id = 1,
                    User = new User { Username = "user" },
                    Text = "text",
                    CreationDate = new DateTime(2013, 1, 1)
                },
                Post = null,
                Reporter = new User(),
                ReportDate = new DateTime(2015, 1, 1),
                ReportType = new ReportType
                {
                    Id = 1,
                    Description = "jeden"
                }
                },
                new Report
                {
                     Comment = new Comment
                    {
                        Id = 2,
                        User = new User { Username = "user" },
                    Text = "text",
                    CreationDate = new DateTime(2013, 1, 1)
                    },
                    Post = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2015, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 2,
                        Description = "dwa"
                    }
                }
            };
            //ACT
            var reportedCommentMapper = new ReportedCommentMapper();
            var result = reportedCommentMapper.Map(reports);
            //ASSERT
            var expectedResult = new List<ReportedCommentDto>
            {
                new ReportedCommentDto
                {
                    Username = "user",
                    Text = "text",
                    CreationDate = new DateTime(2013, 1, 1),
                    Description = "jeden",
                    CommentId = 1
                },
                new ReportedCommentDto
                {
                    Username = "user",
                    Text = "text",
                    CreationDate = new DateTime(2013, 1, 1),
                    Description = "dwa",
                    CommentId = 2
                }
            };
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}