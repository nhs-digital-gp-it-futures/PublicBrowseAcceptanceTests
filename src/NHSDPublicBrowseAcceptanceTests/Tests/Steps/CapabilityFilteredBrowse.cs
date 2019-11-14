using FluentAssertions;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps
{
    [FeatureFile("./Tests/Gherkin/CapabilityFilteredBrowse.txt")]
    public sealed class CapabilityFilteredBrowse : TestSteps
    {
        private int solutionsCount;
        private string capabilityName;
        private string secondCapabilityName;
        private int solutionsWithCapability;

        public CapabilityFilteredBrowse(ITestOutputHelper helper) : base(helper)
        {
        }

        [Given("no Capability is selected")]
        [When("Solutions are presented")]
        public void SolutionsArePresented()
        {
            pages.SolutionsList.WaitForSolutionToBeDisplayed();
            solutionsCount = pages.SolutionsList.GetSolutionsCount();
        }

        [Then("no Solutions are excluded on the basis of the Capabilities they deliver")]
        public void NoSolutionsExcluded()
        {
            pages.SolutionsList.GetSolutionsCount().Should().Be(solutionsCount);
        }

        [Given("one or more Capability is selected")]
        public void CapabilitySelected()
        {
            capabilityName = pages.CapabilityFilter.GetCapabilityName();
            solutionsWithCapability = pages.SolutionsList.GetSolutionsWithCapability(capabilityName);

            pages.CapabilityFilter.ToggleFilter(capabilityName);
        }

        [Then("only Solutions that deliver all of the selected Capabilities are included")]
        [And("Additional Services are not included in the results")]
        public void SolutionsWithCapabilities()
        {
            solutionsCount.Should().Be(solutionsWithCapability);
        }

        [Given("a Capability is de-selected")]
        public void CapabilityDeselectedAdditionalSelected()
        {
            capabilityName = pages.CapabilityFilter.GetCapabilityName();

            // Toggle 2 capability checkboxes, then uncheck the first capability
            pages.CapabilityFilter.ToggleFilter(capabilityName);
            pages.CapabilityFilter.ToggleFilter(capabilityName);
        }

        [And("there is one or more Capability selected")]
        public void SelectCapability()
        {
            secondCapabilityName = pages.CapabilityFilter.GetCapabilityName(1);
            solutionsWithCapability = pages.SolutionsList.GetSolutionsWithCapability(secondCapabilityName);
            pages.CapabilityFilter.ToggleFilter(secondCapabilityName);
        }
    }
}
