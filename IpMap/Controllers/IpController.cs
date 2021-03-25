using IpMap.Models;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public ActionResult<IpDataModel> Get()
        {
            IpDataModel data = new IpDataModel();
            data.IP = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            return Ok(data);
        }
    }
}
