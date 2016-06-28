using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Represents Test functionality.
    /// </summary>
    public class TestService : ITestService
    {
        #region Fields
        private Service service;
        private ITestRepository repository;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates TestService with specified parameters.
        /// </summary>
        /// <param name="uow"> UnitOwWork instance.</param>
        /// <param name="repository"> Repository instance.</param>
        /// <exception> System.ArgumentNullException if uow or repository is null.</exception>
        public TestService(IUnitOfWork uow, ITestRepository repository)
        {
            if (uow == null || repository == null) throw new ArgumentNullException(uow == null ? nameof(uow) : nameof(repository));
            service = new Service(uow);
            this.repository = repository;
        }
        #endregion

        #region ITestService Methods
        /// <summary>
        /// Creates new Test.
        /// </summary>
        /// <param name="test"> Test to create.</param>
        public void CreateTest(BllTest test)
        {
            if (test == null) throw new ArgumentNullException(nameof(test));
            repository.Create(test.ToDalTest());
            service.Save();
        }

        /// <summary>
        /// Remove existing Test.
        /// </summary>
        /// <param name="test"> Test to remove.</param>
        public void DeleteTest(BllTest test)
        {
            if (test == null) throw new ArgumentNullException(nameof(test));
            repository.Delete(test.ToDalTest());
            service.Save();
        }

        /// <summary>
        /// Gets all Tests.
        /// </summary>
        /// <returns> IEnumerable`1 of tests.</returns>
        public IEnumerable<BllTest> GetAllTests()
        {
            return repository.GetAll().Select(u => u.ToBllTest());
        }

        /// <summary>
        /// Gets Test by Id.
        /// </summary>
        /// <param name="id"> Test identificator.</param>
        /// <returns> Test.</returns>
        /// <exception> ServiceAccesException if service is inaccessible.</exception>
        public BllTest GetTest(int id)
        {
            return Service.GetById(repository.GetById, id)?.ToBllTest();
        }

        /// <summary>
        /// Updates Test.
        /// </summary>
        /// <param name="test"> Test to update.</param>
        public void UpdateTest(BllTest test)
        {
            if (test == null) throw new ArgumentNullException(nameof(test));
            repository.Update(test.ToDalTest());
            service.Save();
        }

        /// <summary>
        /// Gets tests for specified subject.
        /// </summary>
        /// <param name="subject"> Subject instance.</param>
        /// <returns> Tests created by specified subject.</returns>
        public IEnumerable<BllTest> GetTestsBySubject(BllSubject subject)
        {
            if (subject == null) throw new ArgumentNullException(nameof(subject));
            return repository.GetByPredicate(t => t.Subject.Id == subject.Id).Select(t => t.ToBllTest());
        }

        /// <summary>
        /// Gets tests for specified user.
        /// </summary>
        /// <param name="user"> User instance.</param>
        /// <returns> Tests created by specified user.</returns>
        /// <exception> System.ArgumentNullException if user is null.</exception>
        public IEnumerable<BllTest> GetTestsByUser(BllUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            return repository.GetByPredicate(t => t.User.Id == user.Id).Select(t => t.ToBllTest());
        }

        /// <summary>
        /// Gets tests that hae specified name.
        /// </summary>
        /// <param name="name"> Test name.</param>
        /// <returns> Tests with specified name.</returns>
        /// <exception> System.ArgumentNullException if name is null.</exception>
        public IEnumerable<BllTest> GetTestsByName(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            return repository.GetByPredicate(t => t.Name.ToLower().Contains(name.ToLower())).Select(t => t.ToBllTest());
        }
        #endregion
    }
}
