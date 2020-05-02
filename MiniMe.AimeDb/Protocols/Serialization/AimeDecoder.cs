using System;
using System.Collections.Generic;
using System.Text;
using MiniMe.Core.Extension;
using MiniMe.Core.Utilities;

namespace MiniMe.AimeDb.Protocols.Serialization
{
    internal static class AimeDecoder
    {
        private delegate AimeRequest DecodeCallback(ref ReadOnlySpan<byte> packet);

        private static readonly Dictionary<ushort, DecodeCallback> _readers =
            new Dictionary<ushort, DecodeCallback>
            {
                [0x0001] = ReadFeliCaLookupRequest,
                [0x0004] = ReadLookupRequest,
                [0x0005] = ReadRegisterRequest,
                [0x0009] = ReadLogRequest,
                [0x000b] = ReadCampaignRequest,
                [0x000d] = ReadRegisterRequest,
                [0x000f] = ReadLookupRequest2,
                [0x0064] = ReadHelloRequest,
                [0x0066] = ReadGoodbyeRequest
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
        private static void ReadMetadata(AimeRequest request, ref ReadOnlySpan<byte> packet)
        {
            request.GameId = Encoding.ASCII.GetString(packet.Slice(10, 4));
            request.KeyChipId = Encoding.ASCII.GetString(packet.Slice(20, 11));
        }

        private static AimeRequest ReadFeliCaLookupRequest(ref ReadOnlySpan<byte> packet)
        {
            var request = new FeliCaLookupRequest();

            ReadMetadata(request, ref packet);
            request.Idm = HexUtility.ToHexString(packet.Slice(32, 8));
            request.Pmm = HexUtility.ToHexString(packet.Slice(40, 8));

            return request;
        }

        private static AimeRequest ReadLookupRequest(ref ReadOnlySpan<byte> packet)
        {
            var request = new Lookup2Request();

            ReadMetadata(request, ref packet);
            request.Luid = HexUtility.ToHexString(packet.Slice(32, 10));

            return request;
        }

        private static AimeRequest ReadLogRequest(ref ReadOnlySpan<byte> packet)
        {
            var request = new LogRequest();

            ReadMetadata(request, ref packet);
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

        private static AimeRequest ReadCampaignRequest(ref ReadOnlySpan<byte> packet)
        {
            var request = new CampaignRequest();

            ReadMetadata(request, ref packet);

            return request;
        }

        private static AimeRequest ReadRegisterRequest(ref ReadOnlySpan<byte> packet)
        {
            var request = new RegisterRequest();

            ReadMetadata(request, ref packet);
            request.Luid = HexUtility.ToHexString(packet.Slice(32, 10));

            return request;
        }

        private static AimeRequest ReadLookupRequest2(ref ReadOnlySpan<byte> packet)
        {
            var request = new Lookup2Request();

            ReadMetadata(request, ref packet);
            request.Luid = HexUtility.ToHexString(packet.Slice(32, 10));

            return request;
        }

        private static AimeRequest ReadHelloRequest(ref ReadOnlySpan<byte> packet)
        {
            var request = new HelloRequest();
            ReadMetadata(request, ref packet);

            return request;
        }

        private static AimeRequest ReadGoodbyeRequest(ref ReadOnlySpan<byte> packet)
        {
            return new GoodbyeRequest();
        }
        #endregion
    }
}
