using System;
using System.Collections.Generic;
using MemeLord.Models;
using FluentAssertions;
using NUnit.Framework;
using MemeLord.Logic.Modules.Reports;

namespace Test.Unit.Logic.Modules
{
    class FindMostFrequentReportTest
    {
        [Test]
        public void Can_Find_Most_Frequent_Report_For_Post()
        {
            //ARRANGE
            List<Report> reports = new List<Report>
            {
                new Report
                {
                    Post = new Post { Id = 1 },
                    Comment = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2014, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 1,
                        Description = "jeden"
                    }
                },
                new Report
                {
                    Post = new Post { Id = 1 },
                    Comment = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2016, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 3,
                        Description = "trzy"
                    }
                },
                new Report
                {
                    Post = new Post { Id = 1 },
                    Comment = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2015, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 2,
                        Description = "dwa"
                    }
                },
                new Report
                {
                    Post = new Post { Id = 1 },
                    Comment = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2016, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 3,
                        Description = "trzy"
                    }
                },
                new Report
                {
                    Post = new Post { Id = 1 },
                    Comment = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2015, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 2,
                        Description = "dwa"
                    }
                },
                new Report
                {
                    Post = new Post { Id = 1 },
                    Comment = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2016, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 3,
                        Description = "trzy"
                    }
                },
                new Report
                {
                    Post = new Post { Id = 2 },
                    Comment = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2015, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 2,
                        Description = "dwa"
                    }
                },
                new Report
                {
                    Post = new Post { Id = 2 },
                    Comment = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2015, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 2,
                        Description = "dwa"
                    }
                },
                new Report
                {
                    Post = new Post { Id = 2 },
                    Comment = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2016, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 3,
                        Description = "trzy"
                    }
                },
                new Report
                {
                    Post = new Post { Id = 3 },
                    Comment = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2014, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 1,
                        Description = "jeden"
                    }
                }
            };

            //ACT
            var findMostFrequentReport = new FindMostFrequentReport();
            var result = findMostFrequentReport.ForPost(reports, 2, 10);

            //ASSERT
            var expectedResult = new List<Report>
            {
                new Report
                {
                    Post = new Post { Id = 1 },
                    Comment = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2016, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 3,
                        Description = "trzy"
                    }
                },
                new Report
                {
                    Post = new Post { Id = 2 },
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
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void Can_Find_Most_Frequent_Report_For_Comment()
        {
            //ARRANGE
            List<Report> reports = new List<Report>
            {
                new Report
                {
                    Comment = new Comment { Id = 1 },
                    Post = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2014, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 1,
                        Description = "jeden"
                    }
                },
                new Report
                {
                    Comment = new Comment { Id = 1 },
                    Post = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2016, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 3,
                        Description = "trzy"
                    }
                },
                new Report
                {
                    Comment = new Comment { Id = 1 },
                    Post = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2015, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 2,
                        Description = "dwa"
                    }
                },
                new Report
                {
                    Comment = new Comment { Id = 1 },
                    Post = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2016, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 3,
                        Description = "trzy"
                    }
                },
                new Report
                {
                    Comment = new Comment { Id = 1 },
                    Post = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2015, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 2,
                        Description = "dwa"
                    }
                },
                new Report
                {
                    Comment = new Comment { Id = 1 },
                    Post = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2016, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 3,
                        Description = "trzy"
                    }
                },
                new Report
                {
                    Comment = new Comment { Id = 2 },
                    Post = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2015, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 2,
                        Description = "dwa"
                    }
                },
                new Report
                {
                    Comment = new Comment { Id = 2 },
                    Post = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2015, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 2,
                        Description = "dwa"
                    }
                },
                new Report
                {
                    Comment = new Comment { Id = 2 },
                    Post = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2016, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 3,
                        Description = "trzy"
                    }
                },
                new Report
                {
                    Comment = new Comment { Id = 3 },
                    Post = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2014, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 1,
                        Description = "jeden"
                    }
                }
            };

            //ACT
            var findMostFrequentReport = new FindMostFrequentReport();
            var result = findMostFrequentReport.ForComment(reports, 2, 10);

            //ASSERT
            var expectedResult = new List<Report>
            {
                new Report
                {
                    Comment = new Comment { Id = 1 },
                    Post = null,
                    Reporter = new User(),
                    ReportDate = new DateTime(2016, 1, 1),
                    ReportType = new ReportType
                    {
                        Id = 3,
                        Description = "trzy"
                    }
                },
                new Report
                {
                    Comment = new Comment { Id = 2 },
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
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}