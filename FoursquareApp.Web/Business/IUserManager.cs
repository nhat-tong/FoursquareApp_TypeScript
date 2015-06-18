using FoursquareApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoursquareApp.Web.Business
{
    /// <summary>
    /// User Management Interface
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Get User
        /// </summary>
        /// <returns></returns>
        User GetUser();

        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="userName"></param>
        ReturnCode AddUser(User user);

        /// <summary>
        /// User SignIn
        /// </summary>
        /// <param name="user"></param>
        ReturnCode SignIn(User user);

        /// <summary>
        /// Get User Status
        /// </summary>
        /// <returns></returns>
        User GetStatus();
    }
}
