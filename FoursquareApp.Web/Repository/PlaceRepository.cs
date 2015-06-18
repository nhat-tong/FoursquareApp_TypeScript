using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using FoursquareApp.Web.Models;
using System.Data.SqlClient;
using System.Data;

namespace FoursquareApp.Web.Repository
{
    /// <summary>
    /// Responsible for Place with database
    /// </summary>
    public class PlaceRepository : IPlaceRepository
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public PlaceRepository()
        {
        }

        /// <summary>
        /// Get all places from database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Place> GetPlaces(string userName)
        {
            IEnumerable<Place> results = null;

            using (var connection = new SqlConnection(FoursquareSettings.FoursquareConnection))
            {
                connection.Open();

                results = connection.Query<Place>("GetPlacesStoreProc", new {userName}, commandType: CommandType.StoredProcedure).ToList();

                connection.Close();
            }

            return results;
        }

        /// <summary>
        /// Insert a new place to db
        /// </summary>
        /// <param name="place"></param>
        public ReturnCode InsertPlace(Place place)
        {
            ReturnCode statusCode = ReturnCode.Failed;

            var parameters = new DynamicParameters(new
            {
                UserName = place.UserName,
                PlaceId = place.Id,
                Name = place.Name,
                Cat = place.Category,
                Adr = place.Address,
                Rating = place.Rating
            });
            parameters.Add("@ReturnCode", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            using (var connection = new SqlConnection(FoursquareSettings.FoursquareConnection))
            {
                connection.Open();

                connection.Execute("InsertPlaceStoreProc", parameters, commandType: CommandType.StoredProcedure);

                statusCode = parameters.Get<ReturnCode>("@ReturnCode");

                connection.Close();
            }

            return statusCode;
        }

        /// <summary>
        /// Delete a place from db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ReturnCode DeletePlace(string id, string userName)
        {
            ReturnCode returnCode = ReturnCode.Failed;

            var parameters = new DynamicParameters(new
            {
                id = id,
                UserName = userName
            });

            parameters.Add("@ReturnCode", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            using (var connection = new SqlConnection(FoursquareSettings.FoursquareConnection))
            {
                connection.Open();

                connection.ExecuteScalar("DeletePlaceStoreProc", parameters, commandType: CommandType.StoredProcedure);

                returnCode = parameters.Get<ReturnCode>("@ReturnCode");

                connection.Close();
            }

            return returnCode;
        }
    }
}