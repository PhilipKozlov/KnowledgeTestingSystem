using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace DAL
{
    /// <summary>
    /// Represents User repository functionality.
    /// </summary>
    public interface IUserRepository : IRepository<DalUser>
    {
        /// <summary>
        /// Adds new user to data storage.
        /// </summary>
        /// <param name="user"> User to add.</param>
        void Create(DalUser user);
        /// <summary>
        /// Removes an user from data storage.
        /// </summary>
        /// <param name="user"> User to remove.</param>
        void Delete(DalUser user);
        /// <summary>
        /// Updates user in data storage.
        /// </summary>
        /// <param name="user"> User to update.</param>
        void Update(DalUser user);
    }
}
