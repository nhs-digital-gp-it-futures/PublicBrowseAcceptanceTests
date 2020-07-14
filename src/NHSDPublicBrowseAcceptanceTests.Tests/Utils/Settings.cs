using Microsoft.Extensions.Configuration;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Utils
{
    public class Settings
    {
        public string HubUrl { get; }
        public string PbUrl { get; }

        public AzureBlobStorageSettings AzureBlobStorageSettings { get; }
        public DatabaseSettings DatabaseSettings { get; }

        public Settings(IConfiguration config)
        {
            HubUrl = config.GetValue<string>("hubUrl");
            PbUrl = config.GetValue<string>("pbUrl");
            AzureBlobStorageSettings = config.GetSection("azureBlobStorage").Get<AzureBlobStorageSettings>();
            DatabaseSettings = config.GetSection("db").Get<DatabaseSettings>();
        }


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
    }

}