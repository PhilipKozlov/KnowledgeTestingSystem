using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using MvcPL.Models;

namespace MvcPL
{
    /// <summary>
    /// Maps BLL entities to Mvc view models.
    /// </summary>
    internal static class BllToMvcPLEntityMapper
    {
        #region Extension Methods
        /// <summary>
        /// Maps BllUser entity to  UserViewModel entity.
        /// </summary>
        /// <param name="user"> BllUser instance.</param>
        /// <returns> UserViewModel instance.</returns>
        public static UserViewModel ToUserViewModel(this BllUser user)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Roles = user.Roles.Select(r => r.ToRoleViewModel()).ToList()
            };
        }

        /// <summary>
        /// Maps BllRole entity to  RoleViewModel entity.
        /// </summary>
        /// <param name="role"> BllRole instance.</param>
        /// <returns> RoleViewModel instance.</returns>
        public static RoleViewModel ToRoleViewModel(this BllRole role)
        {
            return new RoleViewModel()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
            };
        }
        /// <summary>
        /// Maps BllSubject entity to SubjectViewModel.
        /// </summary>
        /// <param name="subject"> BllSubject instance.</param>
        /// <returns> SubjectViewModel instance.</returns>
        public static SubjectViewModel ToSubjectViewModel(this BllSubject subject)
        {
            return new SubjectViewModel
            {
                Id = subject.Id,
                Name = subject.Name
            };
        }

        /// <summary>
        /// Maps BllTest entity to TestViewModel.
        /// </summary>
        /// <param name="test"> BllTest instance.</param>
        /// <returns> TestViewModel instance.</returns>
        public static TestViewModel ToTestViewModel(this BllTest test)
        {
            int i = 0;
            var testViewModel = new TestViewModel
            {
                Id = test.Id,
                Name = test.Name,
                SubjectName = test.Subject.Name,
                UserId = test.UserId.Value,
                Created = test.Created,
                IsTimed = test.IsTimed,
                TimeToComplete = test.TimeToComplete,
                Questions = test.Questions.Select(q => q.ToQuestionViewModel()).ToList()
            };
            testViewModel.Questions.ToList().ForEach(q => q.QuestionNumber = ++i);
            return testViewModel;
        }

        /// <summary>
        /// Maps BllQuestion entity to QuestionViewModel.
        /// </summary>
        /// <param name="question"> BllQuestion instance.</param>
        /// <returns> QuestionViewModel instance.</returns>
        public static QuestionViewModel ToQuestionViewModel(this BllQuestion question)
        {
            return new QuestionViewModel
            {
                Id = question.Id,
                TestId = question.TestId,
                QuestionText = question.QuestionText,
                Answers = question.Answers.Select(a => a.ToAnswerViewModel()).ToList()
            };
        }

        /// <summary>
        /// Maps BllAnswer entity to AnswerViewModel.
        /// </summary>
        /// <param name="answer"> BllAnswer instance.</param>
        /// <returns> AnswerViewModel instance.</returns>
        public static AnswerViewModel ToAnswerViewModel(this BllAnswer answer)
        {
            return new AnswerViewModel
            {
                Id = answer.Id,
                QuestionId = answer.QuestionId,
                IsCorrect = answer.IsCorrect,
                AnswerText = answer.AnswerText
            };
        }

        /// <summary>
        /// Maps BllTestResult entity to TestResultViewModel entity.
        /// </summary>
        /// <param name="testResult"> BllTestResult instance.</param>
        /// <returns> TestResultViewModel instance.</returns>
        public static TestResultViewModel ToTestResultViewModel(this BllTestResult testResult)
        {
            return new TestResultViewModel
            {
                Id = testResult.Id,
                DateTime = testResult.DateTime,
                Grade = testResult.Grade,
                TimeSpent = testResult.TimeSpent,
                UserId = testResult.UserId,
                TestId = testResult?.Test.Id,
                TestName = testResult?.Test.Name
            };
        }

        /// <summary>
        /// Maps BllUserTestingStatistic to UserTestingStatisticViewModel entity.
        /// </summary>
        /// <param name="userTestingStatistic"> BllUserTestingStatistic instance.</param>
        /// <returns> UserTestingStatisticViewModel instance.</returns>
        public static UserTestingStatisticViewModel ToUserTestigStatisticViewModel(this BllUserTestingStatistic userTestingStatistic)
        {
            return new UserTestingStatisticViewModel
            {
                UserName = userTestingStatistic.UserName,
                NumberOfCompletedTests = userTestingStatistic.NumberOfCompletedTests,
                AverageGrade = userTestingStatistic.AverageGrade,
                MaxGrade = userTestingStatistic.MaxGrade,
                MinGrade = userTestingStatistic.MinGrade,
                MaxTestTime = userTestingStatistic.MaxTestTime,
                MinTestTime = userTestingStatistic.MinTestTime
            };
        }

        /// <summary>
        /// Maps BllTestingStatistic to TestingStatisticViewModel entity.
        /// </summary>
        /// <param name="testingStatistic"> BllTestingStatistic instance.</param>
        /// <returns> TestingStatisticViewModel instance.</returns>
        public static TestingStatisticViewModel ToTestingStatisticViewModel(this BllTestingStatistic testingStatistic)
        {
            return new TestingStatisticViewModel
            {
                TotalNumberOfTests = testingStatistic.TotalNumberOfTests,
                CreatedTestsPerDay = testingStatistic.CreatedTestsPerDay,
                CompletedTestsPerDay = testingStatistic.CompletedTestsPerDay,
                TotalTestingTime = testingStatistic.TotalTestingTime,
                UserStatistics = testingStatistic.UserStatistics.Select(us => us.ToUserTestigStatisticViewModel()).ToList()
            };
        }
        #endregion
    }
}