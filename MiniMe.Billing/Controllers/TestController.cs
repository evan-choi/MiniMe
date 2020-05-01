using Microsoft.AspNetCore.Mvc;

namespace MiniMe.Billing.Controllers
{
    [ApiController]
    [Route("/billing")]
    public class TestController : ControllerBase
    {
        [HttpGet("test")]
        public string Test()
        {
            return "multiple server test";
        }
    }
}
