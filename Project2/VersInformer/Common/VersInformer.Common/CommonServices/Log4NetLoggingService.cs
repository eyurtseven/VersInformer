using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Core;
using VersInformer.Common.ServiceInterfaces;

namespace VersInformer.Common.CommonServices
{
    /// <summary>
    /// Log4net Logging Service Implementation
    /// </summary>
    public class Log4NetLoggingService : ILoggingService
    {
        private static readonly ConcurrentDictionary<string, ILog> Loggers = new ConcurrentDictionary<string, ILog>();

        /// <summary>
        /// Initializes the <see cref="Log4NetLoggingService"/> class.
        /// </summary>
        static Log4NetLoggingService()
        {
            XmlConfigurator.Configure();
        }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <param name="loggerName">Name of the logger.</param>
        /// <returns></returns>
        private ILog GetLogger(string loggerName)
        {
            return Loggers.GetOrAdd(loggerName, LogManager.GetLogger);
        }

        /// <summary>
        /// Debugs the specified logger.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Debug(string logger, string message, Exception exception = null)
        {
            if (exception != null)
                GetLogger(logger).Debug(message, exception);
            else
                GetLogger(logger).Debug(message);
        }

        /// <summary>
        /// Debugs the specified logger.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="format">The format.</param>
        /// <param name="parameters">The parameters.</param>
        public void Debug(string logger, Exception exception, string format, params object[] parameters)
        {
            if (exception != null)
                GetLogger(logger).Debug(string.Format(format, parameters), exception);
            else
                GetLogger(logger).Debug(string.Format(format, parameters));

        }

        /// <summary>
        /// Informations the specified logger.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Info(string logger, string message, Exception exception = null)
        {
            if (exception != null)
                GetLogger(logger).Info(message, exception);
            else
                GetLogger(logger).Info(message);
        }

        /// <summary>
        /// Informations the specified logger.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="format">The format.</param>
        /// <param name="parameters">The parameters.</param>
        public void Info(string logger, Exception exception, string format, params object[] parameters)
        {
            if (exception != null)
                GetLogger(logger).Info(string.Format(format, parameters), exception);
            else
                GetLogger(logger).Info(string.Format(format, parameters));
        }

        /// <summary>
        /// Warns the specified logger.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Warn(string logger, string message, Exception exception = null)
        {
            if (exception != null)
                GetLogger(logger).Warn(message, exception);
            else
                GetLogger(logger).Warn(message);
        }

        /// <summary>
        /// Warns the specified logger.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="format">The format.</param>
        /// <param name="parameters">The parameters.</param>
        public void Warn(string logger, Exception exception, string format, params object[] parameters)
        {
            if (exception != null)
                GetLogger(logger).Warn(string.Format(format, parameters), exception);
            else
                GetLogger(logger).Warn(string.Format(format, parameters));
        }

        /// <summary>
        /// Errors the specified logger.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Error(string logger, string message, Exception exception = null)
        {
            if (exception != null)
                GetLogger(logger).Error(message, exception);
            else
                GetLogger(logger).Error(message);
        }

        /// <summary>
        /// Errors the specified logger.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="format">The format.</param>
        /// <param name="parameters">The parameters.</param>
        public void Error(string logger, Exception exception, string format, params object[] parameters)
        {
            if (exception != null)
                GetLogger(logger).Error(string.Format(format, parameters), exception);
            else
                GetLogger(logger).Error(string.Format(format, parameters));
        }

        /// <summary>
        /// Fatals the specified logger.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Fatal(string logger, string message, Exception exception = null)
        {
            if (exception != null)
                GetLogger(logger).Fatal(message, exception);
            else
                GetLogger(logger).Fatal(message);
        }

        /// <summary>
        /// Fatals the specified logger.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="format">The format.</param>
        /// <param name="parameters">The parameters.</param>
        public void Fatal(string logger, Exception exception, string format, params object[] parameters)
        {
            if (exception != null)
                GetLogger(logger).Fatal(string.Format(format, parameters), exception);
            else
                GetLogger(logger).Fatal(string.Format(format, parameters));
        }
    }
}
