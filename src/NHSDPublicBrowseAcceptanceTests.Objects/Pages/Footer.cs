using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    public class Footer
    {
        public By Container => By.Id("nhsuk-footer");

        public By Links => By.CssSelector(".nhsuk-footer__list-item-link");
    }
}
