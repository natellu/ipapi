using IpMap.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpMap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IpController : ControllerBase
    {
        private IConfiguration configuration;
        public IpController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        [HttpGet]
        public ActionResult<IpDataModel> Get()
        {
            IpDataModel data = new IpDataModel();
            /*data.IP = Request.HttpContext.Connection.RemoteIpAddress.ToString();*/
            data.IP = configuration.GetSection("ipdata").Value;

            return Ok(data);
        }
    }
}
