using System;
using System.Runtime.Serialization;

namespace VersInformer.Service.Entity
{
    [DataContract]
    public class Client
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime Time { get; set; }
    }
}
