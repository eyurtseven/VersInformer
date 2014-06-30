using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VersInformer.Common.Entities.Users
{
    [DataContract]
    public class SEUser
    {
        [DataMember(IsRequired = true)]
        public string UserName { get; set; }
        
        [DataMember(IsRequired = true)]
        public string NickName { get; set; }

        [DataMember(IsRequired = true)]
        public DateTime LastActivationDateTime { get; set; }
    }
}
