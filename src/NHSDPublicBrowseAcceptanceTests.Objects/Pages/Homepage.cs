namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
    using OpenQA.Selenium;

    public class Homepage
    {
        public static By Title => By.CssSelector(".nhsuk-hero__wrapper h1");

        public static By AboutSection => CustomBy.DataTestId("about-us");

        public static By BrowseSolutions => CustomBy.DataTestId("browse-promo", "a");

        public static By GuidanceContent => CustomBy.DataTestId("guidance-promo", "a");

        public static By LoginLogoutLink => CustomBy.DataTestId("login-logout-component", "a");

        public static By DFOCVCSolutions => CustomBy.DataTestId("dfocvc-card", "a");

        public static By NominateAnOrgControl => CustomBy.DataTestId("proxy-card", "a");

        public static By NominateAnOrgLink => By.CssSelector("[data-test-id$='-nominate']");

        public static By ProxyBackLink => CustomBy.DataTestId("nominate-organisation-page-back-link", "a"); 
    }
}
