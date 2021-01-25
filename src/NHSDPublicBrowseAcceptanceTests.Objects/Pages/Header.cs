namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
    using OpenQA.Selenium;

    public sealed class Header
    {
        public static By Logo => By.CssSelector(".nhsuk-header__logo a");

        public static By Container => By.ClassName("nhsuk-header");

        public static By Banner => CustomBy.DataTestId("beta-banner");
    }
}
