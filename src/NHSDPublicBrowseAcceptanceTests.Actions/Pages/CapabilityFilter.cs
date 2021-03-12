namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FluentAssertions;
    using NHSDPublicBrowseAcceptanceTests.TestData.Capabilities;
    using NHSDPublicBrowseAcceptanceTests.TestData.Information;
    using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
    using OpenQA.Selenium;

    public class CapabilityFilter : Interactions
    {
        public CapabilityFilter(IWebDriver driver)
            : base(driver)
        {
        }

        public void CapbilityFilterDisplayed()
        {
            Wait.Until(d => d.FindElement(Objects.Pages.CapabilityFilter.Capabilities).Displayed);
        }

        public void ClickCapabilityContinueButton()
        {
            CapbilityFilterDisplayed();
            Driver.FindElement(Objects.Pages.CapabilityFilter.ApplyCapabilityFilter).Click();

            Wait.Until(d => d.FindElement(Objects.Pages.Common.GeneralPageTitle).Text == "Catalogue Solution – results");
        }

        public void CapabilityNamesShown(IEnumerable<Capability> capabilities)
        {
            var capabilityLabels = Driver.FindElements(Objects.Pages.CapabilityFilter.Capabilities)
                .Select(s => s.FindElement(By.TagName("label")).Text);

            capabilityLabels.Should().BeEquivalentTo(capabilities.Select(s => s.Name));
        }

        public async Task<string> SelectCapabilityAsync(string connectionString)
        {
            Wait.Until(d => Driver.FindElement(Objects.Pages.CapabilityFilter.Capabilities).Displayed);
            var selectedCapabilities =
                await SqlExecutor.ExecuteAsync<string>(connectionString, Queries.GetSelectedCapabilities, null);

            var randomCapabilityName = RandomInformation.GetRandomItem(selectedCapabilities);

            Driver.FindElements(Objects.Pages.CapabilityFilter.Capabilities)
                .First(s => s.FindElement(By.TagName("label")).Text.ToLower().Contains(randomCapabilityName.ToLower()))
                .FindElement(By.TagName("input")).Click();

            return randomCapabilityName;
        }
    }
}