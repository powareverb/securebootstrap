using SecureBootstrapWinService.Configuration;
using SecureBootstrapWinService.Controller;
using SecureBootstrapWinService.Logging;
using SecureBootstrapWinService.NancyHelpers;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace SecureBootstrapWinService.Injection
{
    public class SecureBootstrapPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            // Nancy
            container.Register<Nancy.IRootPathProvider, SelfHostRootPathProvider>();
            container.Register<IConfiguration>(() => { return new ConfigurationManager().LoadConfiguration(); }, Lifestyle.Singleton);
            container.Register<ISecureBootstrapListenerService, SecureBootstrapListenerService>();
            container.Register<ILogFactory, Logging.SerilogLoggingFactory>();
            container.Register<IBootstrapController, BootstrapController>();
            container.Register<IDBController, DBController>();
            //container.Register<ISessionManager, GatewaySessionManager>();
        }
    }
}
