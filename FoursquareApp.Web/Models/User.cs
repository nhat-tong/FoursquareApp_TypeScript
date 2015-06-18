using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace FoursquareApp.Web.Models
{
    [DataContract]
    public class User
    {
        [DataMember(Name="userName")]
        public string UserName { get; set; }

        [DataMember(Name="password")]
        public string Password { get; set; }
    }
}