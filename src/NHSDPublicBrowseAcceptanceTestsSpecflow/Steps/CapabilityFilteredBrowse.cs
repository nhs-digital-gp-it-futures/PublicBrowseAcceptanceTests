using FluentAssertions;
using NHSDPublicBrowseAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTestsSpecflow.Steps
{
    [Binding]
    public class CapabilityFilteredBrowse
    {
        private UITest _test;
        private ScenarioContext _context;
        private int solutionsCount;
        private string capabilityName;
        private string secondCapabilityName;
        private int solutionsWithCapability;

        public CapabilityFilteredBrowse(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"one or more Capability is selected")]
        public void GivenOneOrMoreCapabilityIsSelected()
        {
            capabilityName = _test.pages.CapabilityFilter.GetCapabilityName();
            solutionsWithCapability = _test.pages.SolutionsList.GetSolutionsWithCapability(capabilityName);

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
            solutionsWithCapability = _test.pages.SolutionsList.GetSolutionsWithCapability(secondCapabilityName);
            _test.pages.CapabilityFilter.ToggleFilter(secondCapabilityName);
        }

        [Given(@"no Capability is selected")]
        [StepDefinition(@"Solutions are presented")]
        public void SolutionsArePresented()
        {
            _test.pages.SolutionsList.WaitForSolutionToBeDisplayed();
            solutionsCount = _test.pages.SolutionsList.GetSolutionsCount();
        }

        [Then(@"no Solutions are excluded on the basis of the Capabilities they deliver")]
        public void ThenNoSolutionsAreExcludedOnTheBasisOfTheCapabilitiesTheyDeliver()
        {
            _test.pages.SolutionsList.GetSolutionsCount().Should().Be(solutionsCount);
        }

        [Then(@"only Solutions that deliver all the Foundation Capabilities are included")]
        [Then(@"only Solutions that deliver all of the selected Capabilities are included")]
        [Then(@"Additional Services are not included in the results")]
        public void SolutionsWithCapabilities()
        {
            solutionsCount.Should().Be(solutionsWithCapability);
        }

        [When(@"the nhs logo is clicked")]
        public void WhenTheNhsLogoIsClicked()
        {
            _test.pages.Common.ClickLogo();
        }

    }
}
