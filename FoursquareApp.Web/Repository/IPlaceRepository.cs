using FoursquareApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoursquareApp.Web.Repository
{
    /// <summary>
    /// Place Repository Interface
    /// </summary>
    public interface IPlaceRepository
    {
        /// <summary>
        /// Get all places from database
        /// </summary>
        /// <returns></returns>
        IEnumerable<Place> GetPlaces(string userName);

        /// <summary>
        /// Insert a new place to db
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        ReturnCode InsertPlace(Place place);

        /// <summary>
        /// Delete a place from db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ReturnCode DeletePlace(string id, string userName);
    }
}
