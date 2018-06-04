namespace SecureBootstrapWinService.Configuration
{
    public class ConfigurationManager
    {
        public IConfiguration LoadConfiguration()
        {
            var ret = new ConfigurationSettings();
            ret.ApplicationName = "SecureBootstrap";
            ret.ApplicationInstanceName = "SecureBootstrap";
            ret.ApplicationHostUrl = "http://localhost:9101";
            //ret.DatabaseConnection = @"Data Source=.\SQLExpress;Initial Catalog=SecureBootstrap;Integrated Security=True";
            ret.DatabaseConnection = @"SecureBootstrap.db";
            return ret;
        }
    }
}
