using SimpleInjector;
using VersInformer.Common.IoC;
using VersInformer.Service.Data;
using VersInformer.Service.Data.JsonFileService;

namespace VersInformer.Service.Helpers
{
    public static class InitializeHelper
    {
        private static readonly object LockObject = new object();

        public static void Initialize()
        {
            if (IsInitialized) return;
            lock (LockObject)
            {
                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                if (IsInitialized) return;
                IsInitialized = true;
                IoCContainer.Instance.Register(OnRegistrationAction);
            }
        }

        private static void OnRegistrationAction(Container container)
        {
            container.RegisterSingle<IUserManager, UserManager>();
            container.RegisterSingle<IUserDataService, JsonFileDataService>();
        }

        public static bool IsInitialized { get; private set; }
    }
}