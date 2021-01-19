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
            driver.FindElement(Objects.Pages.BuyersGuide.DownloadButton).Displayed.Should().BeTrue();
        }

        public string GetDownloadLink()
        {
            return driver.FindElement(Objects.Pages.BuyersGuide.DownloadButton).GetAttribute("href");
        }

        public bool CatalogueGuidanceContentDisplayed()
        {
            return driver.FindElement(Objects.Pages.BuyersGuide.CatalogueSolutionGuide).Displayed;
        }

        public bool ServiceDeskGuidanceContentDisplayed()
        {
            return driver.FindElement(Objects.Pages.BuyersGuide.ServiceDeskGuide).Displayed;
        }
    }
}
