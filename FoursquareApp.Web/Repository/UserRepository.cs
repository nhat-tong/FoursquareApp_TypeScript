using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using FoursquareApp.Web.Models;
using System.Data;

namespace FoursquareApp.Web.Repository
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Default contructor
        /// </summary>
        public UserRepository()
        {
        }

        /// <summary>
        /// User Sign In
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ReturnCode SignIn(User user)
        {
            ReturnCode isSigned = ReturnCode.Failed;

            var parameters = new DynamicParameters(new { 
                UserName = user.UserName,
                Password = user.Password
            });

            parameters.Add("@ReturnCode", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            using (var connection = new SqlConnection(FoursquareSettings.FoursquareConnection))
            {
                connection.Open();

                connection.Query("SignInStoreProc", parameters, commandType: CommandType.StoredProcedure);

                isSigned = parameters.Get<ReturnCode>("@ReturnCode");

                connection.Close();
            }

            return isSigned;
        }

        /// <summary>
        /// Insert new user to db
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ReturnCode AddUser(User user)
        {
            var returnCode = ReturnCode.Failed;

            var parameters = new DynamicParameters(new
            {
                UserName = user.UserName,
                Password = user.Password
            });
            parameters.Add("@ReturnCode", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            using (var connection = new SqlConnection(FoursquareSettings.FoursquareConnection))
            {
                connection.Open();

                connection.Query("AddUserStoreProc", parameters, commandType: CommandType.StoredProcedure);
                returnCode = parameters.Get<ReturnCode>("@ReturnCode");

                connection.Close();
            }

            return returnCode;
        }
    }
}