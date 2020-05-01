using System;

namespace MiniMe.Core.Utilities
{
    public static class ProcessEnvironment
    {
        public static string GetEnvironmentVariable(string variable)
        {
            return Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
        }
    }
}
