using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using BLL;
using System.Collections.Generic;

namespace MvcPL
{
    /// <summary>
    /// Defines the contract to provide custom membership services.
    /// </summary>
    public class CustomMembershipProvider : MembershipProvider
    {
        #region Fields
        private IUserService userService = (IUserService)DependencyResolver.Current.GetService(typeof(IUserService));
        private IRoleService roleService = (IRoleService)DependencyResolver.Current.GetService(typeof(IRoleService));
        #endregion

        #region Public Methods
        /// <summary>
        /// Creates new user with specified parameters.
        /// </summary>
        /// <param name="name"> User name.</param>
        /// <param name="lastName"> User Last Name.</param>
        /// <param name="email"> User email.</param>
        /// <param name="password"> User password.</param>
        /// <returns> Membershipuser instance.</returns>
        /// <exception> BLL.UserEmailAlreadyExistsException if user with specified email already exists.</exception>
        public MembershipUser CreateUser(string name, string lastName, string email, string password)
        {
            var user = new BllUser
            {
                Name = name,
                LastName = lastName,
                Email = email,
                Password = Crypto.HashPassword(password),
                Roles = new List<BllRole>()
            };
            user.Roles.Add(new BllRole { Name = "User" });
            userService.CreateUser(user);
            return GetUser(email, false);
        }

        /// <summary>
        /// Validates user.
        /// </summary>
        /// <param name="email"> User email.</param>
        /// <param name="password"> User password.</param>
        /// <returns> True if user has been validated successfully; otherwise - false.</returns>
        public override bool ValidateUser(string email, string password)
        {
            var user = userService.GetUserByEmail(email);
            return user != null && Crypto.VerifyHashedPassword(user.Password, password) ? true : false;
        }

        /// <summary>
        /// Gets user by email.
        /// </summary>
        /// <param name="email"> User email.</param>
        /// <param name="userIsOnline"> True to update the last-activity date/time stamp for the user; false to return
        /// user information without updating the last-activity date/time stamp for the user.</param>
        /// <returns> MembershipUser instance or null if user was not found.</returns>
        public override MembershipUser GetUser(string email, bool userIsOnline)
        {
            var user = userService.GetUserByEmail(email);
            if (user == null) return null;
            var memberUser = new MembershipUser("CustomMembershipProvider", $"{user.Name} {user.LastName}",
                null, user.Email, null, null,
                false, false, DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue);
            return memberUser;
        }
        #endregion

        #region Not Implemented Methods
        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(BllUser user)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email,
            string passwordQuestion,
            string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override string ApplicationName { get; set; }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }
        #endregion     
    }
}