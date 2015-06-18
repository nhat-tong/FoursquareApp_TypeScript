using FoursquareApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoursquareApp.Web.Repository
{
    public interface IUserRepository
    {
        /// <summary>
        /// User Sign In
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        ReturnCode SignIn(User user);

        /// <summary>
        /// Insert new user to db
        /// </summary>
        /// <param name="user"></param>
        ReturnCode AddUser(User user);
    }
}
