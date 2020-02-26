using NHSDPublicBrowseAcceptanceTests.Actions;
using NHSDPublicBrowseAcceptanceTests.Actions.Pages;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using OpenQA.Selenium;
using System.Collections.Generic;

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
        internal List<SolutionContactDetails> contactDetails = new List<SolutionContactDetails>();
        internal int expectedSolutionsCount;

        public UITest()
        {
            var (serverUrl, databaseName, dbUser, dbPassword) = EnvironmentVariables.GetDbConnectionDetails();
            ConnectionString = string.Format(Utils.ConnectionString.GPitFutures, serverUrl, databaseName, dbUser, dbPassword);

            Url = EnvironmentVariables.GetUrl();

            driver = new BrowserFactory().Driver;

            Pages = new PageActions(driver).PageActionCollection;

            driver.Navigate().GoToUrl(this.Url);
        }
    }
}
