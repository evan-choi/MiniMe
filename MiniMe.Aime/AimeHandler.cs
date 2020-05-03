using System;
using MiniMe.Aime.Data;
using MiniMe.Aime.Data.Models;
using MiniMe.Aime.Protocols;
using MiniMe.Core.Utilities;
using Serilog;

namespace MiniMe.Aime
{
    internal sealed class AimeHandler
    {
        private readonly AimeSession _session;
        private readonly AimeUserRepository _repository;
        private readonly ILogger _logger;

        public AimeHandler(AimeSession session, AimeUserRepository repository, ILogger logger)
        {
            _logger = logger;
            _session = session;
            _repository = repository;
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
            string accessCode = HexUtility.HexToDecimalString(request.Idm).PadLeft(20, '0');

            return Ok(new FeliCaLookupResponse
            {
                AccessCode = accessCode
            });
        }

        private LookupResponse Lookup(LookupRequest request)
        {
            var user = _repository.Find(u => u.AccessCode == request.AccessCode);

            return Ok(new LookupResponse
            {
                AimeId = user?.CardId,
                RegisterLevel = RegisterLevel.None
            });
        }

        private Lookup2Response Lookup2(Lookup2Request request)
        {
            var user = _repository.Find(u => u.AccessCode == request.AccessCode);

            return Ok(new Lookup2Response
            {
                AimeId = user?.CardId,
                RegisterLevel = RegisterLevel.None
            });
        }

        private RegisterResponse Register(RegisterRequest request)
        {
            var user = new AimeUser
            {
                Id = Guid.NewGuid(),
                CardId = AimeUtility.GenerateCardId(),
                AccessCode = request.AccessCode,
                CreatedAt = DateTimeOffset.Now,
                AccessAt = DateTimeOffset.Now
            };

            _repository.Add(user);

            return Ok(new RegisterResponse
            {
                AimeId = user.CardId
            });
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
