using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureBootstrapWinService.Message.Request
{
    public class NewBootstrapRequest
    {
        public string ClusterName { get; internal set; }
        public string NodeName { get; internal set; }
        public string MachineId { get; internal set; }
    }
}
