﻿using NHSDPublicBrowseAcceptanceTests.Actions;
using NHSDPublicBrowseAcceptanceTests.Actions.Pages;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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

        public UITest()
        {
            var (serverUrl, databaseName, dbUser, dbPassword) = EnvironmentVariables.GetDbConnectionDetails();
            connectionString = string.Format(ConnectionString.GPitFutures, serverUrl, databaseName, dbUser, dbPassword);

            url = EnvironmentVariables.GetUrl();

            driver = new BrowserFactory().Driver;

            pages = new PageActions(driver).PageActionCollection;

            driver.Navigate().GoToUrl(this.url);
        }
    }
}
