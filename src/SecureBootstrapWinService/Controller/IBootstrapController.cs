using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureBootstrapWinService.Message.Request;
using SecureBootstrapWinService.Message.Response;

namespace SecureBootstrapWinService.Controller
{
    public interface IBootstrapController
    {
        // TODO: Isolate params to non dynamic
        Task<NewBootstrapReqResponse> CreateNewBootstrapRequestAsync(NewBootstrapRequest req);
        Task<GetBootstrapReqResponse> GetBootstrapRequestAsync(GetBootstrapRequest req);
    }
}
