using Microsoft.Extensions.Configuration;
using NHSDPublicBrowseAcceptanceTests.Actions;
using NHSDPublicBrowseAcceptanceTests.Actions.Pages;
using NHSDPublicBrowseAcceptanceTests.TestData.Azure;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Utils
{
    public sealed class UITest
    {
        internal AzureBlobStorage AzureBlobStorage;
        internal string ConnectionString;
        internal List<SolutionContactDetails> ContactDetails = new List<SolutionContactDetails>();
        internal string DefaultAzureBlobStorageContainerName;
        internal string DownloadPath;
        internal IWebDriver Driver;
        internal PageActionCollection Pages;
        internal Solution Solution;
        internal CatalogueItem CatalogueItem;
        internal string Url;

        public UITest()
        {
            var settings = GetSettings();

            ConnectionString = settings.DatabaseSettings.ConnectionString;
            AzureBlobStorage = new AzureBlobStorage(settings.AzureBlobStorageSettings.ConnectionString);

            DefaultAzureBlobStorageContainerName = settings.AzureBlobStorageSettings.ContainerName;
            DownloadPath = settings.DownloadPath;
            Url = settings.PbUrl;

            Driver = new BrowserFactory(settings).Driver;

            Pages = new PageActions(Driver).PageActionCollection;

            Driver.Navigate().GoToUrl(Url);
        }

        private static Settings GetSettings()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            return new Settings(configurationBuilder);
        }


    }
}
