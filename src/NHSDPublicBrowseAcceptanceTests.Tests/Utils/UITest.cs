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
        internal Settings Settings;

        public UITest(Settings settings, BrowserFactory browserFactory)
        {
            Settings = settings;

            ConnectionString = settings.DatabaseSettings.ConnectionString;
            AzureBlobStorage = new AzureBlobStorage(settings.AzureBlobStorageSettings.ConnectionString);

            DefaultAzureBlobStorageContainerName = settings.AzureBlobStorageSettings.ContainerName;
            DownloadPath = settings.DownloadPath;
            Url = settings.PbUrl;

            Driver = browserFactory.Driver;

            Pages = new PageActions(Driver).PageActionCollection;

            Driver.Navigate().GoToUrl(Url);
        }
    }
}
