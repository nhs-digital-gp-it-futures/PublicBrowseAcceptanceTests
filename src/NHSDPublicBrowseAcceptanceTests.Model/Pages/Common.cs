using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    public class Common : Interactions
    {
        public Common(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Ensure the page has loaded fully
        /// note; footer is the last element to fully render
        /// </summary>
        public void WaitForPageLoad()
        {
            wait.Until(s => s.FindElement(By.ClassName("nhsuk-footer")));
        }
    }
}