using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    public class BrowseSolutions
    {
        public By BrowseLinkSections => CustomBy.ClassName("nhsuk-promo__heading");

        public By BrowseFoundationSolutions => CustomBy.DataTestId("foundation-solutions-promo", "a h3.nhsuk-promo__heading");
        public By BrowseAllSolutions => CustomBy.DataTestId("all-solutions-promo", "a h3.nhsuk-promo__heading");
    }
}