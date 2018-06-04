using SecureBootstrap.Data;
using SecureBootstrapWinService.Configuration;
using Simple.Data;
using System;

namespace SecureBootstrapWinService.Controller
{
    public class DBController : IDBController
    {
        private IConfiguration _cfg;

        public DBController(IConfiguration cfg)
        {
            this._cfg = cfg;
        }

        public BootstrapRequest PutRequest(BootstrapRequest reqItem)
        {
            var db = Database.Opener.OpenFile(_cfg.DatabaseConnection);
            var employee = db.BootstrapRequest.Insert(reqItem);
            return reqItem;
        }
    }
}
