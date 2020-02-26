using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    public sealed class BuyersGuide
    {
        public By DownloadButton => CustomBy.DataTestId("subsection-button", "a");

        public By CatalogueSolutionGuide => By.Id("catalogue-solution");

        public By ServiceDeskGuide => By.Id("contact-us");
    }
}
