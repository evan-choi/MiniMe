using System;
using System.Collections.Generic;
using System.Text;
using MiniMe.Core.Extension;
using MiniMe.Core.Utilities;

namespace MiniMe.Aime.Protocols.Serialization
{
    internal static class AimeDecoder
    {
        private delegate AimeRequest DecodeCallback(ref ReadOnlySpan<byte> packet);

        private static readonly Dictionary<ushort, DecodeCallback> _readers =
            new Dictionary<ushort, DecodeCallback>
            {
                [0x0001] = DecodeFeliCaLookupRequest,
                [0x0004] = DecodeLookupRequest,
                [0x0005] = DecodeRegisterRequest,
                [0x0009] = DecodeLogRequest,
                [0x000b] = DecodeCampaignRequest,
                [0x000d] = DecodeRegisterRequest,
                [0x000f] = DecodeLookupRequest2,
                [0x0064] = DecodeHelloRequest,
                [0x0066] = DecodeGoodbyeRequest
            };

        public static AimeRequest Decode(ref ReadOnlySpan<byte> packet)
        {
            var header = packet.Read<AimeHeader>();

            if (_readers.TryGetValue(header.OpCode, out var decoder))
            {
                return decoder(ref packet);
            }

            throw new InvalidOperationException($"Unknown operation code 0x{header.OpCode:X}({header.OpCode})");
        }

        #region Decoders
        private static void DecodeMetadata(AimeRequest request, ref ReadOnlySpan<byte> packet)
        {
            request.GameId = Encoding.ASCII.GetString(packet.Slice(10, 4));
            request.KeyChipId = Encoding.ASCII.GetString(packet.Slice(20, 11));
        }

        private static AimeRequest DecodeFeliCaLookupRequest(ref ReadOnlySpan<byte> packet)
        {
            var request = new FeliCaLookupRequest();

            DecodeMetadata(request, ref packet);
            request.Idm = HexUtility.BytesToHex(packet.Slice(32, 8));
            request.Pmm = HexUtility.BytesToHex(packet.Slice(40, 8));

            return request;
        }

        private static AimeRequest DecodeLookupRequest(ref ReadOnlySpan<byte> packet)
        {
            var request = new Lookup2Request();

            DecodeMetadata(request, ref packet);
            request.AccessCode = HexUtility.BytesToHex(packet.Slice(32, 10));

            return request;
        }

        private static AimeRequest DecodeLogRequest(ref ReadOnlySpan<byte> packet)
        {
            var request = new LogRequest();

            DecodeMetadata(request, ref packet);
            request.Field20 = packet.Read<uint>(0x20);
            request.Field24 = packet.Read<uint>(0x24);
            request.Field28 = packet.Read<uint>(0x28);
            request.Field2C = packet.Read<uint>(0x2C);
            request.Field30 = packet.Read<uint>(0x30);
            request.Field34 = packet.Read<uint>(0x34);
            request.Field38 = packet.Read<uint>(0x38);
            request.Field3C = packet.Read<uint>(0x3C);

            return request;
        }

        private static AimeRequest DecodeCampaignRequest(ref ReadOnlySpan<byte> packet)
        {
            var request = new CampaignRequest();

            DecodeMetadata(request, ref packet);

            return request;
        }

        private static AimeRequest DecodeRegisterRequest(ref ReadOnlySpan<byte> packet)
        {
            var request = new RegisterRequest();

            DecodeMetadata(request, ref packet);
            request.AccessCode = HexUtility.BytesToHex(packet.Slice(32, 10));

            return request;
        }

        private static AimeRequest DecodeLookupRequest2(ref ReadOnlySpan<byte> packet)
        {
            var request = new Lookup2Request();

            DecodeMetadata(request, ref packet);
            request.AccessCode = HexUtility.BytesToHex(packet.Slice(32, 10));

            return request;
        }

        private static AimeRequest DecodeHelloRequest(ref ReadOnlySpan<byte> packet)
        {
            var request = new HelloRequest();

            DecodeMetadata(request, ref packet);

            return request;
        }

        private static AimeRequest DecodeGoodbyeRequest(ref ReadOnlySpan<byte> packet)
        {
            return new GoodbyeRequest();
        }
        #endregion
    }
}
