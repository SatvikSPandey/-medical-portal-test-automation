using Microsoft.Extensions.Configuration;

namespace MedicalPortal.Tests.Utilities
{
    public static class ConfigReader
    {
        private static IConfiguration? _configuration;

        private static IConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .Build();
                }
                return _configuration;
            }
        }

        public static string BaseUrl => Configuration["BaseUrl"] ?? "https://the-internet.herokuapp.com";
        public static string Browser => Configuration["Browser"] ?? "chrome";
        public static int TimeoutSeconds => int.Parse(Configuration["TimeoutSeconds"] ?? "10");
    }
}