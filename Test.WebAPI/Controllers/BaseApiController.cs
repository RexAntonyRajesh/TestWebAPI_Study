using System.Net;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Test.Domain;
using Test.WebAPI.Extension;
using Test.Service.Response;

namespace Test.WebAPI.Base
{
    public abstract class BaseApiController : ControllerBase
    {
        private readonly IConfiguration config;

        public BaseApiController(IConfiguration config)
        {
            this.config = config;
        }
    }
}