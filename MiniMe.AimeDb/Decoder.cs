using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using MiniMe.AimeDb.Protocols;
using MiniMe.Core.Extension;

namespace MiniMe.AimeDb
{
    internal static class Decoder
    {
        private delegate AimeRequest DecodeCallback(ref ReadOnlySpan<byte> packet);

        private static readonly Dictionary<ushort, DecodeCallback> _readers;

        static Decoder()
        {
            _readers = new Dictionary<ushort, DecodeCallback>
            {
                [1] = ReadFeliCaLookupRequest,
                [4] = ReadLookupRequest,
                [5] = ReadRegisterRequest,
                [9] = ReadLogRequest,
                [11] = ReadCampaignRequest,
                [13] = ReadRegisterRequest,
                [15] = ReadLookupRequest2,
                [100] = ReadHelloRequest,
                [102] = ReadGoodbyeRequest
            };
        }

        public static AimeRequest Decode(ref ReadOnlySpan<byte> packet)
        {
            var opCode = packet.Read<ushort>(4);

            if (_readers.TryGetValue(opCode, out var decoder))
            {
                return decoder(ref packet);
            }

            throw new InvalidOperationException($"Unknown operation code 0x{opCode:X}({opCode})");
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
            request.Idm = packet.Slice(20, 8).ToHexString();
            request.Pmm = packet.Slice(28, 2).ToHexString();

            return request;
        }

        private static AimeRequest ReadLookupRequest(ref ReadOnlySpan<byte> packet)
        {
            throw new NotImplementedException();
        }

        private static AimeRequest ReadLogRequest(ref ReadOnlySpan<byte> packet)
        {
            throw new NotImplementedException();
        }

        private static AimeRequest ReadCampaignRequest(ref ReadOnlySpan<byte> packet)
        {
            throw new NotImplementedException();
        }

        private static AimeRequest ReadRegisterRequest(ref ReadOnlySpan<byte> packet)
        {
            throw new NotImplementedException();
        }

        private static AimeRequest ReadLookupRequest2(ref ReadOnlySpan<byte> packet)
        {
            throw new NotImplementedException();
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
