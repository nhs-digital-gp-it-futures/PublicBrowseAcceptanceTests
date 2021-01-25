namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    using FluentAssertions;
    using OpenQA.Selenium;

    public sealed class BuyersGuide : Interactions
    {
        public BuyersGuide(IWebDriver driver)
            : base(driver)
        {
        }

        public void DownloadLinkPresented()
        {
            Driver.FindElement(Objects.Pages.BuyersGuide.DownloadButton).Displayed.Should().BeTrue();
        }

        public string GetDownloadLink()
        {
            return Driver.FindElement(Objects.Pages.BuyersGuide.DownloadButton).GetAttribute("href");
        }

        public bool CatalogueGuidanceContentDisplayed()
        {
            return Driver.FindElement(Objects.Pages.BuyersGuide.CatalogueSolutionGuide).Displayed;
        }

        public bool ServiceDeskGuidanceContentDisplayed()
        {
            return Driver.FindElement(Objects.Pages.BuyersGuide.ServiceDeskGuide).Displayed;
        }
    }
}
