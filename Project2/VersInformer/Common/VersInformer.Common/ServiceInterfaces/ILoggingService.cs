using System;
using System.ServiceModel;

namespace VersInformer.Common.ServiceInterfaces
{
    [ServiceContract]
    public interface ILoggingService
    {
        [OperationContract]
        void Debug(string logger, string message, Exception exception = null);

        [OperationContract]
        void Debug(string logger, Exception exception, string format, params object[] parameters);


        [OperationContract]
        void Info(string logger, string message, Exception exception = null);

        [OperationContract]
        void Info(string logger, Exception exception, string format, params object[] parameters);


        [OperationContract]
        void Warn(string logger, string message, Exception exception = null);

        [OperationContract]
        void Warn(string logger, Exception exception, string format, params object[] parameters);


        [OperationContract]
        void Error(string logger, string message, Exception exception = null);

        [OperationContract]
        void Error(string logger, Exception exception, string format, params object[] parameters);


        [OperationContract]
        void Fatal(string logger, string message, Exception exception = null);

        [OperationContract]
        void Fatal(string logger, Exception exception, string format, params object[] parameters);

    }
}