using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DAL
{
    /// <summary>
    /// Represents role repository.
    /// </summary>
    public class RoleRepository : IRoleRepository
    {
        #region Fields
        private Repository<Role> repository;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates Repository with specified parameters.
        /// </summary>
        /// <param name="context"> Data base context.</param>
        /// <exception> System.ArgumentNullException if context is null.</exception>
        public RoleRepository(DbContext context)
        {
            repository = new Repository<Role>(context);
        }
        #endregion

        #region IRepository Methods
        /// <summary>
        /// Adds new role to data storage.
        /// </summary>
        /// <param name="role"> Role to add.</param>
        /// <exception> System.ArgumentNullException if role is null.</exception>
        public void Create(DalRole role) => repository.Create(role?.ToRole());

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns> IEnumerable`1 of role.</returns>
        public IEnumerable<DalRole> GetAll() => repository.GetAll().Select(u => u.ToDalRole());

        /// <summary>
        /// Gets a single role with given id.
        /// </summary>
        /// <param name="key"> Role id.</param>
        /// <returns> Role with given id.</returns>
        public DalRole GetById(int key) => repository.GetById(key)?.ToDalRole();

        /// <summary>
        /// Gets all roles that satisfy the predicate.
        /// </summary>
        /// <param name="filter"> Predicate by wich roles must be filtered.</param>
        /// <returns> IEnumerable`1 of roles.</returns>
        public IEnumerable<DalRole> GetByPredicate(Expression<Func<DalRole, bool>> filter) => repository.GetByPredicate(filter?.Convert<DalRole, Role>()).Select(u => u.ToDalRole());

        /// <summary>
        /// Free up unmanaged resources.
        /// </summary>
        public void Dispose() => repository.Dispose();
        #endregion
    }
}
