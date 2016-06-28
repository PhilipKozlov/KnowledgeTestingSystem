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
    /// Represents Subject functionality.
    /// </summary>
    public class SubjectService  : ISubjectService
    {
        #region Fields
        private readonly ISubjectRepository repository;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates SubjectService with specified parameters.
        /// </summary>
        /// <param name="repository"> Repository instance.</param>
        /// <exception> System.ArgumentNullException if uow or repository is null.</exception>
        public SubjectService(ISubjectRepository repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            this.repository = repository;
        }
        #endregion

        #region ISubjectService Methods
        /// <summary>
        /// Gets all Subjects.
        /// </summary>
        /// <returns> IEnumerable`1 of subjects.</returns>
        public IEnumerable<BllSubject> GetAllSubjects()
        {
            return repository.GetAll().Select(u => u.ToBllSubject());
        }

        /// <summary>
        /// Gets Subject by Id.
        /// </summary>
        /// <param name="id"> Subject identificator.</param>
        /// <returns> Subject.</returns>
        /// <exception> ServiceAccesException if service is inaccessible.</exception>
        public BllSubject GetSubject(int id)
        {
            return Service.GetById(repository.GetById, id)?.ToBllSubject();
        }
        #endregion
    }
}
