using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using FifaPSL.BL.Services.Implementation;
using FifaPSL.BL.Services.Interfaces;
using FifaPSL.Common.Models;

namespace FifaPSL.WebApi.Controllers
{
    [RoutePrefix("auth")]
    public class SecurityController : BaseController
    {

        private ISecurityService _securityService;

        protected static RNGCryptoServiceProvider crypProvider = new RNGCryptoServiceProvider();

        public SecurityController()
        {
            _securityService = ServiceFactory.GetService<SecurityService>();
        }

        public class AuthData
        {
            public string Token { get; set; }
            public string Password { get; set; }
            public string Salt { get; set; }
        }

        /// <summary>
        /// Token Response Object
        /// </summary>
        public class TokenResponse
        {
            public string token { get; set; }
        }


        /// <summary>
        /// Get Password Salt and Hash
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        [Route("setup")]
        [HttpPost]
        public HttpResponseMessage GetTempSalt(String password)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, _securityService.GetCryptoKey(password));

        }


        /// <summary>
        /// Get Auth token for restricted services
        /// </summary>
        /// <param name="authModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("token")]
        public HttpResponseMessage GetToken(AuthenticationRequestModel authModel)
        {
            if (ModelState.IsValid)
            {

                string token = _securityService.Login(authModel);

                if (token != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new TokenResponse {token = token});
                }

                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "User name or password is not valid");

            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Credentials provided are invalid");
            }
        }

    }
}
