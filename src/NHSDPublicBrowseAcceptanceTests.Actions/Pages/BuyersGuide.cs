using FluentAssertions;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    public sealed class BuyersGuide : Interactions
    {
        public BuyersGuide(IWebDriver driver) : base(driver)
        {
        }

        public void DownloadLinkPresented()
        {
            driver.FindElement(pages.BuyersGuide.DownloadButton).Displayed.Should().BeTrue();
        }

        public string GetDownloadLink()
        {
            return driver.FindElement(pages.BuyersGuide.DownloadButton).GetAttribute("href");
        }

        public bool CatalogueGuidanceContentDisplayed()
        {
            return driver.FindElement(pages.BuyersGuide.CatalogueSolutionGuide).Displayed;
        }

        public bool ServiceDeskGuidanceContentDisplayed()
        {
            return driver.FindElement(pages.BuyersGuide.ServiceDeskGuide).Displayed;
        }
    }
}