﻿using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.TestData.Capabilities;
using NHSDPublicBrowseAcceptanceTests.TestData.Information;
using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    public class CapabilityFilter : Interactions
    {
        public CapabilityFilter(IWebDriver driver) : base(driver)
        {
        }

        public void CapbilityFilterDisplayed()
        {
            wait.Until(d => d.FindElement(Objects.Pages.CapabilityFilter.Capabilities).Displayed);
        }

        public void ClickCapabilityContinueButton()
        {
            CapbilityFilterDisplayed();
            driver.FindElement(Objects.Pages.CapabilityFilter.ApplyCapabilityFilter).Click();

            wait.Until(d => d.FindElement(Objects.Pages.Common.GeneralPageTitle).Text == "Catalogue Solution – results");
        }

        public void CapabilityNamesShown(IEnumerable<Capability> capabilities)
        {
            var capabilityLabels = driver.FindElements(Objects.Pages.CapabilityFilter.Capabilities)
                .Select(s => s.FindElement(By.TagName("label")).Text);

            capabilityLabels.Should().BeEquivalentTo(capabilities.Select(s => s.Name));
        }

        public string SelectCapability(string connectionString)
        {
            wait.Until(d => driver.FindElement(Objects.Pages.CapabilityFilter.Capabilities).Displayed);
            var selectedCapabilities =
                SqlExecutor.Execute<string>(connectionString, Queries.GetSelectedCapabilities, null);

            var randomCapabilityName = RandomInformation.GetRandomItem(selectedCapabilities);

            driver.FindElements(Objects.Pages.CapabilityFilter.Capabilities)
                .First(s => s.FindElement(By.TagName("label")).Text.ToLower().Contains(randomCapabilityName.ToLower()))
                .FindElement(By.TagName("input")).Click();

            return randomCapabilityName;
        }
    }
}