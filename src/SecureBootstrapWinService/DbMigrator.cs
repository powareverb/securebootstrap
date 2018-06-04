using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureBootstrapWinService
{
    public class DbMigrator
    {
        //public DbMigrator(IMigrationRunner run)
        //{

        //}

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
        //private void UpdateDatabase(IServiceProvider serviceProvider)
        //{
        //    // Instantiate the runner
        //    var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

        //    // Execute the migrations
        //    runner.MigrateUp();
        //}
    }
}
