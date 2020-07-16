using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.Actions.Utils;
using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
using System.IO;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.BrowseSolutions
{
    [Binding]
    public class CompareSolutions
    {
        private readonly UITest _test;
        private readonly Settings _settings;

        public CompareSolutions(UITest test, Settings settings)
        {
            _test = test;
            _settings = settings;
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
            var client = DownloadFileUtility.DownloadFile(localFileName, _settings.DownloadPath, url, DownloadFileUtility.GetHeadersFromDriver(_test.Driver));
            var downloadedFile = Path.Combine(_settings.DownloadPath, localFileName);
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
