using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using VersInformer.Common.Entities.Messaging;

namespace VersInformer.Common.ServiceInterfaces
{
    [ServiceContract]
    public interface IMessagingService
    {
        [OperationContract]
        IList<SEMessage> GetMessages(DateTime starTime);

        [OperationContract]
        IList<SEMessage> SendMessageAndGetMessages(string messageText, DateTime starTime);
    }
}
