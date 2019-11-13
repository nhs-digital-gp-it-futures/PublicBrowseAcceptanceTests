using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    public class Homepage
    {
        public By Title => By.CssSelector(".nhsuk-hero__wrapper h1");
    }
}