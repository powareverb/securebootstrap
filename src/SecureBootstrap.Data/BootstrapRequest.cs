using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureBootstrap.Data
{
    public class BootstrapRequest
    {
        public Guid RequestId { get; set; }
        public string NodeName { get; set; }
        public string ClusterName { get; set; }
    }
}
