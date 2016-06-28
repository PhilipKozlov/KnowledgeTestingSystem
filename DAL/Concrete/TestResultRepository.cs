using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DAL
{
    /// <summary>
    /// Represents test result repository.
    /// </summary>
    public class TestResultRepository : ITestResultRepository
    {
        #region Fields
        private Repository<TestResult> repository;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates Repository with specified parameters.
        /// </summary>
        /// <param name="context"> Data base context.</param>
        /// <exception> System.ArgumentNullException if context is null.</exception>
        public TestResultRepository(DbContext context)
        {
            repository = new Repository<TestResult>(context);
        }
        #endregion

        #region IRepository Methods
        /// <summary>
        /// Adds new test result to data storage.
        /// </summary>
        /// <param name="testResult"> TestResult to add.</param>
        /// <exception> System.ArgumentNullException if test result is null.</exception>
        public void Create(DalTestResult testResult) => repository.Create(testResult?.ToTestResult());

        /// <summary>
        /// Gets all test results.
        /// </summary>
        /// <returns> IEnumerable`1 of test result.</returns>
        public IEnumerable<DalTestResult> GetAll() => repository.GetAll().Select(u => u.ToDalTestResult());

        /// <summary>
        /// Gets a single test result with given id.
        /// </summary>
        /// <param name="key"> TestResult id.</param>
        /// <returns> TestResult with given id.</returns>
        public DalTestResult GetById(int key) => repository.GetById(key)?.ToDalTestResult();

        /// <summary>
        /// Gets all test results that satisfy the predicate.
        /// </summary>
        /// <param name="filter"> Predicate by wich test results must be filtered.</param>
        /// <returns> IEnumerable`1 of test results.</returns>
        public IEnumerable<DalTestResult> GetByPredicate(Expression<Func<DalTestResult, bool>> filter) => repository.GetByPredicate(filter?.Convert<DalTestResult, TestResult>()).Select(u => u.ToDalTestResult());
        

        /// <summary>
        /// Free up unmanaged resources.
        /// </summary>
        public void Dispose() => repository.Dispose();
        #endregion
    }
}
