﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class StationsController : ApiController
    {
        public StationsController()
        {

        }
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}