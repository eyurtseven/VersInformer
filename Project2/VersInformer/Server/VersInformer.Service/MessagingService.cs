using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersInformer.Common.Entities.Messaging;
using VersInformer.Common.ServiceInterfaces;

namespace VersInformer.Service
{
    public class MessagingService : IMessagingService
    {
        public IList<SEMessage> GetMessages(DateTime starTime)
        {
            throw new NotImplementedException();
        }

        public IList<SEMessage> SendMessageAndGetMessages(string messageText, DateTime starTime)
        {
            throw new NotImplementedException();
        }
    }
}
