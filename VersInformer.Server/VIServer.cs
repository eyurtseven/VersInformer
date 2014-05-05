using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using VersInformer.Remote;

namespace VersInformer.Server
{
    public class VIServer : MarshalByRefObject, IRemoteObject
    {

        public event MessageArrivedEvent MessageArrived;

        public void SendMessage(string message)
        {
            InvokeMessage(message);
        }

        bool _isActive = false;
        public void StartServer(int port)
        {
            if (_isActive)
            {
                return;
            }

            var p = new Hashtable();
            p["port"] = port;
            p["name"] = _serverUri;

            var binaryServerFormatterSinkProvider = new BinaryServerFormatterSinkProvider();
            binaryServerFormatterSinkProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            _serverChannel = new TcpServerChannel(p, binaryServerFormatterSinkProvider);

            try
            {
                ChannelServices.RegisterChannel(_serverChannel, false);
                _obfRef = RemotingServices.Marshal(this, p["name"].ToString());
                _isActive = true;
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        public void StopServer()
        {
            if (!_isActive)
            {
                return;
            }
            RemotingServices.Unmarshal(_obfRef);
            RemotingServices.Disconnect(this);
            try
            {
                ChannelServices.UnregisterChannel(_serverChannel);
            }
            catch (Exception)
            {
            }
        }

        private void InvokeMessage(string message)
        {
            if (!_isActive || null == MessageArrived)
            {
                return;
            }

            MessageArrivedEvent listener = null;
            foreach (var del in MessageArrived.GetInvocationList())
            {
                try
                {
                    listener = del as MessageArrivedEvent;
                    if (listener != null)
                    {
                        listener.Invoke(message);
                    }
                }
                catch (Exception ex)
                {
                    MessageArrived -= listener;
                    throw ex;
                }
            }

        }

        TcpServerChannel _serverChannel;
        ObjRef _obfRef; 
        readonly string _serverUri = "versInformer.VI";

    }
}
