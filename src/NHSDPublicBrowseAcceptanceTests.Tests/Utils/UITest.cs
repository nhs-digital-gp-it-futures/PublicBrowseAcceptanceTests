using System;
using System.Collections.Generic;
using System.IO;
using NHSDPublicBrowseAcceptanceTests.Actions;
using NHSDPublicBrowseAcceptanceTests.Actions.Pages;
using NHSDPublicBrowseAcceptanceTests.TestData.Azure;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using OpenQA.Selenium;

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
            ConnectionString = EnvironmentVariables.ConnectionString();
            AzureBlobStorage = new AzureBlobStorage(EnvironmentVariables.AzureBlobStorageConnectionString());
            
            DefaultAzureBlobStorageContainerName = EnvironmentVariables.AzureContainerName();
            DownloadPath = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "downloads");
            Url = EnvironmentVariables.Url();

            Driver = new BrowserFactory().Driver;

            Pages = new PageActions(Driver).PageActionCollection;

            Driver.Navigate().GoToUrl(Url);
        }
    }
}