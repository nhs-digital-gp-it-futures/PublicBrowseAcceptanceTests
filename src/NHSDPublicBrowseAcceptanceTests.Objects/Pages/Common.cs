using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    public sealed class Common
    {
        public By NHSLogo => By.ClassName("nhsuk-header__link");

        public By PageTitle => By.TagName("h1");

        public By GeneralPageTitle => CustomBy.DataTestId("general-page-title");
    }
}
