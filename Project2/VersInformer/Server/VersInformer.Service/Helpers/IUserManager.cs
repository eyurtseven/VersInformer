using System.Collections.Generic;
using VersInformer.Common.Entities.Users;

namespace VersInformer.Service.Helpers
{
    public interface IUserManager
    {
        void SetUserOnline(string userName);
        IList<SEUser> GetOnlineUsers();
        bool Validate(string userName, string password);
    }
}