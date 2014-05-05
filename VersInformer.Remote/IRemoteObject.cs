using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersInformer.Remote
{
    public interface IRemoteObject
    {
        event MessageArrivedEvent MessageArrived;
        void SendMessage(string message);
    }
}
