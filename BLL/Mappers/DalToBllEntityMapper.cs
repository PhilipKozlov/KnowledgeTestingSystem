using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    /// <summary>
    /// Maps DAL entities to BLL entities.
    /// </summary>
    internal static class DalToBllEntityMapper
    {
        #region Extension Methods
        /// <summary>
        /// Maps DalUser entity to  BllUser entity.
        /// </summary>
        /// <param name="user"> DalUser instance.</param>
        /// <returns> BllUser instance.</returns>
        public static BllUser ToBllUser(this DalUser user)
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
        /// Maps DalRole entity to  BllRole entity.
        /// </summary>
        /// <param name="role"> DalRole instance.</param>
        /// <returns> BllRole instance.</returns>
        public static BllRole ToBllRole(this DalRole role)
        {
            return new BllRole()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        /// <summary>
        /// Maps DalSubject entity to  BllSubject entity.
        /// </summary>
        /// <param name="subject"> DalSubject instance.</param>
        /// <returns> BllSubject instance.</returns>
        public static BllSubject ToBllSubject(this DalSubject subject)
        {
            return new BllSubject()
            {
                Id = subject.Id,
                Name = subject.Name
            };
        }

        /// <summary>
        /// Maps DalTest entity to  BllTest entity.
        /// </summary>
        /// <param name="test"> DalTest instance.</param>
        /// <returns> BllTest instance.</returns>
        public static BllTest ToBllTest(this DalTest test)
        {
            return new BllTest()
            {
                Id = test.Id,
                Name = test.Name,
                Created = test.Created,
                IsTimed = test.IsTimed,
                TimeToComplete = test.TimeToComplete,
                Subject = test.Subject?.ToBllSubject(),
                UserId = test.User?.Id,
                Questions = test.Questions.Select(q => q.ToBllQuestion()).ToList()
            };
        }

        /// <summary>
        /// Maps DalQuestion entity to  BllQuestion entity.
        /// </summary>
        /// <param name="question"> DalQuestion instance.</param>
        /// <returns> BllQuestion instance.</returns>
        public static BllQuestion ToBllQuestion(this DalQuestion question)
        {
            return new BllQuestion()
            {
                Id = question.Id,
                TestId = question.TestId,
                QuestionText = question.QuestionText,
                Answers = question.Answers.Select(a => a.ToBllAnswer()).ToList()
            };
        }

        /// <summary>
        /// Maps DalAnswer entity to  BllAnswer entity.
        /// </summary>
        /// <param name="answer"> DalAnswer instance.</param>
        /// <returns> BllAnswer instance.</returns>
        public static BllAnswer ToBllAnswer(this DalAnswer answer)
        {
            return new BllAnswer()
            {
                Id = answer.Id,
                QuestionId = answer.QuestionId,
                AnswerText = answer.AnswerText,
                IsCorrect = answer.IsCorrect
            };
        }

        /// <summary>
        /// Maps DalTestResult entity to  BllTestResult entity.
        /// </summary>
        /// <param name="testResult"> DalTestResult instance.</param>
        /// <returns> BllTestResult instance.</returns>
        public static BllTestResult ToBllTestResult(this DalTestResult testResult)
        {
            return new BllTestResult()
            {
                Id = testResult.Id,
                Grade = testResult.Grade,
                DateTime = testResult.DateTime,
                TimeSpent = testResult.TimeSpent,
                Test = testResult?.Test.ToBllTest(),
                UserId = testResult.User.Id,
                UserName = testResult.User.Email
            };
        }
        #endregion
    }
}
