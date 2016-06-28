using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    /// <summary>
    /// Represents Role functionality.
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// Gets as single role with given id.
        /// </summary>
        /// <param name="id"> Role id.</param>
        /// <returns> Role with given id.</returns>
        BllRole GetRole(int id);
        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns> IEnumerable`1 of roles.</returns>
        IEnumerable<BllRole> GetAllRoles();
        /// <summary>
        /// Adds new role to data storage.
        /// </summary>
        /// <param name="role"> Role to add.</param>
        void CreateRole(BllRole role);

        /// <summary>
        /// Gets Role by name.
        /// </summary>
        /// <param name="name"> Role name.</param>
        /// <returns> Role.</returns>
        BllRole GetRoleByName(string name);
    }
}
