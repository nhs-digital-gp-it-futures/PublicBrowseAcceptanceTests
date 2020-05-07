using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.Actions.Utils;
using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.BrowseSolutions
{
    [Binding]
    public class CompareSolutions
    {
        private readonly ScenarioContext _context;
        private readonly UITest _test;

        public CompareSolutions(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Then(@"the compare all solutions tile is displayed")]
        public void ThenTheCompareAllSolutionsTileIsDisplayed()
        {
            _test.Pages.BrowseSolutions.CompareAllSolutionsTileIsDisplayed().Should().BeTrue();
        }

        [Given(@"the user wants to compare all solutions")]
        public void GivenTheUserWantsToCompareAllSolutions()
        {
            _test.Pages.Homepage.ClickBrowseSolutions();
            _test.Pages.BrowseSolutions.OpenCompareAllSolutions();
        }

        [Then(@"the compare document download button is enabled")]
        public void ThenTheCompareDocumentDownloadButtonIsEnabled()
        {
            _test.Pages.SolutionsList.CompareSolutionsButtonIsDisplayed().Should().BeTrue();
            var url = _test.Pages.SolutionsList.GetCompareSolutionsButtonUrl();
            var localFileName = "compare-solutions.xlsx";
            //var useragent = ((IJavaScriptExecutor)_test.Driver).ExecuteScript("return navigator.userAgent;");
            //IDictionary<string, string> headers = new Dictionary<string, string>();
            //headers.Add("user-agent", (string)useragent);

            IDictionary<string, string> headers = DownloadFileUtility.GetHeadersFromDriver(_test.Driver);
            var client = DownloadFileUtility.DownloadFile(localFileName, _test.DownloadPath, url, headers);
            var downloadedFile = Path.Combine(_test.DownloadPath, localFileName);
            new FileInfo(downloadedFile).Length.Should().BeGreaterThan(0);
            File.ReadAllBytes(downloadedFile).Length.Should().BeGreaterThan(0);
            client.ResponseHeaders.Get("Content-Type").Should().ContainEquivalentOf("spreadsheetml");
        }

        [Then(@"the compare document download button is not displayed")]
        public void ThenTheCompareDocumentDownloadButtonIsNotDisplayed()
        {
            _test.Pages.SolutionsList.CompareSolutionsButtonIsDisplayed().Should().BeFalse();
        }
    }
}
