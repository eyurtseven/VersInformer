using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VersInformer.Common.Entities.Messaging
{
    [DataContract]
    public class SEMessage
    {
        [DataMember(IsRequired = true)]
        public DateTime MessageDateTime { get; set; }

        [DataMember(IsRequired = true)]
        public SEMessageSender Sender { get; set; }

        [DataMember(IsRequired = true)]
        public string MessageText { get; set; }
    }
}
