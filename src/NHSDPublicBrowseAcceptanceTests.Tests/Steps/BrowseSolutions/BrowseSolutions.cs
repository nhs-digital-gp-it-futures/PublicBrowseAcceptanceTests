﻿namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.BrowseSolutions
{
    using FluentAssertions;
    using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
    using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class BrowseSolutions
    {
        private readonly UITest test;

        public BrowseSolutions(UITest test)
        {
            this.test = test;
        }

        [Given(@"the User wants to view Foundation Solutions only")]
        [Given(@"the User wants to view all Solutions")]
        [Given(@"the user navigates to view catalogue solutions")]
        public void GivenIBrowseSolutions()
        {
            test.Pages.Homepage.ClickBrowseSolutions();
        }

        [When(@"the User chooses to view Foundation Solutions")]
        public void WhenTheUserChoosesToViewFoundationSolutions()
        {
            test.Pages.BrowseSolutions.OpenFoundationSolutions();
        }

        [When(@"the User chooses to view all Solutions")]
        public void WhenTheUserChoosesToViewAllSolutions()
        {
            test.Pages.BrowseSolutions.OpenAllSolutions();
            test.Pages.CapabilityFilter.ClickCapabilityContinueButton();
        }

        [Then(@"only Foundation Solutions are presented in the results")]
        public void ThenOnlyFoundationSolutionsArePresentedInTheResults()
        {
            var numberOfSolutionCards = test.Pages.SolutionsList.GetSolutionsCount();
            var numberOfFoundationSolutionIndicators = test.Pages.SolutionsList.GetFoundationSolutionIndicatorCount();
            numberOfFoundationSolutionIndicators.Should().Be(numberOfSolutionCards);
        }

        [Then(@"all the Foundation Solutions are included in the results")]
        public void ThenAllTheFoundationSolutionsAreIncludedInTheResults()
        {
            var numberOfFoundationSolutionsFromDb =
                SqlExecutor.ExecuteScalar(test.ConnectionString, Queries.GetFoundationSolutionsCount, null);
            var numberOfFoundationSolutionIndicatorsOnUi =
                test.Pages.SolutionsList.GetFoundationSolutionIndicatorCount();
            numberOfFoundationSolutionsFromDb.Should().Be(numberOfFoundationSolutionIndicatorsOnUi);
        }

        [Then(@"all Non-Foundation Solutions are included in the results")]
        public void ThenAllNon_FoundationSolutionsAreIncludedInTheResults()
        {
            var numberOfNonFoundationSolutionsFromDb = SqlExecutor.ExecuteScalar(
                test.ConnectionString,
                Queries.GetNonFoundationSolutionsCount,
                null);
            var numberOfFoundationSolutionsFromDb =
                SqlExecutor.ExecuteScalar(test.ConnectionString, Queries.GetFoundationSolutionsCount, null);
            var totalNumberOfSolutionsOnUi = test.Pages.SolutionsList.GetSolutionsCount();
            var numberOfNonFoundationsOnUI = totalNumberOfSolutionsOnUi - numberOfFoundationSolutionsFromDb;
            numberOfNonFoundationsOnUI.Should().Be(numberOfNonFoundationSolutionsFromDb);
        }
    }
}
