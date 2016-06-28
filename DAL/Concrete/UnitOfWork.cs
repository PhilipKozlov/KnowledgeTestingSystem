using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using Logger;
using DAL.Interfaces;

namespace DAL.Concrete
{
    /// <summary>
    /// Represents Unit of Work pattern.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly DbContext context;
        private readonly ILogger logger = LogManager.GetLogger();
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates UnitOfWork with specified parameters.
        /// </summary>
        /// <param name="context"> Data base context.</param>
        /// <exception> System.ArgumentNullException if context is null.</exception>
        public UnitOfWork(DbContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            this.context = context;
        }
        #endregion

        #region IUnitOfWork Methods
        /// <summary>
        /// Commits transaction.
        /// </summary>
        public void Commit()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                logger.Error(ex);
                var dataAccess = new DataAccessException("Entity validation has failed.", ex);
                throw dataAccess;
            }
            catch (DbUpdateException ex)
            {
                logger.Error(ex);
                var dataAccess = new DataAccessException("Entity update has failed.", ex);
                throw dataAccess;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                var dataAccess = new DataAccessException("Required data is inaccessible.", ex);
                throw dataAccess;
            }
        }
        /// <summary>
        /// Rollbacks transaction.
        /// </summary>
        public void Rollback()
        {
            context.ChangeTracker.Entries().ToList().ForEach(x => x.State = EntityState.Detached);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() => context?.Dispose();
        #endregion
    }
}
