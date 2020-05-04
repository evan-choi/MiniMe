using System;

namespace MiniMe.Core.Utilities
{
    internal static class Validation
    {
        public static void ArgumentNotNull(object value, string parameterName)
        {
            if (value == null)
                throw new ArgumentNullException(parameterName);
        }
    }
}
