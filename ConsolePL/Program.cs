using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using BLL;
using CompositionRoot;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.Load<MvcResolver>();
        }

        static void Main(string[] args)
        {
            var userService = resolver.Get<IUserService>();
            var statisticsService = resolver.Get<ITestingStatisticsService>();
            var userStatisticsService = resolver.Get<IUserTestingStatisticService>();
            var testService = resolver.Get<ITestService>();

            
            //var test = new BllTest
            //{
            //    Id = 4/*2312*/,
            //    Name = "Physics 101",
            //    Created = DateTime.Now,
            //    Subject = new BllSubject { Id = 1 /*Name = "Physics" */},
            //    User = new BllUser
            //    {
            //        Id = 1,
            //        //Name = "Philip",
            //        //LastName = "Kozlov",
            //        //Email = "test@test.com",
            //        //Password = "123",
            //        //Roles = new BllRole[] { new BllRole { Name = "Administrator" } }
            //    },
            //    IsTimed = true,
            //    TimeToComplete = TimeSpan.FromMinutes(10),
            //    Questions = new List<BllQuestion>
            //            {
            //                new BllQuestion
            //                {
            //                    Id = 4/*23312*/,
            //                    TestId = 4/*23123123*/,
            //                    QuestionText = "What`s up?",
            //                    Answers = new List<BllAnswer>
            //                                {
            //                                    new BllAnswer
            //                                    {
            //                                        Id = 7/*2389*/,
            //                                        QuestionId = 4/*091*/,
            //                                        AnswerText = "Not much.",
            //                                        IsCorrect = false
            //                                    },
            //                                    new BllAnswer
            //                                    {
            //                                        Id = 8/*389*/,
            //                                        QuestionId = 4/*91*/,
            //                                        AnswerText = "Greate.",
            //                                        IsCorrect = true
            //                                    }
            //                                }
            //                }
            //            }
            //};

            try
            {
                //var user = userService.GetUser(1);
                //user.Roles.Add(new BllRole { Id = 4 });
                //user.Roles.Remove(user.Roles.ElementAt(1));
                //user.Roles.Add(new BllRole { Id = 5, Name = "Super Admin" });
                //userService.UpdateUser(user);
                //var user = new BllUser
                //{
                //    Id = 353,
                //    Name = "Test",
                //    LastName = "Test",
                //    Email = "test@test.com",
                //    Password = "123",
                //    Roles = new BllRole[] { new BllRole { Id = 1 } }
                //};
                //userService.CreateUser(user);

                var dbTest = testService.GetTest(4);
                dbTest.Name = "Updated Physics 101";
                dbTest.Questions.Add(
                            new BllQuestion
                            {
                                TestId = dbTest.Id,
                                QuestionText = "How do you do?",
                                Answers = new List<BllAnswer>
                                            {
                                                new BllAnswer
                                                {
                                                    AnswerText = "Fine.",
                                                    IsCorrect = false
                                                },
                                                new BllAnswer
                                                {
                                                    AnswerText = "So-so.",
                                                    IsCorrect = true
                                                }
                                            }

                            });
                dbTest.Questions.Remove(dbTest.Questions.ElementAt(1));
                testService.UpdateTest(dbTest);
            }
            catch (Exception ex)
            {

            }
            var testsAll = testService.GetAllTests();
            var tests = testService.GetTestsByName("ph");

            foreach (var t in tests)
            {
                Console.WriteLine($"{t.Id} {t.Name} {t.IsTimed} {t.TimeToComplete}");
                foreach (var q in t.Questions)
                {
                    Console.WriteLine($"{q.Id} {q.QuestionText}");
                    foreach (var a in q.Answers)
                    {
                        Console.WriteLine($"{a.Id} {a.IsCorrect} {a.AnswerText}");
                    }
                }
            }

            //var users = userService.GetAllUsers().ToList();
            //foreach (var u in users)
            //{
            //    Console.Write($"{u.Id} {u.Name} {u.LastName} ");
            //    foreach (var r in u.Roles) Console.WriteLine($" {r.Name} ");
            //}

            //var statistics = statisticsService.GetStatistics();

            //Console.WriteLine($"{statistics.CompletedTestsPerDay} {statistics.TotalTestingTime} ");
            //foreach (var us in statistics.UserStatistics)
            //    Console.WriteLine($"{us.AverageGrade} {us.MaxGrade} {us.MaxTestTime} {us.MinGrade} {us.MinTestTime} {us.NumberOfCompletedTests}");


            //Console.WriteLine(userStatisticsService.GetStatisticForUser(users.FirstOrDefault()));

            ////var tests = testService.GetTestsByUser(users.FirstOrDefault());
            //var tests = testService.GetTestsByName("phys");

            //foreach (var t in tests)
            //{
            //    Console.WriteLine($"{t.Id} {t.Name} {t.IsTimed} {t.TimeToComplete}");
            //    foreach (var q in t.Questions)
            //    {
            //        Console.WriteLine($"{q.Id} {q.QuestionText}");
            //        foreach (var a in q.Answers)
            //        {
            //            Console.WriteLine($"{a.Id} {a.IsCorrect} {a.AnswerText}");
            //        }
            //    }
            //}

            Console.ReadKey();
        }
    }
}
