using System.Collections.Generic;
using System.ServiceModel;
using VersInformer.Common.Entities.Users;

namespace VersInformer.Common.ServiceInterfaces
{
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IUserService
    {
        [OperationContract]
        IList<SEUser> GetOnlineUsers();


    }
}