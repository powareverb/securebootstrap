using SecureBootstrapWinService.Configuration;
using Topshelf;
using SimpleInjector;
using Topshelf.SimpleInjector;
using System;

namespace SecureBootstrapWinService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var cnt = new SimpleInjector.Container();
                PackageExtensions.RegisterPackages(cnt, System.AppDomain.CurrentDomain.GetAssemblies());

                //
                //var options = new OptionSet {
                //    { "instance=", "append a tag onto the instance name, to allow multiple services to run", (string r) => cfg.ApplicationInstanceId = r },
                //};
                //var test = options.Parse(args);

                HostFactory.Run(c =>
                {
                    var cfg = cnt.GetInstance<IConfiguration>();
                    c.UseSimpleInjector(cnt);

                    // TODO: Will need to change this to run as user later...
                    c.RunAsLocalSystem();
                    var instanceOverride = cfg.ApplicationInstanceName;
                    var serviceDisplayName = string.Format("{0} - {1}", cfg.ApplicationName, instanceOverride);
                    var serviceName = string.Format("{0} - {1}", cfg.ApplicationName, instanceOverride);
                    var serviceDescription = string.Format("{0} - {1}", cfg.ApplicationName, instanceOverride);

                    c.SetDisplayName(serviceDisplayName);
                    c.SetServiceName(serviceName);
                    c.SetDescription(serviceDescription);
                    c.EnableServiceRecovery(rc =>
                    {
                        rc.RestartService(1); // restart the service after 1 minute
                        rc.RestartService(2); // restart the service after 2 minute
                        rc.RestartService(3); // restart the service after 3 minute
                        rc.SetResetPeriod(1); // set the reset interval to one day
                    });
                    c.Service<ISecureBootstrapListenerService>(srv =>
                    {
                        srv.ConstructUsingSimpleInjector();
                        srv.WhenStarted((service) => service.Start());
                        srv.WhenStopped((service) => service.Stop());
                    });
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message} at {ex.StackTrace}");
            }
        }
    }
}
