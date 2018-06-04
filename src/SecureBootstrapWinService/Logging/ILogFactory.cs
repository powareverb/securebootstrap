namespace SecureBootstrapWinService.Logging
{
    public interface ILogFactory
    {
        IGenericLoggingScope NewScope<T>(string scopeName);
    }
}
