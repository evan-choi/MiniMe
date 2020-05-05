using Microsoft.AspNetCore.Mvc;
using MiniMe.Billing.Protocols;
using MiniMe.Core.Utilities;

namespace MiniMe.Billing.Controllers
{
    [ApiController]
    [Route("/")]
    public class BillingController : ControllerBase
    {
        private const int playLimit = 1024;
        private const int nearFull = 0x00010200;

        private readonly BillingCryptoService _cryptoService;

        public BillingController(BillingCryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        [HttpPost("request")]
        public BillingResponse Request([FromBody] BillingRequest request)
        {
            byte[] signedPlayLimit = _cryptoService.Sign(playLimit, request.KeyChipId);
            byte[] signedNearFull = _cryptoService.Sign(nearFull, request.KeyChipId);
            
            return new BillingResponse
            {
                Result = 0,
                WaitTime = 100,
                LineLimit = 1,
                Message = string.Empty,
                PlayLimit = playLimit,
                PlayLimitSignature = HexUtility.BytesToHex(signedPlayLimit).ToLower(),
                NearFull = nearFull,
                NearFullSignature = HexUtility.BytesToHex(signedNearFull).ToLower(),
                ProtocolVersion = "1.000",
                FixLogCount = 0,
                FixInterval = 5,
                PlayHistory = "000000/0:000000/0:000000/0"
            };
        }
    }
}
