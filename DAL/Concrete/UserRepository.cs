using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ORM;
using System.Linq.Expressions;
using DAL.Mappers;
using DAL.Interfaces;
using DAL.DTO;

namespace DAL.Concrete
{
    /// <summary>
    /// Represents user repository.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        #region Fields
        private readonly Repository<User> repository;
        private readonly DbContext context;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates Repository with specified parameters.
        /// </summary>
        /// <param name="context"> Data base context.</param>
        /// <exception> System.ArgumentNullException if context is null.</exception>
        public UserRepository(DbContext context)
        {
            repository = new Repository<User>(context);
            this.context = context;
        }
        #endregion

        #region IRepository Methods
        /// <summary>
        /// Adds new user to data storage.
        /// </summary>
        /// <param name="user"> User to add.</param>
        /// <exception> System.ArgumentNullException if user is null.</exception>
        public void Create(DalUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            var ormUser = user.ToUser();
            var dbRoles = context.Set<Role>();
            var userRoles = new List<Role>();
            foreach (var role in ormUser.Roles)
            {
                var dbRole = dbRoles.SingleOrDefault(r => r.Name == role.Name);
                userRoles.Add(dbRole == null ? role : dbRole);
            }
            ormUser.Roles = userRoles;
            context.Set<User>().Add(ormUser);
        }

        /// <summary>
        /// Removes user from data storage.
        /// </summary>
        /// <param name="user"> User to remove.</param>
        /// <exception> System.ArgumentNullException if user is null.</exception>
        public void Delete(DalUser user) => repository.Delete(user?.ToUser());

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns> IEnumerable`1 of users.</returns>
        public IEnumerable<DalUser> GetAll() => repository.GetAll().Select(u => u.ToDalUser());

        /// <summary>
        /// Gets a single user with given id.
        /// </summary>
        /// <param name="key"> User id.</param>
        /// <returns> User with given id.</returns>
        public DalUser GetById(int key) => repository.GetById(key)?.ToDalUser();

        /// <summary>
        /// Gets all users that satisfy the predicate.
        /// </summary>
        /// <param name="filter"> Predicate by wich users must be filtered.</param>
        /// <returns> IEnumerable`1 of users.</returns>
        public IEnumerable<DalUser> GetByPredicate(Expression<Func<DalUser, bool>> filter) => repository.GetByPredicate(filter?.Convert<DalUser, User>()).Select(u => u.ToDalUser());

        /// <summary>
        /// Updates user in data storage.
        /// </summary>
        /// <param name="user"> User to update.</param>
        /// <exception> System.ArgumentNullException if user is null.</exception>
        public void Update(DalUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            var dbUser = context.Set<User>().Find(user.Id);
            var userRoles = dbUser.Roles.ToList();

            context.Entry(dbUser).CurrentValues.SetValues(user);

            foreach (var userRole in userRoles)
            {
                var role = user.Roles?.SingleOrDefault(r => r.Id == userRole.Id);
                if (role != null)
                    context.Entry(userRole).CurrentValues.SetValues(role);
                else
                    dbUser.Roles.Remove(userRole);
            }

            var roles = context.Set<Role>();

            foreach (var role in user.Roles)
            {
                if (!userRoles.Any(r => r.Id == role.Id))
                    dbUser.Roles.Add(roles.SingleOrDefault(r => r.Id == role.Id) ?? role.ToRole());
            }
        }

        /// <summary>
        /// Free up unmanaged resources.
        /// </summary>
        public void Dispose() => repository.Dispose();
        #endregion
    }
}
