namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.Capabilities
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FluentAssertions;
    using NHSDPublicBrowseAcceptanceTests.TestData.Capabilities;
    using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
    using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class CapabilitiesSteps
    {
        private readonly UITest test;

        private readonly List<Capability> capabilities;
        private string selectedCapability;
        private int solutionsForCapability;

        public CapabilitiesSteps(UITest test)
        {
            this.test = test;
            capabilities = new List<Capability>();
        }

        [Given(@"no Capability is selected")]
        public void GivenNoCapabilityIsSelected()
        {
            test.Pages.Homepage.ClickBrowseSolutions();
            test.Pages.BrowseSolutions.OpenAllSolutions();
        }

        [Given(@"one or more Capability is selected")]
        public async Task GivenOneOrMoreCapabilityIsSelected()
        {
            test.Pages.Homepage.ClickBrowseSolutions();
            test.Pages.BrowseSolutions.OpenAllSolutions();

            selectedCapability = await test.Pages.CapabilityFilter.SelectCapabilityAsync(test.ConnectionString);
            solutionsForCapability = await SqlExecutor.ExecuteScalarAsync(
                test.ConnectionString,
                Queries.GetSolutionsWithCapabilityCount,
                new { capabilityName = selectedCapability });
        }

        [Then(@"Solution results are presented")]
        public void ThenSolutionResultsArePresented()
        {
            test.Pages.SolutionsList.GetSolutionsWithCapabilityCount(selectedCapability).Should()
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
            test.Pages.Homepage.ClickBrowseSolutions();
            test.Pages.BrowseSolutions.OpenAllSolutions();
        }

        [Then(@"all of the Capabilities defined in the Capabilities and Standards model are displayed")]
        public async Task ThenAllOfTheCapabilitiesDefinedInTheCapabilitiesAndStandardsModelAreDisplayed()
        {
            await GetCapabilitiesAsync();
            test.Pages.CapabilityFilter.CapabilityNamesShown(capabilities);
        }

        private async Task GetCapabilitiesAsync()
        {
            var caps = await SqlExecutor.ExecuteAsync<Capability>(test.ConnectionString, Queries.GetAllCapabilities, null);

            capabilities.AddRange(caps);
        }
    }
}
