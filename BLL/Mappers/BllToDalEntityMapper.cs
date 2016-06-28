using System.Linq;
using DAL.DTO;
using BLL.DTO;

namespace BLL.Mappers
{
    /// <summary>
    /// Maps BLL entities to DAL entities.
    /// </summary>
    internal static class BllToDalEntityMapper
    {
        #region Extension Methods
        /// <summary>
        /// Maps BllUser entity to  DalUser entity.
        /// </summary>
        /// <param name="user"> BllUser instance.</param>
        /// <returns> DalUser instance.</returns>
        public static DalUser ToDalUser(this BllUser user)
        {
            return new DalUser()
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Roles = user.Roles?.Select(r => r.ToDalRole()).ToList()
            };
        }

        /// <summary>
        /// Maps BllRole entity to  DalRole entity.
        /// </summary>
        /// <param name="role"> BllRole instance.</param>
        /// <returns> DalRole instance.</returns>
        public static DalRole ToDalRole(this BllRole role)
        {
            return new DalRole()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        /// <summary>
        /// Maps BllSubject entity to  DalSubject entity.
        /// </summary>
        /// <param name="subject"> BllSubject instance.</param>
        /// <returns> DalSubject instance.</returns>
        public static DalSubject ToDalSubject(this BllSubject subject)
        {
            return new DalSubject()
            {
                Id = subject.Id,
                Name = subject.Name
            };
        }

        /// <summary>
        /// Maps BllTest entity to  DalTest entity.
        /// </summary>
        /// <param name="test"> BllTest instance.</param>
        /// <returns> DalTest instance.</returns>
        public static DalTest ToDalTest(this BllTest test)
        {
            return new DalTest()
            {
                Id = test.Id,
                Name = test.Name,
                Created = test.Created,
                IsTimed = test.IsTimed,
                TimeToComplete = test.TimeToComplete,
                Subject = test.Subject?.ToDalSubject(),
                User = (new BllUser { Id = (int)test?.UserId }).ToDalUser(),
                Questions = test.Questions.Select(q => q.ToDalQuestion()).ToList()
            };
        }

        /// <summary>
        /// Maps BllQuestion entity to  DalQuestion entity.
        /// </summary>
        /// <param name="question"> BllQuestion instance.</param>
        /// <returns> DalQuestion instance.</returns>
        public static DalQuestion ToDalQuestion(this BllQuestion question)
        {
            return new DalQuestion()
            {
                Id = question.Id,
                TestId = question.TestId,
                QuestionText = question.QuestionText,
                Answers = question.Answers.Select(a  => a.ToDalAnswer()).ToList()
            };
        }

        /// <summary>
        /// Maps BllAnswer entity to  DalAnswer entity.
        /// </summary>
        /// <param name="answer"> BllAnswer instance.</param>
        /// <returns> DalAnswer instance.</returns>
        public static DalAnswer ToDalAnswer(this BllAnswer answer)
        {
            return new DalAnswer()
            {
                Id = answer.Id,
                QuestionId = answer.QuestionId,
                AnswerText = answer.AnswerText,
                IsCorrect = answer.IsCorrect
            };
        }

        /// <summary>
        /// Maps BllTestResult entity to  DalTestResult entity.
        /// </summary>
        /// <param name="testResult"> BllTestResult instance.</param>
        /// <returns> DalTestResult instance.</returns>
        public static DalTestResult ToDalTestResult(this BllTestResult testResult)
        {
            return new DalTestResult()
            {
                Id = testResult.Id,
                Grade = testResult.Grade,
                DateTime = testResult.DateTime,
                TimeSpent = testResult.TimeSpent,
                Test = testResult?.Test.ToDalTest(),
                User =  (new BllUser { Id = testResult.UserId }).ToDalUser()
            };
        }
        #endregion
    }
}
