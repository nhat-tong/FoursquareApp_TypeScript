using FoursquareApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoursquareApp.Web.Business
{
    /// <summary>
    /// Place Management Interface
    /// </summary>
    public interface IPlaceManager
    {
        /// <summary>
        /// Get user places
        /// </summary>
        /// <returns></returns>
        IEnumerable<Place> GetPlaces();

        /// <summary>
        /// Get user places pagination
        /// </summary>
        /// <returns></returns>
        IEnumerable<Place> GetPlaces(int index, int count);

        /// <summary>
        /// Insert a new place
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        ReturnCode InsertPlace(Place place);

        /// <summary>
        /// Delete a place by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ReturnCode DeletePlace(string id, string userName);
    }
}
