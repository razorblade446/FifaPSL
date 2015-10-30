using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FifaPSL.Common.Models;

namespace FifaPSL.WebApi.Controllers
{
    [RoutePrefix("match")]
    public class MatchController : BaseController
    {
        public MatchController() {
        }

        /// <summary>
        /// Get Match by ID
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        [Route("{matchId:int}")]
        [HttpGet]
        public Match GetMatch(int matchId) {
            throw new NotImplementedException();
        }
 
    }
}
