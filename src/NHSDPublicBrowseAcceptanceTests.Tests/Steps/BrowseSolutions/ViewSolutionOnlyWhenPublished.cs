using NHSDPublicBrowseAcceptanceTests.TestData.Capabilities;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
using System;
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
            _test.CatalogueItem = GenerateCatalogueItem.GenerateNewCatalogueItem(checkForUnique: true,
                connectionString: _test.ConnectionString, publishedStatus: status);
            _test.CatalogueItem.Create(_test.ConnectionString);
            _test.Solution = GenerateSolution.GenerateNewSolution(_test.CatalogueItem.CatalogueItemId, 0, false);
            _test.Solution.Create(_test.ConnectionString);
            _context.Add("DeleteSolution", true);
            new Capability().AddRandomCapabilityToSolution(_test.ConnectionString, _test.Solution.Id);

            _test.Driver.Navigate().Refresh();
        }
    }
}