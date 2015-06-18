using FoursquareApp.Web.Business;
using FoursquareApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace FoursquareApp.Web.Controllers
{
    public class UserController : ApiController
    {
        private IUserManager _userManager;
        private IPlaceManager _placeManager;
        private IHttpContextManager _httpContextManager;

        public UserController()
        {
            _userManager = new UserManager();
            _placeManager = new PlaceManager();
            _httpContextManager = new HttpContextManager();
        }

        // GET api/User
        [HttpGet]
        [ActionName("GetUser")]
        public HttpResponseMessage GetUser()
        {
            var user = _userManager.GetUser();

            if (user != null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotModified);
                msg.Headers.Add("userName", user.UserName);
                return msg;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Info: User not existed");
            }
        }

        [HttpGet]
        [ActionName("GetStatus")]
        public HttpResponseMessage GetStatus()
        {
            var user = _userManager.GetStatus();

            if (user != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user.UserName);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, string.Empty);
            }
        }

        // GET api/User
        [HttpPost]
        [ActionName("SignIn")]
        public HttpResponseMessage SignIn([FromBody]User user)
        {
            var result = _userManager.SignIn(user);

            if (result == ReturnCode.Success)
            {
                _httpContextManager.SetUserContext(user);
                FormsAuthentication.SetAuthCookie(user.UserName, true);

                return Request.CreateResponse(HttpStatusCode.OK, "User signed in successfully");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "User name or Password is not correct");
            }
        }

        [HttpPost]
        [ActionName("SignOut")]
        public HttpResponseMessage SignOut()
        {
            FormsAuthentication.SignOut();

            return Request.CreateResponse(HttpStatusCode.OK); 
        }

        // POST api/User
        [HttpPost]
        [ActionName("AddUser")]
        public HttpResponseMessage AddUser([FromBody]User user)
        {
            var returnCode = _userManager.AddUser(user);

            if (returnCode == ReturnCode.Success)
            {
                return Request.CreateResponse(HttpStatusCode.Created, "New user created");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "User create error");
            }
        }
    }
}