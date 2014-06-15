using System.ServiceModel;
using VersInformer.Service.Entity;

namespace VersInformer.Service.Abstract
{
    [ServiceContract(CallbackContract = typeof(IVersInformerCallback), SessionMode = SessionMode.Required)]
    public interface IVersInformer
    {
        [OperationContract(IsInitiating = true)]
        bool Connect(Client client);

        [OperationContract(IsOneWay = true, IsTerminating = true)]
        void Disconnect(Client client);

        [OperationContract(IsOneWay = true)]
        void SendMessage(Message msg);

        [OperationContract(IsOneWay = true)]
        void VersiyonAliniyor();

        [OperationContract(IsOneWay = true)]
        void VersiyonAlinacak();

        [OperationContract(IsOneWay = true)]
        void VersiyonTesteHazir();

        [OperationContract(IsOneWay = true)]
        void VersiyonAlindi();

        [OperationContract(IsOneWay = true)]
        void YemekListesi();

    }
}
