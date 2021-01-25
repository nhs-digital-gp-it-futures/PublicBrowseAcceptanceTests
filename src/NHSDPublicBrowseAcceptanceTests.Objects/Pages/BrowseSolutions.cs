namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
    using OpenQA.Selenium;

    public static class BrowseSolutions
    {
        public static By BrowseSolutionsHeading => CustomBy.DataTestId("browse-solutions-heading");

        public static By BrowseLinkSections => By.ClassName("nhsuk-promo__heading");

        public static By BrowseFoundationSolutions =>
            CustomBy.DataTestId("foundation-solutions-promo", "a h3.nhsuk-promo__heading");

        public static By BrowseAllSolutions => CustomBy.DataTestId("all-solutions-promo", "a h3.nhsuk-promo__heading");

        public static By CompareAllSolutions => CustomBy.DataTestId("compare-promo", "a");
    }
}
