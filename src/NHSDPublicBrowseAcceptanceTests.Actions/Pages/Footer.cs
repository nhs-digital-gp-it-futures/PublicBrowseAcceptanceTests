namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    using System.Linq;
    using OpenQA.Selenium;

    public class Footer : Interactions
    {
        public Footer(IWebDriver driver)
            : base(driver)
        {
        }

        public void ComponentDisplayed()
        {
            Wait.Until(s => s.FindElement(Objects.Pages.Footer.Container).Displayed);
        }

        public void SelectURL(string linkText)
        {
            var links = Driver.FindElements(Objects.Pages.Footer.Links);

            links.Single(s => s.Text.Equals(linkText)).Click();
        }
    }
}