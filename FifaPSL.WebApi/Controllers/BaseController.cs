﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using FifaPSL.Common.Models;
using FifaPSL.BL.Services.Implementation;

namespace FifaPSL.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseController: ApiController
    {

        protected ServiceFactory serviceFactory;

#pragma warning disable 1591
        public BaseController() {
#pragma warning restore 1591
            initFactory();
        }

        protected void initFactory() {
            if (serviceFactory == null) {
                serviceFactory = new ServiceFactory();
            }
        }

    }
}
