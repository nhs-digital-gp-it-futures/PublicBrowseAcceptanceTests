using NHSDPublicBrowseAcceptanceTests.Actions;
using NHSDPublicBrowseAcceptanceTests.Actions.Pages;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Utils
{
    public sealed class UITest
    {
        internal IWebDriver driver;
        internal PageActionCollection Pages;
        internal string ConnectionString;
        internal string Url;
        internal Solution solution;
        internal SolutionDetail solutionDetail;
        internal List<SolutionContactDetails> ContactDetails = new List<SolutionContactDetails>();
        internal TestData.Azure.AzureBlobStorage AzureBlobStorage;
        internal string DefaultAzureBlobStorageContainerName;
        internal string DownloadPath;

        public UITest()
        {
            var (serverUrl, databaseName, dbUser, dbPassword) = EnvironmentVariables.GetDbConnectionDetails();
            ConnectionString = string.Format(Utils.ConnectionString.GPitFutures, serverUrl, databaseName, dbUser, dbPassword);
            AzureBlobStorage = new TestData.Azure.AzureBlobStorage(EnvironmentVariables.GetAzureBlobStorageConnectionString());
            DefaultAzureBlobStorageContainerName = EnvironmentVariables.GetAzureContainerName();
            DownloadPath = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "downloads");

            Url = EnvironmentVariables.GetUrl();

            driver = new BrowserFactory().Driver;

            Pages = new PageActions(driver).PageActionCollection;

            driver.Navigate().GoToUrl(this.Url);
        }
    }
}
