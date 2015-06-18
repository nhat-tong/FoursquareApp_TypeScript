using FoursquareApp.Web.Models;
using FoursquareApp.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;

namespace FoursquareApp.Web.Business
{
    /// <summary>
    /// User Management
    /// </summary>
    public class UserManager : IUserManager
    {
        private IHttpContextManager _httpContextManager;
        private IUserRepository _userRepository;
        private IHashGenerator _hashGenerator;

        /// <summary>
        /// Default contructor
        /// </summary>
        public UserManager()
        {
            _userRepository = new UserRepository();
            _httpContextManager = new HttpContextManager();
            _hashGenerator = new MD5HashGenerator();
        }

        /// <summary>
        /// Get user from context
        /// </summary>
        /// <returns></returns>
        public User GetUser()
        {
            User user = null;
            var userName = _httpContextManager.GetUserContext();

            if (!string.IsNullOrEmpty(userName))
            {
                user = new User();
                user.UserName = userName;
            }

            return user;
        }

        /// <summary>
        /// Add a new user to context
        /// </summary>
        /// <param name="user"></param>
        public ReturnCode AddUser(User user)
        {
            _httpContextManager.SetUserContext(user);

            // Hash password here
            var passwordEncoded = _hashGenerator.Hash(user.Password);

            user.Password = passwordEncoded;

            return _userRepository.AddUser(user);
        }

        /// <summary>
        /// User Sign In
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public ReturnCode SignIn(User user)
        {
            var returnCode = ReturnCode.Failed;
            // Hash password here
            var passwordEncoded = _hashGenerator.Hash(user.Password);

            user.Password = passwordEncoded;

            returnCode = _userRepository.SignIn(user);

            if (returnCode == ReturnCode.Success)
            {
                // Set User Identity
                string[] roles = { "User", "Admin" };
                HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(user.UserName), roles);
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(user.UserName), roles);
            }

            return returnCode;
        }

        /// <summary>
        /// Get User Status
        /// </summary>
        /// <returns></returns>
        public User GetStatus()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return this.GetUser();
            }

            return null;
        }
    }
}