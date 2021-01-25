namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
    using OpenQA.Selenium;

    public sealed class BuyersGuide
    {
        public static By DownloadButton => CustomBy.DataTestId("subsection-button", "a");

        public static By CatalogueSolutionGuide => By.Id("catalogue-solution");

        public static By ServiceDeskGuide => By.Id("contact-us");
    }
}
