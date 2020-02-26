using NHSDPublicBrowseAcceptanceTests.Actions;
using NHSDPublicBrowseAcceptanceTests.Actions.Pages;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Utils
{
    public sealed class UITest
    {
        internal IWebDriver driver;
        internal PageActionCollection pages;
        internal string connectionString;
        internal string url;
        internal int expectedSolutionsCount;
        internal Solution solution;
        internal SolutionDetail solutionDetail;
        internal List<SolutionContactDetails> contactDetails = new List<SolutionContactDetails>();
        internal NHSDPublicBrowseAcceptanceTests.TestData.Azure.AzureBlobStorage AzureBlobStorage;
        internal string DefaultAzureBlobStorageContainerName;
        internal string DownloadPath;

        public UITest()
        {
            var (serverUrl, databaseName, dbUser, dbPassword) = EnvironmentVariables.GetDbConnectionDetails();
            connectionString = string.Format(ConnectionString.GPitFutures, serverUrl, databaseName, dbUser, dbPassword);
            AzureBlobStorage = new NHSDPublicBrowseAcceptanceTests.TestData.Azure.AzureBlobStorage(EnvironmentVariables.GetAzureBlobStorageConnectionString());
            DefaultAzureBlobStorageContainerName = EnvironmentVariables.GetAzureContainerName();
            DownloadPath = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "downloads");

            url = EnvironmentVariables.GetUrl();

            driver = new BrowserFactory().Driver;

            pages = new PageActions(driver).PageActionCollection;

            driver.Navigate().GoToUrl(this.url);
        }
    }
}
