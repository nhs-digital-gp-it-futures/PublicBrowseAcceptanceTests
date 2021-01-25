namespace NHSDPublicBrowseAcceptanceTests.Tests.Utils
{
    using System;
    using System.IO;
    using Microsoft.Extensions.Configuration;

    public class Settings
    {
        public Settings(IConfiguration config)
        {
            HubUrl = config.GetValue<string>("hubUrl");
            PublicBrowseUrl = config.GetValue<string>("pbUrl");
            DownloadPath = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), config.GetValue<string>("downloadDirectory"));
            Browser = config.GetValue<string>("browser");
            DatabaseSettings = SetUpDatabaseSettings(config);
        }

        public string HubUrl { get; }

        public string PublicBrowseUrl { get; }

        public string DownloadPath { get; }

        public string Browser { get; }

        public DatabaseSettings DatabaseSettings { get; }

        private static string ConnectionStringTemplate => @"Server={0};Initial Catalog={1};Persist Security Info=false;User Id={2};Password={3}";

        private static DatabaseSettings SetUpDatabaseSettings(IConfiguration config)
        {
            var databaseSettings = config.GetSection("db").Get<DatabaseSettings>();
            databaseSettings.ConnectionString = ConstructDatabaseConnectionString(
                databaseSettings.ServerUrl,
                databaseSettings.DatabaseName,
                databaseSettings.User,
                databaseSettings.Password);
            return databaseSettings;
        }

        private static string ConstructDatabaseConnectionString(string serverUrl, string databaseName, string user, string password)
        {
            return string.Format(ConnectionStringTemplate, serverUrl, databaseName, user, password);
        }
    }
}
