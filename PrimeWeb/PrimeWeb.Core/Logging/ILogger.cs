using System;

namespace PrimeWeb.Core.Logging
{
    public interface ILogger
    {
        void Add(LogLevels logLevels, string description, string detail, DateTime logDate);
    }
}
