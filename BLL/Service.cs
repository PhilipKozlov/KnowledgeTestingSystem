using DAL;
using System;
using DAL.Interfaces;

namespace BLL
{
    /// <summary>
    /// Represents common functionality for saving data changes.
    /// </summary>
    internal class Service
    {
        #region Fields
        private readonly IUnitOfWork uow;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates Service with specified parameters.
        /// </summary>
        /// <param name="uow"> UnitOwWork instance.</param>
        public Service(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Saves changes to data storage.
        /// </summary>
        public void Save()
        {
            try
            {
                uow.Commit();
            }
            catch (DataAccessException ex)
            {
                uow.Rollback();
                var serviceAccess = new ServiceAccessException("Required data is inaccessible.", ex);
                throw serviceAccess;
            }
        }

        /// <summary>
        /// Gets single entity with specified parameters.
        /// </summary>
        /// <typeparam name="T"> Entity type.</typeparam>
        /// <param name="method"> Method of retrieving the entity.</param>
        /// <param name="id"> Entitny identificator.</param>
        /// <returns> Entity of type T.</returns>
        public static T GetById<T>(Func<int, T> method, int id)
        {
            T entity = default(T);
            try
            {
                entity = method(id);
            }
            catch (DataAccessException ex)
            {
                var serviceAccess = new ServiceAccessException("Required data is inaccessible.", ex);
                throw serviceAccess;
            }
            return entity;
        }
        #endregion
    }
}
