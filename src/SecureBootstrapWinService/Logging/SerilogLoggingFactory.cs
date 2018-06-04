using SecureBootstrapWinService.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureBootstrapWinService.Logging
{
    public class SerilogLoggingFactory : ILogFactory
    {
        private IConfiguration _cfg;

        public SerilogLoggingFactory(IConfiguration _cfg)
        {
            this._cfg = _cfg;
        }

        public string FactoryName
        {
            get { return "SerilogLoggingFactory"; }
        }

        public IGenericLoggingScope NewScope(string scopeName, Type typeDef)
        {
            return new SerilogLoggingScope(_cfg, scopeName, typeDef);
        }

        public IGenericLoggingScope NewScope(string scopeName)
        {
            return new SerilogLoggingScope(_cfg, scopeName, null);
        }


        public IGenericLoggingScope NewScope<T>(string scopeName, object scopeData)
        {
            return new SerilogLoggingScope(_cfg, scopeName, this.GetType(), scopeData);
        }

        public IGenericLoggingScope NewScope<T>(string scopeName)
        {
            return new SerilogLoggingScope(_cfg, scopeName, null);
        }
    }
}
