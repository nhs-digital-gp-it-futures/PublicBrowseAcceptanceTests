using FluentAssertions;
using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps
{
    [Binding]
    public class CapabilityFilteredBrowse
    {
        private readonly UITest _test;
        private readonly ScenarioContext _context;
        private string capabilityName;
        private string secondCapabilityName;

        public CapabilityFilteredBrowse(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"one or more Capability is selected")]
        public void GivenOneOrMoreCapabilityIsSelected()
        {
            capabilityName = _test.pages.CapabilityFilter.GetCapabilityName();
            _test.expectedSolutionsCount = _test.pages.SolutionsList.GetSolutionsWithCapability(capabilityName);
            _test.pages.CapabilityFilter.ToggleFilter(capabilityName);
        }

        [Given(@"a Capability is de-selected")]
        public void GivenACapabilityIsDe_Selected()
        {
            capabilityName = _test.pages.CapabilityFilter.GetCapabilityName();

            // Toggle 2 capability checkboxes, then uncheck the first capability
            _test.pages.CapabilityFilter.ToggleFilter(capabilityName);
            _test.pages.CapabilityFilter.ToggleFilter(capabilityName);
        }

        [Given(@"there is one or more Capability selected")]
        public void GivenThereIsOneOrMoreCapabilitySelected()
        {
            secondCapabilityName = _test.pages.CapabilityFilter.GetCapabilityName(1);
            _test.expectedSolutionsCount = _test.pages.SolutionsList.GetSolutionsWithCapability(secondCapabilityName);
            _test.pages.CapabilityFilter.ToggleFilter(secondCapabilityName);
        }

        [Then(@"no Solutions are excluded on the basis of the Capabilities they deliver")]
        public void ThenNoSolutionsAreExcludedOnTheBasisOfTheCapabilitiesTheyDeliver()
        {
            var actualCount = _test.pages.SolutionsList.GetSolutionsCount();
            actualCount.Should().BeGreaterThan(_test.expectedSolutionsCount);
        }

        [When(@"the nhs logo is clicked")]
        public void WhenTheNhsLogoIsClicked()
        {
            _test.pages.Common.ClickLogo();
        }

    }
}
