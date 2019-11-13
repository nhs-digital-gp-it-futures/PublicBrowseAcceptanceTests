using System.Linq;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    public class CapabilityFilter : Interactions
    {
        public CapabilityFilter(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Get a capability name from the checkbox list
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Name of capability from checkbox label</returns>
        public string GetCapabilityName(int index = 0)
        {
            var capability = driver.FindElements(pages.CapabilityFilter.Capabilities)[index];

            return capability.FindElement(By.TagName("label")).Text.Trim();
        }

        /// <summary>
        /// Toggle a capability checkbox and click Apply Filters
        /// </summary>
        /// <param name="capabilityName"></param>
        public void ToggleFilter(string capabilityName)
        {
            var capabilities = driver.FindElements(pages.CapabilityFilter.Capabilities);

            var capability = capabilities.First(s => s.Text == capabilityName);

            capability.FindElement(By.TagName("input")).Click();

            driver.FindElement(pages.CapabilityFilter.ApplyFilter).Click();
        }

        /// <summary>
        /// Click the `Foundation only` button
        /// </summary>
        public void FoundationSolutionsFilter()
        {
            driver.FindElement(pages.CapabilityFilter.ApplyFoundationFilter).Click();
        }

        public void SelectLastCapability()
        {
            var capabilities = driver.FindElements(pages.CapabilityFilter.Capabilities);

            var capName = GetCapabilityName(capabilities.Count - 1);

            ToggleFilter(capName);
        }
    }
}