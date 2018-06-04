using Nancy;
using SecureBootstrapWinService.Configuration;
using SecureBootstrapWinService.Controller;
using SecureBootstrapWinService.Logging;
using SecureBootstrapWinService.Message.Request;
using SecureBootstrapWinService.Message.Response;

namespace SecureBootstrapWinService.NancyModules
{
    public class RequestBootstrapModule : NancyModule
    {
        private readonly IRootPathProvider _pathProvider;
        private readonly IConfiguration _cfg;
        private readonly IGenericLoggingScope _logger;
        private readonly IBootstrapController _controller;

        public const string UrlPrefixBootstrap = "/bootstrap";

        public RequestBootstrapModule(IConfiguration config, IRootPathProvider pathProvider, ILogFactory log, IBootstrapController bootstrap)
        {
            this._pathProvider = pathProvider;
            this._cfg = config;
            this._logger = log.NewScope<RequestBootstrapModule>("RequestBootstrapModule");
            //this._sess = sess;

            this._controller = bootstrap;

            this.Get[UrlPrefixBootstrap+"/new", true] = async (x, ct) =>
            {
                NewBootstrapRequest req = new NewBootstrapRequest()
                {
                };
                NewBootstrapReqResponse ret = await _controller.CreateNewBootstrapRequestAsync(req);
                return this.Response.AsJson(ret);
            };
            this.Get[UrlPrefixBootstrap + "/get/{requestId}", true] = async (x, ct) =>
            {
                GetBootstrapRequest req = new GetBootstrapRequest()
                {
                    RequestId = x.requestId
                };
                GetBootstrapReqResponse ret = await _controller.GetBootstrapRequestAsync(req);
                return this.Response.AsJson(ret);
            };
        }
    }
}
