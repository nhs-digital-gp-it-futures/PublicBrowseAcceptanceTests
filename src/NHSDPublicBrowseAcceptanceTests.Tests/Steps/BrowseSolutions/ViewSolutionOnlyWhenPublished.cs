using System;
using System.Linq;
using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.TestData.Capabilities;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.BrowseSolutions
{
    [Binding]
    public class ViewSolutionOnlyWhenPublished
    {
        private readonly ScenarioContext _context;
        private readonly UITest _test;

        public ViewSolutionOnlyWhenPublished(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"that a Solution has a PublishedStatus of (.*)")]
        public void GivenThatASolutionHasAPublishedStatusOf(int status)
        {
            _test.Solution = GenerateSolution.GenerateNewSolution(checkForUnique: true,
                connectionString: _test.ConnectionString, publishedStatus: status);
            _test.Solution.Create(_test.ConnectionString);
            _test.SolutionDetail =
                GenerateSolutionDetails.GenerateNewSolutionDetail(_test.Solution.Id, Guid.NewGuid(), 0, false);
            _test.SolutionDetail.Create(_test.ConnectionString);
            _test.Solution.SolutionDetailId = _test.SolutionDetail.SolutionDetailId;
            _test.Solution.Update(_test.ConnectionString);
            _context.Add("DeleteSolution", true);
            new Capability().AddRandomCapabilityToSolution(_test.ConnectionString, _test.Solution.Id);


            _test.Driver.Navigate().Refresh();
        }

        [Then(@"the Solution's Marketing Page availability is (.*)")]
        public void ThenTheSolutionSMarketingPageAvailabilityIsFalse(bool published)
        {
            var solutions = _test.Pages.SolutionsList.GetListOfSolutionNames();
            solutions.Any(s => s.Contains(_test.Solution.Name)).Should().Be(published);
        }
    }
}