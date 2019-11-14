using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    public sealed class Header
    {
        public By Logo => By.CssSelector(".nhsuk-header__logo a");

        public By Container => By.ClassName("nhsuk-header");

        public By TermsBanner => CustomBy.DataTestId("terms-banner");
    }
}
