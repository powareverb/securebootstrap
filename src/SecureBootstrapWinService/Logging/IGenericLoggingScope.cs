using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureBootstrapWinService.Logging
{
    public interface IGenericLoggingScope
    {
        void Information(string message);
    }
}
