using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Represents User functionality.
    /// </summary>
    public class RoleService : IRoleService
    {
        #region Fields
        private Service service;
        private IRoleRepository repository;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates RoleService with specified parameters.
        /// </summary>
        /// <param name="uow"> UnitOwWork instance.</param>
        /// <param name="repository"> Repository instance.</param>
        /// <exception> System.ArgumentNullException if uow or repository is null.</exception>
        public RoleService(IUnitOfWork uow, IRoleRepository repository)
        {
            if (uow == null || repository == null) throw new ArgumentNullException(uow == null ? nameof(uow) : nameof(repository));
            service = new Service(uow);
            this.repository = repository;
        }
        #endregion

        #region IRoleService Methods
        /// <summary>
        /// Creates new Role.
        /// </summary>
        /// <param name="role"> Role to create.</param>
        public void CreateRole(BllRole role)
        {
            if (role == null) throw new ArgumentNullException(nameof(role));
            if (repository.GetByPredicate(r => r.Name == role.Name).Count() > 0) throw new RoleAlreadyExistsException(nameof(role));
            repository.Create(role.ToDalRole());
            service.Save();
        }

        /// <summary>
        /// Gets all Roles.
        /// </summary>
        /// <returns> IEnumerable`1 of roles.</returns>
        public IEnumerable<BllRole> GetAllRoles()
        {
            return repository.GetAll().Select(u => u.ToBllRole());
        }

        /// <summary>
        /// Gets Role by Id.
        /// </summary>
        /// <param name="id"> Role identificator.</param>
        /// <returns> Role.</returns>
        /// <exception> ServiceAccesException if service is inaccessible.</exception>
        public BllRole GetRole(int id)
        {
            return Service.GetById(repository.GetById, id)?.ToBllRole();
        }

        /// <summary>
        /// Gets Role by name.
        /// </summary>
        /// <param name="name"> Role name.</param>
        /// <returns> Role.</returns>
        public BllRole GetRoleByName(string name)
        {
            return repository.GetByPredicate(r => r.Name.Equals(name)).FirstOrDefault().ToBllRole();
        }
        #endregion
    }
}
