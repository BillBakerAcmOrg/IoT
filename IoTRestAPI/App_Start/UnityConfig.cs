using log4net;
using log4net.Config;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace IoTRestAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //container.RegisterInstance<ILog>(LogManager.GetLogger("foo.txt"));
            container.RegisterInstance<ILog>(IoTLogger.Logger);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
        public class IoTLogger
        {
            private static readonly ILog logger = LogManager.GetLogger(typeof(IoTLogger));

            public static ILog Logger { get { return logger; } }

            static IoTLogger()
            {
                XmlConfigurator.Configure();
            }

        }
    }
}