using System;

namespace MiniMe.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LoggerNameAttribute : Attribute
    {
        public string Name { get; }

        public LoggerNameAttribute(string name)
        {
            Name = name;
        }
    }
}
