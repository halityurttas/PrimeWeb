using log4net;
using log4net.Config;
using System;

namespace PrimeWeb.Service.LogService
{
    /// <summary>
    /// Log4Net service
    /// https://logging.apache.org/log4net/
    /// </summary>
    public class Log4NetService : ILogService
    {
        ILog _log;

        public Log4NetService()
        {
            _log = LogManager.GetLogger("");
            XmlConfigurator.Configure();
        }

        public void Debug(object message)
        {
            _log.Debug(message);
        }

        public void Debug(object message, Exception exception)
        {
            _log.Debug(message, exception);
        }
        
        public void Error(object message)
        {
            _log.Error(message);
        }

        public void Error(object message, Exception exception)
        {
            _log.Error(message, exception);
        }
        
        public void Fatal(object message)
        {
            _log.Fatal(message);
        }

        public void Fatal(object message, Exception exception)
        {
            _log.Fatal(message, exception);
        }

        public void Info(object message)
        {
            _log.Info(message);
        }

        public void Info(object message, Exception exception)
        {
            _log.Info(message, exception);
        }

        public void Warn(object message)
        {
            _log.Warn(message);
        }

        public void Warn(object message, Exception exception)
        {
            _log.Warn(message, exception);
        }

    }
}
