using FluentAssertions;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps
{
    [FeatureFile("./Tests/Gherkin/FoundationSolutionCapabilityFilteredBrowse.txt")]
    public sealed class FoundationSolutionCapabilityFilteredBrowse : TestSteps
    {
        private int solutionsCount;

        public FoundationSolutionCapabilityFilteredBrowse(ITestOutputHelper helper) : base(helper)
        {
        }

        [Given("all the Foundation Capabilities are selected")]
        public void FoundationCapabilitiesSelected()
        {
            pages.CapabilityFilter.FoundationSolutionsFilter();
        }

        [And("no other Capabilities are selected")]
        public void NoOtherCapabilitiesSelected()
        {
        }

        [When("Solutions are presented")]
        public void SolutionsArePresented()
        {
            pages.SolutionsList.WaitForSolutionToBeDisplayed();
            solutionsCount = pages.SolutionsList.GetSolutionsCount();
        }

        [Then("only Solutions that deliver all the Foundation Capabilities are included")]
        [Then("Solutions that deliver all the Foundation Capabilities and the other selected Capabilities are included")]
        public void SolutionsWithSelectedCapabilities()
        {
            pages.SolutionsList.SolutionsHaveAllSelectedCapabilities().Should().BeTrue();
        }

        [And("one or more other Capabilities are selected")]
        public void SelectAdditionalCapability()
        {
            pages.CapabilityFilter.SelectLastCapability();
        }
    }
}
