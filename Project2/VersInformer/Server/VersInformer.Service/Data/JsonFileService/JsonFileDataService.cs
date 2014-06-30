using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using AutoMapper;
using Newtonsoft.Json;
using VersInformer.Common;
using VersInformer.Common.Entities.Users;
using VersInformer.Common.ServiceInterfaces;
using VersInformer.Service.Data.JsonFileService.Entities;

namespace VersInformer.Service.Data.JsonFileService
{
    internal class JsonFileDataService : IUserDataService
    {
        private const string UsersFileName = "data\\users.json";
        private readonly ILoggingService _loggingService;
        private readonly ConcurrentDictionary<string, JEUser> _users = new ConcurrentDictionary<string, JEUser>();
        private static string _usersFileFileName;

        public JsonFileDataService(ILoggingService loggingService)
        {
            loggingService.Info(CommonConstants.PerformanceLoggerName, "JsonFileDataService Constructor Starting");
            
            _loggingService = loggingService;
            ReadUsersToFile(_loggingService, _users);

            loggingService.Info(CommonConstants.PerformanceLoggerName, "JsonFileDataService Constructor Ended");        
        }


        /// <summary>
        /// Gets the name of the user by user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public SEUser GetUserByUserName(string userName)
        {
            try
            {
                _loggingService.Info(CommonConstants.PerformanceLoggerName, "JsonFileDataService.GetUserByUserName Starting");
                JEUser user;
                return _users.TryGetValue(userName, out user) ? Mapper.Map<SEUser>(user) : null;
            }
            finally
            {
                _loggingService.Info(CommonConstants.PerformanceLoggerName, "JsonFileDataService.GetUserByUserName Ended");                
            }
        }

        /// <summary>
        /// Validates the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool Validate(string userName, string password)
        {
            try
            {
                _loggingService.Info(CommonConstants.PerformanceLoggerName, "JsonFileDataService.Validate Starting");
                JEUser user;
                return _users.TryGetValue(userName, out user) && user.PasswordHash.SequenceEqual(password.CalculateMd5());
            }
            finally
            {
                _loggingService.Info(CommonConstants.PerformanceLoggerName, "JsonFileDataService.Validate Ended");                                
            }
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="UserExistsException"></exception>
        public SEUser CreateUser(SEUser user, string password)
        {
            try
            {
                _loggingService.Info(CommonConstants.PerformanceLoggerName, "JsonFileDataService.CreateUser Starting");
                var user2 = Mapper.Map<JEUser>(user);
                user2.PasswordHash = password.CalculateMd5();

                _users.AddOrUpdate(user.UserName, user2, (s, jeUser) => { throw new UserExistsException(s); });

                SaveUserToFile(_loggingService, _users);

                return user;
            }
            finally
            {
                _loggingService.Info(CommonConstants.PerformanceLoggerName, "JsonFileDataService.CreateUser Ended");                                                
            }
        }


        #region Private Methods

        /// <summary>
        /// Reads the users to file.
        /// </summary>
        private static void ReadUsersToFile(ILoggingService loggingService, ConcurrentDictionary<string, JEUser> users)
        {
            loggingService.Info(CommonConstants.PerformanceLoggerName, "JsonFileDataService.ReadUsersToFile Starting");
            int userCount = 0;
            // ReSharper disable once AssignNullToNotNullAttribute
            _usersFileFileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), UsersFileName);
            var usersFileDirectoryName = Path.GetDirectoryName(_usersFileFileName);

            if (usersFileDirectoryName != null && !Directory.Exists(usersFileDirectoryName)) Directory.CreateDirectory(usersFileDirectoryName);

            if (File.Exists(_usersFileFileName))
            {
                var content = File.ReadAllText(_usersFileFileName);
                if (!string.IsNullOrWhiteSpace(content))
                {
                    var uss = JsonConvert.DeserializeObject<JEUser[]>(content);
                    if (uss != null)
                    {
                        foreach (var user in uss)
                        {
                            userCount++;
                            users.AddOrUpdate(user.UserName, user, (s, jeUser) => Mapper.Map(user, jeUser));
                        }
                    }
                }
            }
            loggingService.Info(CommonConstants.PerformanceLoggerName, null, "JsonFileDataService.ReadUsersToFile Ended. Read {0} user(s).", userCount);
        }


        private static void SaveUserToFile(ILoggingService loggingService, ConcurrentDictionary<string, JEUser> users)
        {
            loggingService.Info(CommonConstants.PerformanceLoggerName, "JsonFileDataService.SaveUserToFile started");
            lock (typeof(JsonFileDataService))
            {
                File.WriteAllText(_usersFileFileName, JsonConvert.SerializeObject(users.Select(x => x.Value).ToArray()));
            }
            loggingService.Info(CommonConstants.PerformanceLoggerName, null, "JsonFileDataService.SaveUserToFile Ended. Wrote {0} user(s).", users.Count);
        }
        #endregion



        #region Static Constructor

        /// <summary>
        /// Initializes the <see cref="JsonFileDataService"/> class. Initialize Automapper registrations.
        /// </summary>
        static JsonFileDataService()
        {
            Mapper.CreateMap<SEUser, JEUser>()
                .ForMember(d => d.PasswordHash, m => m.Ignore());

            Mapper.CreateMap<JEUser, SEUser>()
                .ForSourceMember(s => s.PasswordHash, m => m.Ignore());

        }

        #endregion
    }
}
