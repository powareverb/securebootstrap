using Microsoft.Extensions.DependencyInjection;
using Nancy.Hosting.Self;
using SecureBootstrapWinService.Configuration;
using SecureBootstrapWinService.Controller;
using SecureBootstrapWinService.Logging;
using System;

namespace SecureBootstrapWinService
{
    class SecureBootstrapListenerService : ISecureBootstrapListenerService
    {
        IConfiguration _cfg;
        private IGenericLoggingScope _logger;
        private IDBController _db;
        private NancyHost _nancyHost;

        public SecureBootstrapListenerService(IConfiguration cfg, ILogFactory log, IDBController db)
        {
            this._cfg = cfg;
            this._logger = log.NewScope<SecureBootstrapListenerService>("SecurityGatewayListenerService");
            _db = db;
        }

        public void Start()
        {
            var serviceName = _cfg.ApplicationInstanceName;
            this._logger.Information($"The {serviceName} service is starting on '{_cfg.ApplicationHostUrl}'.");
            HostConfiguration hostConfiguration = new HostConfiguration();
            hostConfiguration.UrlReservations.CreateAutomatically = true;
            hostConfiguration.RewriteLocalhost = true;

            // Do the DB migrations?

            this._nancyHost = new NancyHost(hostConfiguration, new Uri(_cfg.ApplicationHostUrl));
            this._nancyHost.Start();

        }

        public void Stop()
        {
            var serviceName = _cfg.ApplicationInstanceName;
            this._logger.Information($"The {serviceName} service is stopping.");
            this._nancyHost.Stop();
            this._nancyHost.Dispose();
        }


        /// <summary>
        /// Configure the dependency injection services
        /// </sumamry>
        //private static IServiceProvider CreateServices()
        //{
        //    return new ServiceCollection()
        //        // Add common FluentMigrator services
        //        .AddFluentMigratorCore()
        //        .ConfigureRunner(rb => rb
        //            // Add SQLite support to FluentMigrator
        //            .AddSQLite()
        //            // Set the connection string
        //            .WithGlobalConnectionString("Data Source=test.db")
        //            // Define the assembly containing the migrations
        //            .ScanIn(typeof(AddLogTable).Assembly).For.Migrations())
        //        // Enable logging to console in the FluentMigrator way
        //        .AddLogging(lb => lb.AddFluentMigratorConsole())
        //        // Build the service provider
        //        .BuildServiceProvider(false);
        //}

        /// <summary>
        /// Update the database
        /// </sumamry>
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
        }
    }
}
