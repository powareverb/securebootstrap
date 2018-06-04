using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureBootstrapWinService.Configuration
{
    class ConfigurationSettings : IConfiguration
    {
        public string ApplicationInstanceName { get; internal set; }

        public string ApplicationName { get; internal set; }

        public string ApplicationHostUrl { get; internal set; }

        public string DatabaseConnection { get; internal set; }
    }
}
