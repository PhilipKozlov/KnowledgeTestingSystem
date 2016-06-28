using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using Logger;

namespace DAL
{
    /// <summary>
    /// Represents common repository for all entities.
    /// </summary>
    /// <typeparam name="TEntity"> Entity type.</typeparam>
    internal class Repository<TEntity> where TEntity : class
    {
        #region Fields
        private readonly DbContext context;
        private readonly DbSet<TEntity> dbSet;
        private readonly ILogger logger = LogManager.GetLogger();
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates Repository with specified parameters.
        /// </summary>
        /// <param name="context"> Database context.</param>
        public Repository(DbContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            this.context = context;
            dbSet = context.Set<TEntity>();
        }
        #endregion

        #region IRepository Methods
        /// <summary>
        /// Adds new entity to data storage.
        /// </summary>
        /// <param name="entity"> Entity to add.</param>
        public void Create(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            dbSet.Add(entity);
        }
        /// <summary>
        /// Removes an entity from data storage.
        /// </summary>
        /// <param name="entity"> Entity to remove.</param>
        public void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns> IEnumerable`1 of entities.</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }
        /// <summary>
        /// Gets as single entity with given id.
        /// </summary>
        /// <param name="key"> Entity id.</param>
        /// <returns> Entity with given id.</returns>
        public TEntity GetById(int key)
        {
            TEntity entity = null;
            try
            {
                entity = dbSet.Find(key);
            }
            catch(InvalidOperationException ex)
            {
                logger.Error(ex);
                var dataAccess = new DataAccessException("Invalid key, or context has been disposed", ex);
                throw dataAccess;
            }
            return entity;
        }
        /// <summary>
        /// Gets all entities that satisfy the predicate.
        /// </summary>
        /// <param name="filter"> Predicate by wich entities must be filtered.</param>
        /// <returns> IEnumerable`1 of entities.</returns>
        public IEnumerable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> filter)
        {
            return filter == null ? GetAll() : dbSet.Where(filter);
        }
        #endregion

        #region IDisposable
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() => context.Dispose();
        #endregion
    }
}
