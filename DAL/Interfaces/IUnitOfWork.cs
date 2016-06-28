using System;

namespace DAL.Interfaces
{
    /// <summary>
    /// Represents Unit of Work pattern functionality.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits transaction.
        /// </summary>
        void Commit();
        /// <summary>
        /// Rollbacks transaction.
        /// </summary>
        void Rollback();
    }
}
