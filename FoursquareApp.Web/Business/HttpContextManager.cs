using FoursquareApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;

namespace FoursquareApp.Web.Business
{
    /// <summary>
    /// HttpContext Management
    /// </summary>
    public class HttpContextManager : IHttpContextManager
    {
        private const string UserContextKey = "uid";

        /// <summary>
        /// Default Constructor
        /// </summary>
        public HttpContextManager()
        {
        }

        /// <summary>
        /// Get User Context
        /// </summary>
        /// <returns></returns>
        public string GetUserContext()
        {
            return (HttpContext.Current.Request.Cookies[UserContextKey] != null ? HttpContext.Current.Request.Cookies[UserContextKey].Value : null);
        }

        /// <summary>
        /// Set User Context
        /// </summary>
        /// <param name="user"></param>
        public void SetUserContext(User user)
        {
            HttpCookie userCookie = new HttpCookie(UserContextKey, user.UserName);
            userCookie.Expires = DateTime.UtcNow.AddMinutes(30);

            HttpContext.Current.Response.Cookies.Add(userCookie);
        }
    }
}