using System;
using Microsoft.AspNetCore.Mvc;
using MiniMe.AllNet.Protocols;
using MiniMe.Core;
using MiniMe.Core.AspNetCore.Mvc;
using MiniMe.Core.Utilities;

namespace MiniMe.AllNet.Controllers
{
    [ApiController]
    [Route("/sys/servlet")]
    public class ServletController : ControllerBase
    {
        [HttpPost("PowerOn")]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult PowerOnFromForm([FromBase64Form] PowerOnPayload payload)
        {
            return PowerOn(payload);
        }

        [HttpPost("PowerOn")]
        public IActionResult PowerOn([FromBody] PowerOnPayload payload)
        {
            int hourDelta = int.Parse(ProcessEnvironment.GetEnvironmentVariable("HOUR_DELTA") ?? "0");
            var now = DateTime.UtcNow.AddHours(-hourDelta);

            return Ok(new PowerOnResponse
            {
                Stat = 1,
                Uri = SwitchBoard.GetStartupUri(payload.GameId),
                Host = SwitchBoard.GetStartupHost(payload.GameId),
                PlaceId = "123",
                Name = ProcessEnvironment.GetEnvironmentVariable("SHOW_NAME") ?? string.Empty,
                Nickname = ProcessEnvironment.GetEnvironmentVariable("SHOW_NAME") ?? string.Empty,
                Region0 = "1",
                RegionName0 = "W",
                RegionName1 = "X",
                RegionName2 = "Y",
                RegionName3 = "Z",
                Country = ProcessEnvironment.GetEnvironmentVariable("SHOW_REGION") ?? string.Empty,
                AllnetId = "456",
                ClientTimezone = "+0900",
                UtcTime = $"{now:s}Z",
                Setting = string.Empty,
                ResVersion = "3",
                Token = payload.Token
            });
        }
    }
}
