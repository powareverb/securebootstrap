using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;
using SecureBootstrapWinService.Injection;
using SimpleInjector;

namespace SecureBootstrapWinService.NancyHelpers
{
    public class CustomNancyBootstrapper : DefaultNancyBootstrapper
    {
        IRootPathProvider rootProvider;

        protected override void ConfigureConventions(NancyConventions conventions)
        {
            rootProvider = new SelfHostRootPathProvider();
            base.ConfigureConventions(conventions);

            //conventions.StaticContentsConventions.AddDirectory("content");
        }

        protected override void ApplicationStartup(TinyIoCContainer nancy, IPipelines pipelines)
        {
            // Create Simple Injector container
            Container container = new Container();
            PackageExtensions.RegisterPackages(container, System.AppDomain.CurrentDomain.GetAssemblies());
            //container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();

            // Register application components here, e.g.:
            //container.Register(typeof(ICommandHandler<>), AppDomain.CurrentDomain.GetAssemblies());

            // Register Nancy modules.
            foreach (var nancyModule in this.Modules) container.Register(nancyModule.ModuleType);

            // Cross-wire Nancy abstractions that application components require (if any). e.g.:
            //container.Register(nancy.Resolve<IModelValidator>);

            // Check the container.
            container.Verify();

            // Hook up Simple Injector in the Nancy pipeline.
            nancy.Register(typeof(INancyModuleCatalog), new SimpleInjectorModuleCatalog(container));
            nancy.Register(typeof(INancyContextFactory), new Injection.SimpleInjectorScopedContextFactory(
                container, nancy.Resolve<INancyContextFactory>()));

            rootProvider = container.GetInstance<IRootPathProvider>();
        }
        protected override IRootPathProvider RootPathProvider
        {
            get { return rootProvider; }
        }
    }
}
