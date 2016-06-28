using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Represents Role repository functionality.
    /// </summary>
    public interface IRoleRepository : IRepository<DalRole>
    {
        /// <summary>
        /// Adds new role to data storage.
        /// </summary>
        /// <param name="role"> Role to add.</param>
        void Create(DalRole role);
    }
}
