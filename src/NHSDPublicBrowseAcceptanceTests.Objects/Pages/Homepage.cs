using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    public class Homepage
    {
        public By Title => By.CssSelector(".nhsuk-hero__wrapper h1");

        public By AboutSection => CustomBy.DataTestId("about-us");

        public By BrowseSolutions => CustomBy.DataTestId("browse-promo", "a h3.nhsuk-promo__heading");

        public By GuidanceContent => CustomBy.DataTestId("guidance-promo", "a h3.nhsuk-promo__heading");
    }
}