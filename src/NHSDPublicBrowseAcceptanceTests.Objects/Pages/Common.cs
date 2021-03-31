namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
    using OpenQA.Selenium;

    public sealed class Common
    {
        public static By NHSLogo => By.ClassName("nhsuk-header__link");

        public static By PageTitle => By.TagName("h1");

        public static By GeneralPageTitle => CustomBy.DataTestId("general-description", "h1");

        public static By GoBackLink => By.ClassName("nhsuk-back-link__link");
    }
}
