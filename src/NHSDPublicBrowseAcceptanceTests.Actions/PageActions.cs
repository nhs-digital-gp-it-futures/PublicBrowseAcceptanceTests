﻿namespace NHSDPublicBrowseAcceptanceTests.Actions
{
    using NHSDPublicBrowseAcceptanceTests.Actions.Pages;
    using OpenQA.Selenium;

    public sealed class PageActions
    {
        public PageActions(IWebDriver driver)
        {
            PageActionCollection = new PageActionCollection
            {
                SolutionsList = new SolutionsList(driver),
                CapabilityFilter = new CapabilityFilter(driver),
                Homepage = new Homepage(driver),
                Common = new Common(driver),
                Footer = new Footer(driver),
                Header = new Header(driver),
                BrowseSolutions = new BrowseSolutions(driver),
                ViewASolution = new ViewASolution(driver),
                BuyersGuide = new BuyersGuide(driver),
            };
        }

        public PageActionCollection PageActionCollection { get; set; }
    }
}