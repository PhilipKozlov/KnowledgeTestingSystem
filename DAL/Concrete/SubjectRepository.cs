using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Mappers;
using DAL.Interfaces;
using DAL.DTO;

namespace DAL.Concrete
{
    /// <summary>
    /// Represents subject repository.
    /// </summary>
    public class SubjectRepository : ISubjectRepository
    {
        #region Fields
        private readonly Repository<Subject> repository;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates Repository with specified parameters.
        /// </summary>
        /// <param name="context"> Data base context.</param>
        /// <exception> System.ArgumentNullException if context is null.</exception>
        public SubjectRepository(DbContext context)
        {
            repository = new Repository<Subject>(context);
        }
        #endregion

        #region IRepository Methods
        /// <summary>
        /// Adds new subject to data storage.
        /// </summary>
        /// <param name="subject"> Subject to add.</param>
        /// <exception> System.ArgumentNullException if subject is null.</exception>
        public void Create(DalSubject subject) => repository.Create(subject?.ToSubject());

        /// <summary>
        /// Gets all subjects.
        /// </summary>
        /// <returns> IEnumerable`1 of subjects.</returns>
        public IEnumerable<DalSubject> GetAll() => repository.GetAll().Select(u => u.ToDalSubject());

        /// <summary>
        /// Gets a single subject with given id.
        /// </summary>
        /// <param name="key"> Subject id.</param>
        /// <returns> Subject with given id.</returns>
        public DalSubject GetById(int key) => repository.GetById(key)?.ToDalSubject();

        /// <summary>
        /// Gets all subjects that satisfy the predicate.
        /// </summary>
        /// <param name="filter"> Predicate by wich subjects must be filtered.</param>
        /// <returns> IEnumerable`1 of subjects.</returns>
        public IEnumerable<DalSubject> GetByPredicate(Expression<Func<DalSubject, bool>> filter) => repository.GetByPredicate(filter?.Convert<DalSubject, Subject>()).Select(u => u.ToDalSubject());

        /// <summary>
        /// Free up unmanaged resources.
        /// </summary>
        public void Dispose() => repository.Dispose();
        #endregion
    }
}
