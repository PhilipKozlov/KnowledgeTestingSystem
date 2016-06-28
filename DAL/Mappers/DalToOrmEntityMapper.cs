using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace DAL
{
    /// <summary>
    /// Maps Dal entities to ORM entities.
    /// </summary>
    internal static class DalToOrmEntityMapper
    {
        #region Extension Methods
        /// <summary>
        /// Maps DalUser entity to User entity.
        /// </summary>
        /// <param name="user"> DalUser instance.</param>
        /// <returns> User instance.</returns>
        public static User ToUser(this DalUser user)
        {
            return new User()
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Roles = user.Roles?.Select(r => r.ToRole()).ToList()
            };
        }

        /// <summary>
        /// Maps DalRole entity to  Role entity.
        /// </summary>
        /// <param name="role"> DalRole instance.</param>
        /// <returns> Role instance.</returns>
        public static Role ToRole(this DalRole role)
        {
            return new Role()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        /// <summary>
        /// Maps DalSubject entity to Subject entity.
        /// </summary>
        /// <param name="subject"> DalSubject instance.</param>
        /// <returns> Subject instance.</returns>
        public static Subject ToSubject(this DalSubject subject)
        {
            return new Subject()
            {
                Id = subject.Id,
                Name = subject.Name
            };
        }

        /// <summary>
        /// Maps DalTest entity to Test entity.
        /// </summary>
        /// <param name="test"> DalTest instance.</param>
        /// <returns> Test instance.</returns>
        public static Test ToTest(this DalTest test)
        {
            return new Test()
            {
                Id = test.Id,
                UserId = test.User.Id,
                SubjectId = test.Subject.Id,
                Name = test.Name,
                Created = test.Created,
                IsTimed = test.IsTimed,
                TimeToComplete = test.TimeToComplete,
                User = null,
                Subject = test.Subject?.Id == 0 ? test.Subject.ToSubject() : null,
                Questions = test.Questions.Select(q => q.ToQuestion()).ToList()
            };
        }

        /// <summary>
        /// Maps DalQuestion entity to Question entity.
        /// </summary>
        /// <param name="question"> DalQuestion instance.</param>
        /// <returns> Question instance.</returns>
        public static Question ToQuestion(this DalQuestion question)
        {
            return new Question()
            {
                Id = question.Id,
                TestId = question.TestId,
                QuestionText = question.QuestionText,
                Answers = question.Answers.Select(a => a.ToAnswer()).ToList()
            };
        }

        /// <summary>
        /// Maps DalAnswer entity to Answer entity.
        /// </summary>
        /// <param name="answer"> DalAnswer instance.</param>
        /// <returns> Answer instance.</returns>
        public static Answer ToAnswer(this DalAnswer answer)
        {
            return new Answer()
            {
                Id = answer.Id,
                QuestionId = answer.QuestionId,
                AnswerText = answer.AnswerText,
                IsCorrect = answer.IsCorrect,
            };
        }

        /// <summary>
        /// Maps DalTestResult entity to TestResult entity.
        /// </summary>
        /// <param name="testResult"> DalTestResult instance.</param>
        /// <returns> TestResult instance.</returns>
        public static TestResult ToTestResult(this DalTestResult testResult)
        {
            return new TestResult()
            {
                Id = testResult.Id,
                Grade = testResult.Grade,
                DateTime = testResult.DateTime,
                TimeSpent = testResult.TimeSpent,
                Test = null,
                User = null,
                UserId = testResult.User.Id,
                TestId = testResult.Test.Id
            };
        }
        #endregion
    }
}
