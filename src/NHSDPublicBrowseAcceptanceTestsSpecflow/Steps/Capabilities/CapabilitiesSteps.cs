using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.TestData.Capabilities;
using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps.Capabilities
{
    [Binding]
    public sealed class CapabilitiesSteps
    {
        private readonly UITest _test;
        private readonly ScenarioContext _context;

        private readonly IEnumerable<Capability> capabilities;
        private string selectedCapability;
        private int solutionsForCapability;

        public CapabilitiesSteps(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
            capabilities = SqlExecutor.Execute<Capability>(_test.connectionString, Queries.GetAllCapabilities, null);
        }

        [Given(@"no Capability is selected")]
        public void GivenNoCapabilityIsSelected()
        {
            _test.pages.Homepage.ClickBrowseSolutions();
            _test.pages.BrowseSolutions.OpenAllSolutions();
        }

        [Given(@"one or more Capability is selected")]
        public void GivenOneOrMoreCapabilityIsSelected()
        {
            _test.pages.Homepage.ClickBrowseSolutions();
            _test.pages.BrowseSolutions.OpenAllSolutions();

            selectedCapability = _test.pages.CapabilityFilter.SelectCapability(_test.connectionString);
            solutionsForCapability = SqlExecutor.ExecuteScalar(_test.connectionString, Queries.GetSolutionsWithCapabilityCount, new { CapabilityName = selectedCapability });
        }

        [Then(@"Solution results are presented")]
        public void ThenSolutionResultsArePresented()
        {
            _test.pages.SolutionsList.GetSolutionsWithCapabilityCount(selectedCapability).Should().Be(solutionsForCapability);
        }

        [Given(@"there is a set of Capabilities defined in the Capabilities and Standards model")]
        public void GivenThereIsASetOfCapabilitiesDefinedInTheCapabilitiesAndStandardsModel()
        {
            capabilities.Should().NotBeNull();
        }

        [When(@"the Capabilities are presented for selection")]
        public void WhenTheCapabilitiesArePresentedForSelection()
        {
            _test.pages.Homepage.ClickBrowseSolutions();
            _test.pages.BrowseSolutions.OpenAllSolutions();
        }

        [Then(@"all of the Capabilities defined in the Capabilities and Standards model are displayed")]
        public void ThenAllOfTheCapabilitiesDefinedInTheCapabilitiesAndStandardsModelAreDisplayed()
        {
            _test.pages.CapabilityFilter.CapabilityNamesShown(capabilities);
        }

    }
}
