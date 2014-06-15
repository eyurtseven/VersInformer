using System.Collections.Generic;
using System.ServiceModel;
using VersInformer.Service.Entity;

namespace VersInformer.Service.Abstract
{
    public interface IVersInformerCallback
    {
        [OperationContract(IsOneWay = true)]
        void RefreshClients(List<Client> clients);

        [OperationContract(IsOneWay = true)]
        void OnMessage(Message msg); 

        [OperationContract(IsOneWay = true)]
        void UserJoin(Client client);

        [OperationContract(IsOneWay = true)]
        void UserLeave(Client client);

        [OperationContract(IsOneWay = true)]
        void OnVersiyonAlinacak();
        
        [OperationContract(IsOneWay = true)]
        void OnVersiyonAliniyor();

        [OperationContract(IsOneWay = true)]
        void OnVersiyonTesteHazir();

        [OperationContract(IsOneWay = true)]
        void OnVersiyonAlindi();
        [OperationContract(IsOneWay = true)]
        void OnAciktikArtik();

    }

}
