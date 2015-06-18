using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoursquareApp.Web.Models
{
    public enum ReturnCode : int
    {
        /// <summary>
        /// Action failed
        /// </summary>
        Failed = -1,

        /// <summary>
        /// Action existed
        /// </summary>
        Existed = 0,

        /// <summary>
        /// Action ok
        /// </summary>
        Success = 1
    }
}