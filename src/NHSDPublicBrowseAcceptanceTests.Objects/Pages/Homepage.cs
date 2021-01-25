﻿namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    using NHSDPublicBrowseAcceptanceTests.Objects.Utils;
    using OpenQA.Selenium;

    public class Homepage
    {
        public static By Title => By.CssSelector(".nhsuk-hero__wrapper h1");

        public static By AboutSection => CustomBy.DataTestId("about-us");

        public static By BrowseSolutions => CustomBy.DataTestId("browse-promo", "a h3.nhsuk-promo__heading");

        public static By GuidanceContent => CustomBy.DataTestId("guidance-promo", "a h3");

        public static By LoginLogoutLink => CustomBy.DataTestId("login-logout-component", "a");
    }
}
