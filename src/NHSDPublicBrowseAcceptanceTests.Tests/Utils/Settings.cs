using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Utils
{
    public class Settings
    {
        public string HubUrl { get; }
        public string PublicBrowseUrl { get; }
        public string DownloadPath { get; }
        public string Browser { get; }
        public AzureBlobStorageSettings AzureBlobStorageSettings { get; }
        public DatabaseSettings DatabaseSettings { get; }

        public Settings(IConfiguration config)
        {
            HubUrl = config.GetValue<string>("hubUrl");
            PublicBrowseUrl = config.GetValue<string>("pbUrl");
            DownloadPath = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), config.GetValue<string>("downloadDirectory"));
            Browser = config.GetValue<string>("browser");
            AzureBlobStorageSettings = config.GetSection("azureBlobStorage").Get<AzureBlobStorageSettings>();
            DatabaseSettings = SetUpDatabaseSettings(config);
        }

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

        private static string ConstructDatabaseConnectionString(string serverUrl, string databaseName, string user, string password) =>
            string.Format(ConnectionStringTemplate, serverUrl, databaseName, user, password);

        private static string ConnectionStringTemplate => @"Server={0};Initial Catalog={1};Persist Security Info=false;User Id={2};Password={3}";
    }

    public class AzureBlobStorageSettings
    {
        public string ConnectionString { get; set; }
        public string ContainerName { get; set; }
    }

    public class DatabaseSettings
    {
        public string ServerUrl { get; set; }
        public string DatabaseName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string ConnectionString { get; set; }
    }
}