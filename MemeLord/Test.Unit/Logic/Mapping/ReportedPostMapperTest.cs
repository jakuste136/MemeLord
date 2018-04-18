using System;
using System.Collections.Generic;
using MemeLord.DataObjects.Dto.ReportDtos;
using MemeLord.Models;
using Test.Unit.TestUtils;
using FluentAssertions;
using NUnit.Framework;
using MemeLord.Logic.Mapping.Reports;

namespace Test.Unit.Logic.Mapping
{
    class ReportedPostMapperTest
    {
        [Test]
        public void Can_Map_From_Report_To_ReportDto()
        {
            //ARRANGE
            var report = new Report
            {
                Post = new Post
                {
                    Id = 1,
                    Op = new User { Username = "user" },
                    Title = "title",
                    Image = "image",
                    CreationDate = new DateTime(2013, 1, 1)
                },
                Comment = null,
                Reporter = new User(),
                ReportDate = new DateTime(2015, 1, 1),
                ReportType = new ReportType
                {
                    Id = 1,
                    Description = "jeden"
                }
            };
            //ACT
            var reportedPostMapper = new ReportedPostMapper();
            var result = reportedPostMapper.Map(report);
            //ASSERT
            var expectedResult = new ReportedPostDto
            {
                Username = "user",
                Title = "title",
                Image = "image",
                CreationDate = new DateTime(2013, 1, 1),
                Description = "jeden",
                PostId = 1
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
                    Post = new Post
                    {
                        Id = 1,
                        Op = new User { Username = "user" },
                        Title = "title",
                        Image = "image",
                        CreationDate = new DateTime(2013, 1, 1)
                    },
                    Comment = null,
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
                    Post = new Post
                    {
                        Id = 2,
                        Op = new User { Username = "user" },
                        Title = "title",
                        Image = "image",
                        CreationDate = new DateTime(2013, 1, 1)
                    },
                    Comment = null,
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
            var reportedPostMapper = new ReportedPostMapper();
            var result = reportedPostMapper.Map(reports);
            //ASSERT
            var expectedResult = new List<ReportedPostDto>
            {
                new ReportedPostDto
                {
                    Username = "user",
                    Title = "title",
                    Image = "image",
                    CreationDate = new DateTime(2013, 1, 1),
                    Description = "jeden",
                    PostId = 1
                },
                new ReportedPostDto
                {
                    Username = "user",
                    Title = "title",
                    Image = "image",
                    CreationDate = new DateTime(2013, 1, 1),
                    Description = "dwa",
                    PostId = 2
                }
            };
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}