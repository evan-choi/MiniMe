using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MiniMe.Billing.Controllers
{
    [ApiController]
    [Route("/")]
    public class BillingController : ControllerBase
    {
        [HttpPost("request")]
        public string Request([FromBody] IDictionary<string, string>[] request)
        {
            return "multiple server test";
        }
    }
}
