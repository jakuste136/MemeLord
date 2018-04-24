using System;
using System.Collections.Generic;
using MemeLord.Models;
using FluentAssertions;
using NUnit.Framework;
using MemeLord.DataObjects.Request.Reports;
using MemeLord.Logic.Mapping.Reports;

namespace Test.Unit.Logic.Mapping.ReportMapping
{
    class AddReportMapperTest
    {
        [Test]
        public void Can_Map_From_AddReportRequest_To_Report()
        {
            //ARRANGE
            var report = new AddReportRequest
            {
                PostId = null,
                CommentId = 1,
                ReporterId = 2,
                ReportDate = new DateTime(2013, 1, 1),
                ReportTypeId = 3
            };

            //ACT
            var newCommentReportMapper = new NewReportMapper();
            var result = newCommentReportMapper.Map(report);

            //ASSERT
            var expectedResult = new Report
            {
                Post = null,
                Comment = new Comment { Id = 1 },
                Reporter = new User { Id = 2 },
                ReportDate = new DateTime(2013, 1, 1),
                ReportType = new ReportType { Id = 3 }
            };
            result.Should().BeEquivalentTo(expectedResult);

            //ARRANGE
            report.PostId = 1;
            report.CommentId = null;

            //ACT
            result = newCommentReportMapper.Map(report);

            //ASSERT
            expectedResult.Post = new Post { Id = 1 };
            expectedResult.Comment = null;
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void Can_Map_From_AddReportRequest_List_To_Reports_List()
        {
            //ARRANGE
            var reportList = new List<AddReportRequest>
            {
                new AddReportRequest
                {
                    CommentId = 1,
                    ReporterId = 2,
                    ReportDate = new DateTime(2013, 1, 1),
                    ReportTypeId = 3
                },
                new AddReportRequest
                {
                    PostId = null,
                    CommentId = 2,
                    ReporterId = 3,
                    ReportDate = new DateTime(2014, 1, 1),
                    ReportTypeId = 4
                },
                new AddReportRequest
                {
                    PostId = 3,
                    CommentId = null,
                    ReporterId = 4,
                    ReportDate = new DateTime(2015, 1, 1),
                    ReportTypeId = 5
                }
            };

            //ACT
            var newCommentReportMapper = new NewReportMapper();
            var result = newCommentReportMapper.Map(reportList);

            //ASSERT
            var expectedResult = new List<Report>
            {
                new Report
                {
                    Post = null,
                    Comment = new Comment { Id = 1 },
                    Reporter = new User { Id = 2 },
                    ReportDate = new DateTime(2013, 1, 1),
                    ReportType = new ReportType { Id = 3 }
                },
                new Report
                {
                    Post = null,
                    Comment = new Comment { Id = 2 },
                    Reporter = new User { Id = 3 },
                    ReportDate = new DateTime(2014, 1, 1),
                    ReportType = new ReportType { Id = 4 }
                },
                new Report
                {
                    Post = new Post { Id = 3 },
                    Comment = null,
                    Reporter = new User { Id = 4 },
                    ReportDate = new DateTime(2015, 1, 1),
                    ReportType = new ReportType { Id = 5 }
                }
            };
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}