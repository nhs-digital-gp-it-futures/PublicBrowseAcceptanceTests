namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.BrowseSolutions
{
    using System.IO;
    using FluentAssertions;
    using NHSDPublicBrowseAcceptanceTests.Actions.Utils;
    using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class CompareSolutions
    {
        private readonly UITest test;
        private readonly Settings settings;

        public CompareSolutions(UITest test, Settings settings)
        {
            this.test = test;
            this.settings = settings;
        }

        [Then(@"the compare all solutions tile is displayed")]
        public void ThenTheCompareAllSolutionsTileIsDisplayed()
        {
            test.Pages.BrowseSolutions.CompareAllSolutionsTileIsDisplayed().Should().BeTrue();
        }

        [Given(@"the user wants to compare all solutions")]
        public void GivenTheUserWantsToCompareAllSolutions()
        {
            test.Pages.Homepage.ClickBrowseSolutions();
            test.Pages.BrowseSolutions.OpenCompareAllSolutions();
        }

        [Then(@"the compare document download button is enabled")]
        public void ThenTheCompareDocumentDownloadButtonIsEnabled()
        {
            test.Pages.SolutionsList.CompareSolutionsButtonIsDisplayed().Should().BeTrue();
            var url = test.Pages.SolutionsList.GetCompareSolutionsButtonUrl();
            var localFileName = "compare-solutions.xlsx";
            var client = DownloadFileUtility.DownloadFile(localFileName, settings.DownloadPath, url, DownloadFileUtility.GetHeadersFromDriver(test.Driver));
            var downloadedFile = Path.Combine(settings.DownloadPath, localFileName);
            new FileInfo(downloadedFile).Length.Should().BeGreaterThan(0);
            File.ReadAllBytes(downloadedFile).Length.Should().BeGreaterThan(0);
            client.ResponseHeaders.Get("Content-Type").Should().ContainEquivalentOf("spreadsheetml");
        }

        [Then(@"the compare document download button is not displayed")]
        public void ThenTheCompareDocumentDownloadButtonIsNotDisplayed()
        {
            test.Pages.SolutionsList.CompareSolutionsButtonIsDisplayed().Should().BeFalse();
        }
    }
}
