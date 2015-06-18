using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace FoursquareApp.Web.Business
{
    /// <summary>
    /// MD5 Hash Management
    /// </summary>
    public class MD5HashGenerator : IHashGenerator
    {
        /// <summary>
        /// MD5 Hash
        /// </summary>
        /// <param name="stringToHash"></param>
        /// <returns></returns>
        public string Hash(string stringToHash)
        {
            MD5 md5HashAlgo = MD5.Create();

            // Place the text to hash in a byte array
            byte[] byteArrayToHash = Encoding.UTF8.GetBytes(stringToHash);

            // Hash text and place the result into a byte array
            byte[] hashResult = md5HashAlgo.ComputeHash(byteArrayToHash);

            // Convert the byte result array to hexadecimal string
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < hashResult.Length; i++)
            {
                result.Append(hashResult[i].ToString("X2"));
            }

            return result.ToString();
        }
    }
}