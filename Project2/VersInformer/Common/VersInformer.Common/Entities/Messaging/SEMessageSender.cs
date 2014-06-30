using System.Runtime.Serialization;

namespace VersInformer.Common.Entities.Messaging
{
    [DataContract]
    public class SEMessageSender
    {
        [DataMember(IsRequired = true)]
        public string UserName { get; set; }

        [DataMember(IsRequired = true)]
        public string NickName { get; set; }
    }
}