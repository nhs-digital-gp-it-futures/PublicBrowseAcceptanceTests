using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    public class CapabilityFilter : Interactions
    {
        public CapabilityFilter(IWebDriver driver) : base(driver)
        {
        }

        public void ClickCapabilityContinueButton()
        {
            driver.FindElement(pages.CapabilityFilter.ApplyCapabilityFilter).Click();

            wait.Until(d => d.FindElement(pages.Common.GeneralPageTitle).Text == "Catalogue Solution – results");
        }
    }
}
