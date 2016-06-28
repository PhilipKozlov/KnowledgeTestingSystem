using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
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
