namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    using OpenQA.Selenium;

    public class Footer
    {
        public static By Container => By.Id("nhsuk-footer");

        public static By Links => By.CssSelector(".nhsuk-footer__list-item-link");
    }
}
