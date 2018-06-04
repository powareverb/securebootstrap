using System.Threading.Tasks;
using SecureBootstrapWinService.Message.Request;
using SecureBootstrapWinService.Message.Response;

namespace SecureBootstrapWinService.Controller
{
    public class BootstrapController : IBootstrapController
    {
        private IDBController db;

        public BootstrapController(IDBController db)
        {
            this.db = db;

        }

        public async Task<NewBootstrapReqResponse> CreateNewBootstrapRequestAsync(NewBootstrapRequest req)
        {
            // Do some prevalidation based on the request
            // Create new request ID, defaults
            // Save to DB
            // Trigger authentication request?
            var ret = new NewBootstrapReqResponse();
            var reqItem = new SecureBootstrap.Data.BootstrapRequest()
            {

            };
            var obj = this.db.PutRequest(reqItem);
            return ret;
        }

        public async Task<GetBootstrapReqResponse> GetBootstrapRequestAsync(GetBootstrapRequest req)
        {
            // Do some prevalidation based on the request
            // Get from DB
            // Trigger remove from DB?
            return new GetBootstrapReqResponse();
        }
    }
}
