using System.Collections.Generic;
using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.TestData.Capabilities;
using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.Capabilities
{
    [Binding]
    public sealed class CapabilitiesSteps
    {
        private readonly ScenarioContext _context;
        private readonly UITest _test;

        private readonly IEnumerable<Capability> capabilities;
        private string selectedCapability;
        private int solutionsForCapability;

        public CapabilitiesSteps(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
            capabilities = SqlExecutor.Execute<Capability>(_test.ConnectionString, Queries.GetAllCapabilities, null);
        }

        [Given(@"no Capability is selected")]
        public void GivenNoCapabilityIsSelected()
        {
            _test.Pages.Homepage.ClickBrowseSolutions();
            _test.Pages.BrowseSolutions.OpenAllSolutions();
        }

        [Given(@"one or more Capability is selected")]
        public void GivenOneOrMoreCapabilityIsSelected()
        {
            _test.Pages.Homepage.ClickBrowseSolutions();
            _test.Pages.BrowseSolutions.OpenAllSolutions();

            selectedCapability = _test.Pages.CapabilityFilter.SelectCapability(_test.ConnectionString);
            solutionsForCapability = SqlExecutor.ExecuteScalar(_test.ConnectionString,
                Queries.GetSolutionsWithCapabilityCount, new { CapabilityName = selectedCapability });
        }

        [Then(@"Solution results are presented")]
        public void ThenSolutionResultsArePresented()
        {
            _test.Pages.SolutionsList.GetSolutionsWithCapabilityCount(selectedCapability).Should()
                .Be(solutionsForCapability);
        }

        [Given(@"there is a set of Capabilities defined in the Capabilities and Standards model")]
        public void GivenThereIsASetOfCapabilitiesDefinedInTheCapabilitiesAndStandardsModel()
        {
            capabilities.Should().NotBeNull();
        }

        [When(@"the Capabilities are presented for selection")]
        public void WhenTheCapabilitiesArePresentedForSelection()
        {
            _test.Pages.Homepage.ClickBrowseSolutions();
            _test.Pages.BrowseSolutions.OpenAllSolutions();
        }

        [Then(@"all of the Capabilities defined in the Capabilities and Standards model are displayed")]
        public void ThenAllOfTheCapabilitiesDefinedInTheCapabilitiesAndStandardsModelAreDisplayed()
        {
            _test.Pages.CapabilityFilter.CapabilityNamesShown(capabilities);
        }
    }
}
