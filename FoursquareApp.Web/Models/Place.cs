using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FoursquareApp.Web.Models
{
    [DataContract]
    public class Place
    {
        [DataMember(Name="id")]
        public string Id { get; set; }

        [DataMember(Name="userName")]
        public string UserName { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "category")]
        public string Category { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "rating")]
        public string Rating { get; set; }
    }
}