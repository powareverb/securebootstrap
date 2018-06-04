using SecureBootstrapWinService.Configuration;
using Serilog.Core;
using Serilog.Events;

namespace SecureBootstrapWinService.Logging
{
    internal class SecureBootstrapConfigurationEnricher : ILogEventEnricher
    {
        private IConfiguration _cfg;

        public SecureBootstrapConfigurationEnricher(IConfiguration cfg)
        {
            _cfg = cfg;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            
        }
    }
}