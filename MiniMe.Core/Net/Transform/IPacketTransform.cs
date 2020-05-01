﻿using System;

namespace MiniMe.Core.Net.Transform
{
    public interface IPacketTransform
    {
        ReadOnlySpan<byte> Transform(ref ReadOnlySpan<byte> packet);
    }
}
