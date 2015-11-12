using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

namespace FifaPSL.WebApi.Controllers
{
    [RoutePrefix("auth")]
    public class SecurityController : BaseController
    {

        protected static RNGCryptoServiceProvider crypProvider = new RNGCryptoServiceProvider();

        public class AuthData
        {
            public string Token { get; set; }
            public string Password { get; set; }
            public string Salt { get; set; }
        }


        /// <summary>
        /// Get Password Salt and Hash
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        [Route("setup")]
        [HttpPost]
        public AuthData getTempSalt([FromBody] String password)
        {
            byte[] mySaltHash = new byte[32];
            byte[] myPasswordHash = Encoding.UTF8.GetBytes(password);

            SecurityController.crypProvider.GetBytes(mySaltHash);
            SHA256Managed cryptManager = new SHA256Managed();

            byte[] finalHash = cryptManager.ComputeHash(mySaltHash.Concat(myPasswordHash).ToArray(), 0 ,mySaltHash.Length + myPasswordHash.Length);

            AuthData response = new AuthData();

            response.Salt = BitConverter.ToString(mySaltHash).Replace("-", "");
            response.Password = BitConverter.ToString(myPasswordHash).Replace("-", "");

            return response;

        }

    }
}
