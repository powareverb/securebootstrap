using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureBootstrap.Data;

namespace SecureBootstrapWinService.Controller
{
    public interface IDBController
    {
        BootstrapRequest PutRequest(BootstrapRequest reqItem);
    }
}
