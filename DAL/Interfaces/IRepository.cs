using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Interfaces
{
    /// <summary>
    /// Represents common functionality for all repositories.
    /// </summary>
    public interface IRepository<TEntity> : IDisposable where TEntity : IEntity
    {
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns> IEnumerable`1 of entities.</returns>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Gets as single entity with given id.
        /// </summary>
        /// <param name="id"> Entity id.</param>
        /// <returns> Entity with given id.</returns>
        TEntity GetById(int id);
        /// <summary>
        /// Gets all entities that satisfy the predicate.
        /// </summary>
        /// <param name="filter"> Predicate by wich entities must be filtered.</param>
        /// <returns> IEnumerable`1 of entities.</returns>
        IEnumerable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> filter);
    }
}
