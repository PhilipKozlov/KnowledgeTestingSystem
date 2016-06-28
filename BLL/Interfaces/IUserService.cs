using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    /// <summary>
    /// Represents User functionality.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets as single user with given id.
        /// </summary>
        /// <param name="id"> User id.</param>
        /// <returns> User with given id.</returns>
        BllUser GetUser(int id);
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns> IEnumerable`1 of users.</returns>
        IEnumerable<BllUser> GetAllUsers();
        /// <summary>
        /// Adds new user to data storage.
        /// </summary>
        /// <param name="user"> User to add.</param>
        void CreateUser(BllUser user);
        /// <summary>
        /// Removes user from data storage.
        /// </summary>
        /// <param name="user"> User to remove.</param>
        void DeleteUser(BllUser user);
        /// <summary>
        /// Updates user in data storage.
        /// </summary>
        /// <param name="user"> User to update.</param>
        void UpdateUser(BllUser user);

        /// <summary>
        /// Gets user with specified email.
        /// </summary>
        /// <param name="email"> User emaikl address.</param>
        /// <returns> User with given email.</returns>
        BllUser GetUserByEmail(string email);
    }
}
