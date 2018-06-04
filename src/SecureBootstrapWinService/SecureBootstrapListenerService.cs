using Nancy.Hosting.Self;
using SecureBootstrapWinService.Configuration;
using SecureBootstrapWinService.Logging;
using System;

namespace SecureBootstrapWinService
{
    class SecureBootstrapListenerService : ISecureBootstrapListenerService
    {
        IConfiguration _cfg;
        private IGenericLoggingScope _logger;
        private NancyHost _nancyHost;

        public SecureBootstrapListenerService(IConfiguration cfg, Logging.ILogFactory log)
        {
            this._cfg = cfg;
            this._logger = log.NewScope<SecureBootstrapListenerService>("SecurityGatewayListenerService");
        }

        public void Start()
        {
            var serviceName = _cfg.ApplicationInstanceName;
            this._logger.Information($"The {serviceName} service is starting on '{_cfg.ApplicationHostUrl}'.");
            HostConfiguration hostConfiguration = new HostConfiguration();
            hostConfiguration.UrlReservations.CreateAutomatically = true;
            hostConfiguration.RewriteLocalhost = true;
            this._nancyHost = new NancyHost(hostConfiguration, new Uri(_cfg.ApplicationHostUrl));
            this._nancyHost.Start();
        }

        public void Stop()
        {
            var serviceName = _cfg.ApplicationInstanceName;
            this._logger.Information($"The {serviceName} service is stopping.");
            this._nancyHost.Stop();
            this._nancyHost.Dispose();
        }
    }
}
