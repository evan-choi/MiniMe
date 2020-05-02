using System;
using MiniMe.AimeDb.Protocols;
using MiniMe.Core.Utilities;
using Serilog;

namespace MiniMe.AimeDb
{
    internal sealed class AimeDbHandler
    {
        private readonly AimeDbSession _session;
        private readonly ILogger _logger;

        public AimeDbHandler(AimeDbSession session, ILogger logger)
        {
            _logger = logger;
            _session = session;
        }

        public AimeResponse Dispatch(AimeRequest request)
        {
            switch (request)
            {
                case HelloRequest hello:
                    return Hello(hello);

                case CampaignRequest campaign:
                    return Campaign(campaign);

                case FeliCaLookupRequest feliCaLookup:
                    return FeliCaLookup(feliCaLookup);

                case LookupRequest lookup:
                    return Lookup(lookup);

                case Lookup2Request lookup2:
                    return Lookup2(lookup2);

                case RegisterRequest register:
                    return Register(register);

                case LogRequest log:
                    return Log(log);

                case GoodbyeRequest goodbye:
                    return Goodbye(goodbye);
            }

            throw new InvalidOperationException($"{request} handler not implemented");
        }

        private TResponse Ok<TResponse>(TResponse response) where TResponse : AimeResponse
        {
            response.Status = 1;
            return response;
        }

        private HelloResponse Hello(HelloRequest request)
        {
            return Ok(new HelloResponse());
        }

        private CampaignResponse Campaign(CampaignRequest request)
        {
            return Ok(new CampaignResponse());
        }

        private FeliCaLookupResponse FeliCaLookup(FeliCaLookupRequest request)
        {
            string accessCode = HexUtility.ToDecimalString(request.Idm);

            if (accessCode.Length < 20)
            {
                accessCode = accessCode.PadLeft(20 - accessCode.Length, '0');
            }

            return Ok(new FeliCaLookupResponse
            {
                AccessCode = accessCode
            });
        }

        private LookupResponse Lookup(LookupRequest request)
        {
            // TODO: request.AimeId = lookup aimeId by database
            throw new NotImplementedException();
        }

        private Lookup2Response Lookup2(Lookup2Request request)
        {
            // TODO: request.AimeId = lookup aimeId by database
            throw new NotImplementedException();
        }

        private RegisterResponse Register(RegisterRequest request)
        {
            // TODO: register card by database
            throw new NotImplementedException();
        }

        private LogResponse Log(LogRequest request)
        {
            return Ok(new LogResponse());
        }

        private AimeResponse Goodbye(GoodbyeRequest request)
        {
            return null;
        }
    }
}
