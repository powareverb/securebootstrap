using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureBootstrapWinService.Message.Request
{
    public class GetBootstrapRequest
    {
        public Guid RequestId { get; internal set; }
    }
}
