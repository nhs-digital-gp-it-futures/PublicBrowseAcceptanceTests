﻿using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using NHSDPublicBrowseAcceptanceTests.TestData.Utils;
using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.BrowseSolutions
{
    [Binding]
    public class ViewSolutionsList
    {
        private readonly UITest _test;
        private readonly ScenarioContext _context;
        int expectedNumberOfSolutions = 0;

        public ViewSolutionsList(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"that a User has chosen to view a list of all Solutions")]
        public void GivenThatAUserHasChosenToViewAListOfAllSolutions()
        {
            //instantiated BrowseSolutions for reuse
            var bs = new BrowseSolutions(_test, _context);
            bs.GivenIBrowseSolutions();
            bs.WhenTheUserChoosesToViewAllSolutions();
        }

        [Given(@"has not chosen to filter the solutions")]
        [When("the User chooses to continue")]
        public void GivenHasNotChosenToFilterTheSolutions()
        {
            _test.Pages.CapabilityFilter.ClickCapabilityContinueButton();
        }

        [When("Solutions are presented")]
        public void SolutionsPresented()
        {
        }

        [Then(@"there is a Card for each Solution")]
        [Then("no Solutions are excluded on the basis of the Capabilities they deliver")]
        public void ThenThereIsACardForEachSolution()
        {
            var solutions = SqlExecutor.Execute<Solution>(query: Queries.GetAllSolutions,
                connectionString: _test.ConnectionString,
                param: null);
            expectedNumberOfSolutions = SqlExecutor.ExecuteScalar(_test.ConnectionString, Queries.GetSolutionsCount, null);
            var actualNumberOfSolutionCards = _test.Pages.SolutionsList.GetSolutionsCount();
            actualNumberOfSolutionCards.Should().Be(expectedNumberOfSolutions);
        }

        [Then(@"the Card contains the Supplier Name")]
        public void ThenTheCardContainsTheSupplierName()
        {
            var actualNumberOfSupplierNames = _test.Pages.SolutionsList.GetSolutionSupplierNameCount();
            actualNumberOfSupplierNames.Should().Be(expectedNumberOfSolutions);
        }

        [Then(@"the Solution Name")]
        public void ThenTheSolutionName()
        {
            var actualNumberOfSolutionNames = _test.Pages.SolutionsList.GetSolutionNameCount();
            actualNumberOfSolutionNames.Should().Be(expectedNumberOfSolutions);
        }

        [Then(@"the Solution Summary Description")]
        public void ThenTheSolutionSummaryDescription()
        {
            var actualNumberOfSolutionSummaries = _test.Pages.SolutionsList.GetSolutionSummaryCount();
            actualNumberOfSolutionSummaries.Should().Be(expectedNumberOfSolutions);
        }

        [Then(@"the names of the Capabilities provided by the Solution")]
        public void ThenTheNamesOfTheCapabilitiesProvidedByTheSolution()
        {
            var actualNumberOfSolutionCapabilitiesList = _test.Pages.SolutionsList.GetSolutionCapabilityListCount();
            actualNumberOfSolutionCapabilitiesList.Should().Be(expectedNumberOfSolutions);
        }

        [Then(@"capability '(.*)' is listed in the solution capabilities")]
        public void ThenCapabilityIsListedInTheSolutionCapabilities(string expectedCapabilityName)
        {
            var dbCount = SqlExecutor.ExecuteScalar(_test.ConnectionString, Queries.GetSolutionsWithCapabilityCount, new { capabilityName = expectedCapabilityName });
            var uiCount = _test.Pages.SolutionsList.GetSolutionsWithCapabilityCount(expectedCapabilityName);
            uiCount.Should().Be(dbCount);
        }
    }
}