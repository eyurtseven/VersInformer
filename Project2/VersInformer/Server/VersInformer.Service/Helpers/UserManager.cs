using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using VersInformer.Common.Entities.Users;
using VersInformer.Common.ServiceInterfaces;
using VersInformer.Service.Data;

namespace VersInformer.Service.Helpers
{
    /// <summary>
    /// User Manager Singleton Service
    /// </summary>
    internal class UserManager : IUserManager
    {
        private readonly ILoggingService _loggingService;
        private readonly IUserDataService _userDataService;

        /// <summary>
        /// The online users
        /// </summary>
        private readonly ConcurrentDictionary<string, SEUser> _onlineUsers = new ConcurrentDictionary<string, SEUser>();

        public UserManager(ILoggingService loggingService, IUserDataService userDataService)
        {
            _loggingService = loggingService;
            _userDataService = userDataService;
        }

        /// <summary>
        /// Sets the user online.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        public void SetUserOnline(string userName)
        {
            var u = _onlineUsers.GetOrAdd(userName, GetUserByUserName);
            if (u != null) u.LastActivationDateTime = DateTime.Now;
        }


        /// <summary>
        /// Gets the online users.
        /// </summary>
        /// <returns></returns>
        public IList<SEUser> GetOnlineUsers()
        {
            var lastTime = DateTime.Now.AddMinutes(-10);
            return _onlineUsers
                .Where(x => x.Value.LastActivationDateTime >= lastTime)
                .Select(x => x.Value)
                .ToList();
        }

        public SEUser GetUserByUserName(string userName)
        {
            return _userDataService.GetUserByUserName(userName);
        }

        public bool Validate(string userName, string password)
        {
            return _userDataService.Validate(userName, password);
        }
    }
}
