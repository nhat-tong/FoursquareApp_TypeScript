using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoursquareApp.Web.Business
{
    /// <summary>
    /// Hash generator management
    /// </summary>
    public interface IHashGenerator
    {
        /// <summary>
        /// Hash Method
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        string Hash(string stringToHash);
    }
}
