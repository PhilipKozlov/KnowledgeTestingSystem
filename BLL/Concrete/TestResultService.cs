using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using BLL.Mappers;
using BLL.Interfaces;
using BLL.DTO;

namespace BLL.Concrete
{
    /// <summary>
    /// Represents TestResult functionality.
    /// </summary>
    public class TestResultService : ITestResultService
    {
        #region Fields
        private readonly ITestResultRepository repository;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates TestResultService with specified parameters.
        /// </summary>
        /// <param name="repository"> Repository instance.</param>
        /// <exception> System.ArgumentNullException if uow or repository is null.</exception>
        public TestResultService(ITestResultRepository repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            this.repository = repository;
        }
        #endregion

        #region ITestResultService Methods
        /// <summary>
        /// Gets all TestResults.
        /// </summary>
        /// <returns> IEnumerable`1 of test results.</returns>
        public IEnumerable<BllTestResult> GetAllTestResults()
        {
            return repository.GetAll().Select(u => u.ToBllTestResult());
        }

        /// <summary>
        /// Gets TestResult by Id.
        /// </summary>
        /// <param name="id"> TestResult identificator.</param>
        /// <returns> TestResult.</returns>
        /// <exception> ServiceAccesException if service is inaccessible.</exception>
        public BllTestResult GetTestResult(int id)
        {
            return Service.GetById(repository.GetById, id)?.ToBllTestResult();
        }

        /// <summary>
        /// Gets test results for specified test.
        /// </summary>
        /// <param name="test"> Test instance.</param>
        /// <returns> IEnumerable` of test results.</returns>
        /// <exception> System.ArgumentNullException if test is null.</exception>
        public IEnumerable<BllTestResult> GetTestResultsByTest(BllTest test)
        {
            if (test == null) throw new ArgumentNullException(nameof(test));
            return repository.GetByPredicate(tr => tr.Test.Id == test.Id).Select(tr => tr.ToBllTestResult());
        }

        /// <summary>
        /// Gets test results for specified user.
        /// </summary>
        /// <param name="userName"> User name.</param>
        /// <returns> IEnumerable` of test results.</returns>
        /// <exception> System.ArgumentNullException if user is null.</exception>
        public IEnumerable<BllTestResult> GetTestResultsByUser(string userName)
        {
            if (userName == null) throw new ArgumentNullException(nameof(userName));
            return repository.GetByPredicate(tr => tr.User.Email == userName).Select(tr => tr.ToBllTestResult());
        }
        #endregion
    }
}
