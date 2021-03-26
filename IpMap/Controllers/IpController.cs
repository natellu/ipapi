using IpData;
using IpData.Models;
using IpMap.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        public async Task<IpDataModel> Get()
        {
            IpDataModel data = new IpDataModel();
            string ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            /*string ip = "92.208.162.222";*/
            data.IP = ip;
            string apiKey = configuration.GetSection("ipdata").Value;
            string url = "https://api.ipdata.co/" + ip + "?api-key=" + apiKey;
           
            IpDataClient client = new IpDataClient(apiKey);
            IpInfo ipInfo = await client.Lookup(ip);
            data.IpInfos = ipInfo;
            return data;
        }
    }
}
