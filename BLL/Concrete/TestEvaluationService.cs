using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Provides functionality for evaluating tests.
    /// </summary>
    public class TestEvaluationService : ITestEvaluationService
    {
        #region Fields
        private Service service;
        private ITestResultRepository repository;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates TestEvaluationService with specified parameters.
        /// </summary>
        /// <param name="repository"> TestResultRepository instance.</param>
        /// <param name="uow"> UnitOfWork instance.</param>
        /// <exception> System.ArgumentNullException if service is null.</exception>
        public TestEvaluationService(ITestResultRepository repository, IUnitOfWork uow)
        {
            if (repository == null || uow == null) throw new ArgumentNullException(repository == null ? nameof(repository) : nameof(uow));
            this.repository = repository;
            service = new Service(uow);
        }
        #endregion

        #region ITestEvaluationService Methods
        /// <summary>
        /// Evaluates test completed by user.
        /// </summary>
        /// <param name="completedTest"> Test completed by user.</param>
        /// <returns> TestResult instance.</returns>
        /// <exception> System.ArgumentNullException if completedTest is null.</exception>
        public BllTestResult EvaluateTest(BllCompletedTest completedTest)
        {
            if (completedTest == null) throw new ArgumentNullException(nameof(completedTest));
            int numberOfCorrectAnswers = 0;

            foreach (var question in completedTest.Test.Questions)
            {
                if (completedTest.ChoosenAnswers.Intersect(question.CorrectAnswers).Count() == question.CorrectAnswers.Count) numberOfCorrectAnswers++;
            }

            var testResult = new BllTestResult
            {
                DateTime = DateTime.Now,
                Grade = GradeTest(numberOfCorrectAnswers, completedTest.Test.Questions.Count),
                TimeSpent = completedTest.TimeSpent,
                UserId = completedTest.UserId,
                Test = completedTest.Test
            };
            repository.Create(testResult.ToDalTestResult());
            service.Save();
            return testResult;
        }
        #endregion

        #region Private Methods
        private double GradeTest(int correctAnswers, int questions) => (correctAnswers * 100) / (double)questions;
        #endregion
    }
}
