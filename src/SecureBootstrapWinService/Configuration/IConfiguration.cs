namespace SecureBootstrapWinService.Configuration
{
    public interface IConfiguration
    {
        string ApplicationInstanceName { get; }
        string ApplicationName { get; }
        string ApplicationHostUrl { get; }

        string DatabaseConnection { get; }
    }
}
