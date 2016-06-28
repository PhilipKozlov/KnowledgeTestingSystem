using System.Linq;
using MvcPL.Models;
using BLL.DTO;

namespace MvcPL.Infrastructure.Mappers
{
    /// <summary>
    /// Maps BLL entities to Mvc view models.
    /// </summary>
    internal static class MvcPLToBllEntityMapper
    {
        #region Extension Methods
        /// <summary>
        /// Maps UserViewModel entity to  BllUser entity.
        /// </summary>
        /// <param name="user"> UserViewModel instance.</param>
        /// <returns> BllUser instance.</returns>
        public static BllUser ToBllUser(this UserViewModel user)
        {
            return new BllUser()
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Roles = user.Roles.Select(r => r.ToBllRole()).ToList()
            };
        }

        /// <summary>
        /// Maps RoleViewModel entity to  BllRole entity.
        /// </summary>
        /// <param name="role"> RoleViewModel instance.</param>
        /// <returns> BllRole instance.</returns>
        public static BllRole ToBllRole(this RoleViewModel role)
        {
            return new BllRole()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
            };
        }
        /// <summary>
        /// Maps SubjectViewModel entity to BllSubject.
        /// </summary>
        /// <param name="subject"> SubjectViewModel instance.</param>
        /// <returns> BllSubject instance.</returns>
        public static BllSubject ToBllSubject(this SubjectViewModel subject)
        {
            return new BllSubject
            {
                Id = subject.Id,
                Name = subject.Name
            };
        }

        /// <summary>
        /// Maps TestViewModel entity to BllTest.
        /// </summary>
        /// <param name="test"> TestViewModel instance.</param>
        /// <returns> BllTest instance.</returns>
        public static BllTest ToBllTest(this TestViewModel test)
        {
            return new BllTest
            {
                Id = test.Id,
                Name = test.Name,
                Subject = new BllSubject { Id = test.SubjectId, Name = test.SubjectName},
                UserId = test.UserId,
                Created = test.Created,
                IsTimed = test.IsTimed,
                TimeToComplete = test.TimeToComplete,
                Questions = test.Questions.Select(q => q.ToBllQuestion()).ToList()
            };
        }

        /// <summary>
        /// Maps QuestionViewModel entity to BllQuestion.
        /// </summary>
        /// <param name="question"> QuestionViewModel instance.</param>
        /// <returns> BllQuestion instance.</returns>
        public static BllQuestion ToBllQuestion(this QuestionViewModel question)
        {
            return new BllQuestion
            {
                Id = question.Id,
                TestId = question.TestId,
                QuestionText = question.QuestionText,
                Answers = question.Answers.Select(a => a.ToBllAnswer()).ToList()
            };
        }

        /// <summary>
        /// Maps AnswerViewModel entity to BllAnswer.
        /// </summary>
        /// <param name="answer"> AnswerViewModel instance.</param>
        /// <returns> BllAnswer instance.</returns>
        public static BllAnswer ToBllAnswer(this AnswerViewModel answer)
        {
            return new BllAnswer
            {
                Id = answer.Id,
                QuestionId = answer.QuestionId,
                IsCorrect = answer.IsCorrect,
                AnswerText = answer.AnswerText
            };
        }

        /// <summary>
        /// Maps TestResultViewModel entity to BllTestResult entity.
        /// </summary>
        /// <param name="testResult"> TestResultViewModel instance.</param>
        /// <returns> BllTestResult instance.</returns>
        public static BllTestResult ToBllTestResult(this TestResultViewModel testResult)
        {
            return new BllTestResult
            {
                Id = testResult.Id,
                DateTime = testResult.DateTime,
                Grade = testResult.Grade,
                TimeSpent = testResult.TimeSpent,
                UserId = testResult.UserId,
                Test = new BllTest { Id = testResult.TestId.GetValueOrDefault()}
            };
        }

        /// <summary>
        /// Maps CompletedTestViewModel to BllCompletedTest
        /// </summary>
        /// <param name="completedTest"> CompletedTestViewModel instance.</param>
        /// <returns> BllCompletedTest instance.</returns>
        public static BllCompletedTest ToBllCompletedTest(this CompletedTestViewModel completedTest)
        {
            return new BllCompletedTest
            {
                Test = completedTest.Test.ToBllTest(),
                UserId = completedTest.UserId,
                ChoosenAnswers = completedTest.ChoosenAnswers.Select(a => a.ToBllAnswer()).ToList(),
                TimeSpent = completedTest.TimeSpent
            };
        }
        #endregion
    }
}