using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using BLL;
using Logger;
using BLL.Interfaces;
using BLL.DTO;

namespace MvcPL.Infrastructure.Authentication
{
    /// <summary>
    /// Defines the contract to provide role-management services using custom role providers.
    /// </summary>
    public class CustomRoleProvider : RoleProvider
    {
        #region Fields
        private IUserService userService = (IUserService)DependencyResolver.Current.GetService(typeof(IUserService));
        private IRoleService roleService = (IRoleService)DependencyResolver.Current.GetService(typeof(IRoleService));
        private readonly ILogger logger = LogManager.GetLogger();
        #endregion

        #region RoleProvider Methods
        /// <summary>
        /// Gets a value indicating whether the specified user is in the specified role for
        /// the configured applicationName.
        /// </summary>
        /// <param name="email"> User email.</param>
        /// <param name="roleName"> Role name.</param>
        /// <returns> True if the specified user is in the specified role; otherwise, false.</returns>
        public override bool IsUserInRole(string email, string roleName)
        {
            BllUser user = userService.GetUserByEmail(email);
            if (user == null) return false;
            return user.Roles.Where(r => r.Name.Equals(roleName)).Count() != 0 ? true : false;
        }

        /// <summary>
        /// Gets a list of the roles that a specified user is in.
        /// </summary>
        /// <param name="email"> user email.</param>
        /// <returns> A string array containing the names of all the roles that the specified user
        /// is in</returns>
        public override string[] GetRolesForUser(string email)
        {
            var user = userService.GetUserByEmail(email);
            return user == null ? new string[] { } : user.Roles.Select(r => r.Name).ToArray();
        }

        /// <summary>
        /// Adds a new role to the data source.
        /// </summary>
        /// <param name="roleName"> Role name.</param>
        public override void CreateRole(string roleName)
        {
            try
            {
                roleService.CreateRole(new BllRole { Name = roleName });
            }
            catch (RoleAlreadyExistsException ex)
            {
                logger.Error("Role already exists.", ex);
                throw;
            }
        }
        #endregion

        #region Not Implemented Methods
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
        #endregion
    }
}