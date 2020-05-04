using System;
using System.Collections.ObjectModel;

namespace MiniMe.Core.AspNetCore.RequestDecompression
{
    public class DeflateDecompressionProviderCollection : Collection<IDecompressionProvider>
    {
        public void Add<T>() where T : IDecompressionProvider
        {
            Add(Activator.CreateInstance<T>());
        }
    }
}
