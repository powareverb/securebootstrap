using Nancy;
using SimpleInjector;

namespace SecureBootstrapWinService.Injection
{
    public sealed class SimpleInjectorScopedContextFactory : INancyContextFactory
    {
        private readonly Container container;
        private readonly INancyContextFactory defaultFactory;

        public SimpleInjectorScopedContextFactory(Container container, INancyContextFactory @default)
        {
            this.container = container;
            this.defaultFactory = @default;
        }

        public NancyContext Create(Request request)
        {
            var context = this.defaultFactory.Create(request);
            context.Items.Add("SimpleInjector.Scope", SimpleInjector.Lifestyles.AsyncScopedLifestyle.BeginScope(container));
            return context;
        }
    }
}
