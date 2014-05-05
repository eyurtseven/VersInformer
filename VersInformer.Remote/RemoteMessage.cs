using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersInformer.Remote
{
    [Serializable]
    public class RemoteMessage
    {
        public string Type { get; set; }
        public string From { get; set; }
        public string Message { get; set; }
        public string Time { get; set; }
        public string Environment { get; set; }
        public string AfterMinutes { get; set; }
        public string Action { get; set; }
    }
}
