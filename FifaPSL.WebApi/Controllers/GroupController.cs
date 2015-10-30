using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FifaPSL.BL.Services.Implementation;
using FifaPSL.Common.Models;

namespace FifaPSL.WebApi.Controllers
{
    [RoutePrefix("group")]
    public class GroupController : BaseController
    {

        protected static GroupService groupService;

#pragma warning disable 1591
        public GroupController()
#pragma warning restore 1591
        {
            groupService = (GroupService) serviceFactory.GetGroupService();
        }


        /// <summary>
        /// Get Group
        /// </summary>
        /// <param name="groupId">Group ID</param>
        /// <returns>a Group or 404 Not Found</returns>
        [HttpGet]
        [Route("{groupId:int}")]
        public Group GetGroup(int groupId)
        {
            throw new NotImplementedException();
        }
        
    }
}
