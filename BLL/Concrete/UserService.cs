using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Linq.Expressions;

namespace BLL
{
    /// <summary>
    /// Represents User functionality.
    /// </summary>
    public class UserService : IUserService
    {
        #region Fields
        private Service service;
        private IUserRepository repository;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates UserService with specified parameters.
        /// </summary>
        /// <param name="uow"> UnitOwWork instance.</param>
        /// <param name="repository"> Repository instance.</param>
        /// <exception> System.ArgumentNullException if uow or repository is null.</exception>
        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            if (uow == null || repository == null) throw new ArgumentNullException(uow == null ? nameof(uow) : nameof(repository));
            service = new Service(uow);
            this.repository = repository;
        }
        #endregion

        #region IUserService Methods
        /// <summary>
        /// Creates new User.
        /// </summary>
        /// <param name="user"> User to create.</param>
        /// <exception> UserEmailAlreadyExistsException if user with specified email already exists.</exception>
        public void CreateUser(BllUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            var existingUser = repository.GetByPredicate(u => u.Email == user.Email).SingleOrDefault();
            if (existingUser != null) throw new UserEmailAlreadyExistsException(user.Email);
            repository.Create(user.ToDalUser());
            service.Save();
        }

        /// <summary>
        /// Remove existing User.
        /// </summary>
        /// <param name="user"> User to remove.</param>
        public void DeleteUser(BllUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            repository.Delete(user.ToDalUser());
            service.Save();
        }

        /// <summary>
        /// Gets all Users.
        /// </summary>
        /// <returns> IEnumerable`1 of users.</returns>
        public IEnumerable<BllUser> GetAllUsers()
        {
            return repository.GetAll().Select(u => u.ToBllUser());
        }

        /// <summary>
        /// Gets User by Id.
        /// </summary>
        /// <param name="id"> User identificator.</param>
        /// <returns> User.</returns>
        /// <exception> ServiceAccesException if service is inaccessible.</exception>
        public BllUser GetUser(int id)
        {
            return Service.GetById(repository.GetById, id)?.ToBllUser();
        }

        /// <summary>
        /// Updates User.
        /// </summary>
        /// <param name="user"> User to update.</param>
        /// <exception> UserEmailAlreadyExistsException if user with specified email already exists.</exception>
        public void UpdateUser(BllUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            var existingUser = repository.GetByPredicate(u => u.Email == user.Email && u.Id == user.Id);
            if (existingUser == null) throw new UserEmailAlreadyExistsException(user.Email);
            repository.Update(user.ToDalUser());
            service.Save();
        }

        /// <summary>
        /// Gets user with specified email.
        /// </summary>
        /// <param name="email"> User email address.</param>
        /// <returns> User with given email.</returns>
        public BllUser GetUserByEmail(string email)
        {
            if (email == null) throw new ArgumentNullException(nameof(email));
            return repository.GetByPredicate(u => u.Email == email).SingleOrDefault()?.ToBllUser();
        }
        #endregion
    }
}
