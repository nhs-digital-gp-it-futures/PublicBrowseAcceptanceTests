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
        internal IWebDriver driver;
        internal PageActionCollection Pages;
        internal Solution solution;
        internal SolutionDetail solutionDetail;
        internal string Url;

        public UITest()
        {
            var (serverUrl, databaseName, dbUser, dbPassword) = EnvironmentVariables.GetDbConnectionDetails();
            ConnectionString = string.Format(Utils.ConnectionString.GPitFutures, serverUrl, databaseName, dbUser,
                dbPassword);
            AzureBlobStorage = new AzureBlobStorage(EnvironmentVariables.GetAzureBlobStorageConnectionString());
            DefaultAzureBlobStorageContainerName = EnvironmentVariables.GetAzureContainerName();
            DownloadPath = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "downloads");

            Url = EnvironmentVariables.GetUrl();

            driver = new BrowserFactory().Driver;

            Pages = new PageActions(driver).PageActionCollection;

            driver.Navigate().GoToUrl(Url);
        }
    }
}