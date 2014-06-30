using System;
using System.Collections.Generic;
using VersInformer.Common;
using VersInformer.Common.Entities.Users;
using VersInformer.Common.ServiceInterfaces;
using VersInformer.Service.Helpers;

namespace VersInformer.Service
{
    public class UserService : IUserService
    {
        private readonly ILoggingService _loggingService;
        private readonly IUserManager _userManager;

        public UserService(ILoggingService loggingService, IUserManager userManager)
        {
            loggingService.Info(CommonConstants.PerformanceLoggerName, "UserService Constructor Starting");
            _loggingService = loggingService;
            _userManager = userManager;
            loggingService.Info(CommonConstants.PerformanceLoggerName, "UserService Constructor Ended");
        }

        public IList<SEUser> GetOnlineUsers()
        {
            try
            {
                _loggingService.Info(CommonConstants.PerformanceLoggerName, "UserService.GetOnlineUsers Starting");
                return _userManager.GetOnlineUsers();
            }
            finally
            {
                _loggingService.Info(CommonConstants.PerformanceLoggerName, "UserService.GetOnlineUsers Ended");                
            }
        }
    }
}