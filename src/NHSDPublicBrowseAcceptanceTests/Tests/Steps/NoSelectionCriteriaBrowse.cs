using System;
using FluentAssertions;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps
{
    [FeatureFile("./Tests/Gherkin/NoSelectionCriteriaBrowse.txt")]
    public sealed class NoSelectionCriteriaBrowse : TestSteps, IDisposable
    {
        private int solutionsCount;

        public NoSelectionCriteriaBrowse(ITestOutputHelper helper) : base(helper)
        {
        }

        [Given("no selection criteria are applied")]
        [Given("that Solutions are presented")]
        [When("no selection criteria are applied")]
        public void NoSelectionCriteriaApplied()
        {
            pages.SolutionsList.WaitForSolutionToBeDisplayed();
        }

        [When("Solutions are presented")]
        public void SolutionsArePresented()
        {
            pages.SolutionsList.WaitForSolutionToBeDisplayed();
            solutionsCount = pages.SolutionsList.GetSolutionsCount();
        }

        [Then("no Solutions are excluded")]
        public void NoSolutionsExcluded()
        {
            pages.SolutionsList.GetSolutionsCount().Should().Be(solutionsCount);
        }


        [Then("the Card will contain the correct contents")]
        public void SolutionHasCorrectContents()
        {
            pages.SolutionsList.SolutionHasCapabilities().Should().BeTrue();
            pages.SolutionsList.SolutionHasTitle().Should().BeTrue();
            pages.SolutionsList.SolutionHasSummary().Should().BeTrue();
        }
    }
}
