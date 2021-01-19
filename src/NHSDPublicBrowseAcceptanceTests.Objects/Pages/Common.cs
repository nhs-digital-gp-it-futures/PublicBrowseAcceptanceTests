using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    public sealed class Common
    {
        public static By NHSLogo => By.ClassName("nhsuk-header__link");

        public static By PageTitle => By.TagName("h1");

        public static By GeneralPageTitle => CustomBy.DataTestId("general-page-title");
    }
}
