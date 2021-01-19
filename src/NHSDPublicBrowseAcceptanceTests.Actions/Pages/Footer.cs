using OpenQA.Selenium;
using System.Linq;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    public class Footer : Interactions
    {
        public Footer(IWebDriver driver) : base(driver)
        {
        }

        public void ComponentDisplayed()
        {
            wait.Until(s => s.FindElement(Objects.Pages.Footer.Container).Displayed);
        }

        public void SelectURL(string linkText)
        {
            var links = driver.FindElements(Objects.Pages.Footer.Links);

            links.Single(s => s.Text.Equals(linkText)).Click();
        }
    }
}