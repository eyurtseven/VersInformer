using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using VersInformer.Service.Abstract;
using VersInformer.Service.Entity;

namespace VersInformer.Service.Concrete
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
    ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class VersInformerService : IVersInformer
    {
        readonly Dictionary<Client, IVersInformerCallback> _clients = new Dictionary<Client, IVersInformerCallback>();

        readonly List<Client> _clientList = new List<Client>();

        public IVersInformerCallback CurrentCallback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IVersInformerCallback>();

            }
        }

        readonly object _syncObj = new object();

        private bool SearchClientsByName(string name)
        {
            return _clients.Keys.Any(c => c.Name == name);
        } 

        public bool Connect(Client client)
        {
            if (_clients.ContainsValue(CurrentCallback) || SearchClientsByName(client.Name)) return false;
            lock (_syncObj)
            {
                _clients.Add(client, CurrentCallback);
                _clientList.Add(client);

                foreach (var key in _clients.Keys)
                {
                    var callback = _clients[key];
                    try
                    {
                        callback.RefreshClients(_clientList);
                        callback.UserJoin(client);
                    }
                    catch
                    {
                        _clients.Remove(key);
                        return false;
                    }

                }

            }
            return true;
        }

        public void SendMessage(Message msg)
        {
            lock (_syncObj)
            {
                foreach (var callback in _clients.Values)
                {
                    callback.OnMessage(msg);
                }
            }
        }

        public void VersiyonAliniyor()
        {
            lock (_syncObj)
            {
                foreach (var callback in _clients.Values)
                {
                    callback.OnVersiyonAliniyor();
                }
            }
        }

        public void VersiyonAlinacak()
        {
            lock (_syncObj)
            {
                foreach (var callback in _clients.Values)
                {
                    callback.OnVersiyonAlinacak();
                }
            }
        }

        public void VersiyonTesteHazir()
        {
            lock (_syncObj)
            {
                foreach (var callback in _clients.Values)
                {
                    callback.OnVersiyonTesteHazir();
                }
            }
        }

        public void VersiyonAlindi()
        {
            lock (_syncObj)
            {
                foreach (var callback in _clients.Values)
                {
                    callback.OnVersiyonAlindi();
                }
            }
        }

        public void YemekListesi()
        {
            lock (_syncObj)
            {
                foreach (var callback in _clients.Values)
                {
                    callback.OnAciktikArtik();
                }
            }
        }

        public void Disconnect(Client client)
        {
            foreach (var c in _clients.Keys.Where(c => client.Name == c.Name))
            {
                lock (_syncObj)
                {
                    _clients.Remove(c);
                    _clientList.Remove(c);
                    foreach (IVersInformerCallback callback in _clients.Values)
                    {
                        callback.RefreshClients(_clientList);
                        callback.UserLeave(client);
                    }
                }
                return;
            }
        }
    }
}
