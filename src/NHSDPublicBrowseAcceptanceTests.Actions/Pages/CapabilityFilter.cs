using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.TestData.Capabilities;
using NHSDPublicBrowseAcceptanceTests.TestData.Information;
using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
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

        public void CapabilityNamesShown(IEnumerable<Capability> capabilities)
        {
            var capabilityLabels = driver.FindElements(pages.CapabilityFilter.Capabilities)
                .Select(s => s.FindElement(By.TagName("label")).Text);

            capabilityLabels.Should().BeEquivalentTo(capabilities.Select(s => s.Name));
        }

        public string SelectCapability(string connectionString)
        {
            var selectedCapabilities =
                SqlExecutor.Execute<string>(connectionString, Queries.GetSelectedCapabilities, null);

            var randomCapabilityName = RandomInformation.GetRandomItem(selectedCapabilities);

            driver.FindElements(pages.CapabilityFilter.Capabilities)
                .Single(s => s.FindElement(By.TagName("label")).Text.ToLower().Contains(randomCapabilityName.ToLower()))
                .FindElement(By.TagName("input")).Click();

            return randomCapabilityName;
        }
    }
}