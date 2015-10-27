using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FifaPSL.Common.Models;
using FifaPSL.BL.Services.Implementation;

namespace FifaPSL.WebApi.Controllers
{
    public class BaseController: ApiController
    {

        protected ServiceFactory serviceFactory;

        public BaseController() {
            initFactory();
        }

        protected void initFactory() {
            if (serviceFactory == null) {
                serviceFactory = new ServiceFactory();
            }
        }

    }
}
