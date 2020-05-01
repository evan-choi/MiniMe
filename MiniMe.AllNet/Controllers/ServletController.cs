using System;
using Microsoft.AspNetCore.Mvc;
using MiniMe.AllNet.Protocols;
using MiniMe.Core;
using MiniMe.Core.Utilities;

namespace MiniMe.AllNet.Controllers
{
    [ApiController]
    [Route("/sys/servlet")]
    public class ServletController : ControllerBase
    {
        [HttpPost("PowerOn")]
        [Consumes("application/x-www-form-urlencoded")]
        public PowerOnResponse PowerOnFromForm(PowerOnRequest request)
        {
            return PowerOn(request);
        }

        [HttpPost("PowerOn")]
        public PowerOnResponse PowerOn([FromBody] PowerOnRequest request)
        {
            int hourDelta = int.Parse(ProcessEnvironment.GetEnvironmentVariable("HOUR_DELTA") ?? "0");
            var now = DateTime.UtcNow.AddHours(-hourDelta);

            return new PowerOnResponse
            {
                Stat = 1,
                Uri = SwitchBoard.GetStartupUri(request.GameId) ?? string.Empty,
                Host = SwitchBoard.GetStartupHost(request.GameId) ?? string.Empty,
                PlaceId = "123",
                Name = ProcessEnvironment.GetEnvironmentVariable("SHOW_NAME") ?? string.Empty,
                Nickname = ProcessEnvironment.GetEnvironmentVariable("SHOW_NAME") ?? string.Empty,
                Region0 = "1",
                RegionName0 = "W",
                RegionName1 = "X",
                RegionName2 = "Y",
                RegionName3 = "Z",
                Country = ProcessEnvironment.GetEnvironmentVariable("SHOW_REGION") ?? "JPN",
                AllNetId = "456",
                ClientTimezone = "+0900",
                UtcTime = $"{now:s}Z",
                Setting = string.Empty,
                ResVersion = "3",
                Token = request.Token
            };
        }
    }
}
