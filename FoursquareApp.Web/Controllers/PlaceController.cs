using FoursquareApp.Web.Business;
using FoursquareApp.Web.Models;
using FoursquareApp.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace FoursquareApp.Web.Controllers
{
    public class PlaceController : ApiController
    {
        private IPlaceManager _placeManager;

        public PlaceController()
        {
            _placeManager = new PlaceManager();
        }

        // GET api/Place
        [HttpGet]
        public IEnumerable<Place> Get()
        {
            return _placeManager.GetPlaces();
        }

        [HttpGet]
        public IEnumerable<Place> Get(int index, int count)
        {
            return _placeManager.GetPlaces(index, count);
        }

        // POST api/Place
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Place place)
        {
            ReturnCode returnCode = _placeManager.InsertPlace(place);

            if (returnCode == ReturnCode.Success)
            {
                return Request.CreateResponse(HttpStatusCode.Created, "Place inserted successfully");
            }
            else if (returnCode == ReturnCode.Existed)
            {
                return Request.CreateResponse(HttpStatusCode.NotModified, "Place already bookmarked");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Place insert error");
            }
        }

        // DELETE api/Place/id
        [HttpDelete]
        public HttpResponseMessage Delete(string id, string userName)
        {
            ReturnCode statusCode = _placeManager.DeletePlace(id, userName);

            if (statusCode == ReturnCode.Success)
            {
                var places = _placeManager.GetPlaces();
                return Request.CreateResponse(HttpStatusCode.OK, places);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Place delete error");
            }
        }
    }
}