using System;
using System.Collections.Generic;
using System.Linq;
using MiniMe.Chunithm.Data.Models;
using MiniMe.Chunithm.Protocols;

namespace MiniMe.Chunithm
{
    internal static class ChunithmUtility
    {
        public static int NextPagination<T>(T[] array, ILimitedPagination pagination)
        {
            if (array.Length < pagination.MaxCount)
            {
                return -1;
            }

            return pagination.NextIndex + pagination.MaxCount;
        }

        public static IEnumerable<T> PrepareDbObjects<T>(IEnumerable<T> source) where T : class, IDbObject
        {
            return source.Select(t =>
            {
                if (t != null)
                {
                    t.Id = Guid.NewGuid();
                }

                return t;
            });
        }

        public static IEnumerable<T> PrepareDbObjects<T>(IEnumerable<T> source, Guid id) where T : class, IDbObject
        {
            return source.Select(t =>
            {
                if (t != null)
                {
                    t.Id = id;
                }

                return t;
            });
        }
    }
}
