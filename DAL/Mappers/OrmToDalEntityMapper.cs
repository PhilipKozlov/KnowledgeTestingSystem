using System.Linq;
using ORM;
using DAL.DTO;

namespace DAL.Mappers
{
    /// <summary>
    /// Maps ORM entities to DAL entities.
    /// </summary>
    internal static class OrmToDalEntityMapper
    {
        #region Extension Methods
        /// <summary>
        /// Maps User entity to  DalUser entity.
        /// </summary>
        /// <param name="user"> User instance.</param>
        /// <returns> DalUser instance.</returns>
        public static DalUser ToDalUser(this User user)
        {
            return new DalUser()
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Roles = user.Roles.Select(r => r.ToDalRole()).ToList()
            };
        }

        /// <summary>
        /// Maps Role entity to  DalRole entity.
        /// </summary>
        /// <param name="role"> Role instance.</param>
        /// <returns> DalRole instance.</returns>
        public static DalRole ToDalRole(this Role role)
        {
            return new DalRole()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
            };
        }

        /// <summary>
        /// Maps Subject entity to  DalSubject entity.
        /// </summary>
        /// <param name="subject"> Subject instance.</param>
        /// <returns> DalSubject instance.</returns>
        public static DalSubject ToDalSubject(this Subject subject)
        {
            return new DalSubject()
            {
                Id = subject.Id,
                Name = subject.Name
            };
        }

        /// <summary>
        /// Maps Test entity to  DalTest entity.
        /// </summary>
        /// <param name="test"> Test instance.</param>
        /// <returns> DalTest instance.</returns>
        public static DalTest ToDalTest(this Test test)
        {
            return new DalTest()
            {
                Id = test.Id,
                Name = test.Name,
                Created = test.Created,
                IsTimed = test.IsTimed,
                TimeToComplete = test.TimeToComplete,
                User = test.User?.ToDalUser(),
                Subject = test.Subject?.ToDalSubject(),
                Questions = test.Questions.Select(q => q.ToDalQuestion()).ToList()
            };
        }

        /// <summary>
        /// Maps Question entity to  DalQuestion entity.
        /// </summary>
        /// <param name="question"> Question instance.</param>
        /// <returns> DalQuestion instance.</returns>
        public static DalQuestion ToDalQuestion(this Question question)
        {
            return new DalQuestion()
            {
                Id = question.Id,
                TestId = question.TestId,
                QuestionText = question.QuestionText,
                Answers = question.Answers.Select(a => a.ToDalAnswer()).ToList()
            };
        }

        /// <summary>
        /// Maps Answer entity to  DalAnswer entity.
        /// </summary>
        /// <param name="answer"> Answer instance.</param>
        /// <returns> DalAnswer instance.</returns>
        public static DalAnswer ToDalAnswer(this Answer answer)
        {
            return new DalAnswer()
            {
                Id = answer.Id,
                QuestionId = answer.QuestionId,
                AnswerText = answer.AnswerText,
                IsCorrect = answer.IsCorrect,
            };
        }

        /// <summary>
        /// Maps TestResult entity to  DalTestResult entity.
        /// </summary>
        /// <param name="testResult"> TestResult instance.</param>
        /// <returns> DalTestResult instance.</returns>
        public static DalTestResult ToDalTestResult(this TestResult testResult)
        {
            return new DalTestResult()
            {
                Id = testResult.Id,
                Grade = testResult.Grade,
                DateTime = testResult.DateTime,
                TimeSpent = testResult.TimeSpent,
                Test = testResult.Test?.ToDalTest(),
                User = testResult.User.ToDalUser()
            };
        }
        #endregion
    }
}
