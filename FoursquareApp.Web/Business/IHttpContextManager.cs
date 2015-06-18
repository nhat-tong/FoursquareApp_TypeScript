using FoursquareApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoursquareApp.Web.Business
{
    /// <summary>
    /// HttpContext Management Interface
    /// </summary>
    public interface IHttpContextManager
    {
        /// <summary>
        /// Get User Context From Cookie
        /// </summary>
        /// <returns></returns>
        string GetUserContext();

        /// <summary>
        /// Set User Context To Cookie
        /// </summary>
        /// <param name="user"></param>
        void SetUserContext(User user);
    }
}
