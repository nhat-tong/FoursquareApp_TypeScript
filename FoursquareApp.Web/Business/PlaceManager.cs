using FoursquareApp.Web.Models;
using FoursquareApp.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoursquareApp.Web.Business
{
    /// <summary>
    /// Place Management
    /// </summary>
    public class PlaceManager : IPlaceManager
    {
        private IUserManager _userManager;
        private IPlaceRepository _placeRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        public PlaceManager()
        {
            _userManager = new UserManager();
            _placeRepository = new PlaceRepository();
        }

        /// <summary>
        /// Get user places
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Place> GetPlaces()
        {
            var user = _userManager.GetUser();
            IEnumerable<Place> places = new List<Place>();

            if (user != null)
            {
                places = _placeRepository.GetPlaces(user.UserName);
            }

            return places;
        }

        /// <summary>
        /// Get user places pagination
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Place> GetPlaces(int index, int count)
        {
            var user = _userManager.GetUser();

            IEnumerable<Place> places = new List<Place>();

            if (user != null)
            {
                places = _placeRepository.GetPlaces(user.UserName);
            }

            // ignore a number of index element and after getting a number of count element 
            return places.Skip(index).Take(count);
        }

        /// <summary>
        /// Insert a new place
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        public ReturnCode InsertPlace(Place place)
        {
            return _placeRepository.InsertPlace(place);
        }

        /// <summary>
        /// Delete a place by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ReturnCode DeletePlace(string id, string userName)
        {
            return _placeRepository.DeletePlace(id, userName);
        }
    }
}