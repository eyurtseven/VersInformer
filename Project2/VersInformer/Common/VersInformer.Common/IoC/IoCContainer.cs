using System;
using SimpleInjector;
using SimpleInjector.Integration.Wcf;
using VersInformer.Common.CommonServices;
using VersInformer.Common.ServiceInterfaces;

namespace VersInformer.Common.IoC
{
    public class IoCContainer
    {
        // ReSharper disable once InconsistentNaming
        private static readonly IoCContainer _singletonInstance = new IoCContainer();
        private readonly Container _container;

        /// <summary>
        /// Prevents a default instance of the <see cref="IoCContainer"/> class from being created.
        /// </summary>
        private IoCContainer()
        {
            // Create the container as usual.
            _container = new Container();

            // default registarations 
            _container.RegisterSingle<ILoggingService, Log4NetLoggingService>();

        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static IoCContainer Instance
        {
            get { return _singletonInstance; }
        }

        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public Container Container { get { return _container; } }

        /// <summary>
        /// Registers the specified registration action.
        /// </summary>
        /// <param name="registrationAction">The registration action.</param>
        /// <returns></returns>
        public Container Register(Action<Container> registrationAction)
        {
            registrationAction(_container);
            return _container;
        }

        /// <summary>
        /// Verifies this instance.
        /// </summary>
        public void Verify()
        {
            _container.Verify();
        }

        /// <summary>
        /// Injects the WCF.
        /// </summary>
        public void InjectWcf()
        {
            // Register the container to the SimpleInjectorServiceHostFactory.
            SimpleInjectorServiceHostFactory.SetContainer(_container);
        }

        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>() where T : class
        {
            return _container.GetInstance<T>();
        }
    }
}
