using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FoursquareApp.Web.Models
{
    public static class FoursquareSettings
    {
        public static string FoursquareConnection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["FoursquareConnection"].ConnectionString;
            }
        }
    }
}