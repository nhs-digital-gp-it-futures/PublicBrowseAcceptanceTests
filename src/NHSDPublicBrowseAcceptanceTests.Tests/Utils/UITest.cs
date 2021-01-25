namespace NHSDPublicBrowseAcceptanceTests.Tests.Utils
{
    using System.Collections.Generic;
    using NHSDPublicBrowseAcceptanceTests.Actions;
    using NHSDPublicBrowseAcceptanceTests.Actions.Pages;
    using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
    using OpenQA.Selenium;

    public sealed class UITest
    {
        internal string ConnectionString;
        internal List<SolutionContactDetails> ContactDetails = new();
        internal IWebDriver Driver;
        internal PageActionCollection Pages;
        internal Solution Solution;
        internal CatalogueItem CatalogueItem;

        public UITest(Settings settings, BrowserFactory browserFactory)
        {
            ConnectionString = settings.DatabaseSettings.ConnectionString;

            var publicBrowseUrl = settings.PublicBrowseUrl;

            Driver = browserFactory.Driver;

            Pages = new PageActions(Driver).PageActionCollection;

            Driver.Navigate().GoToUrl(publicBrowseUrl);
        }
    }
}
