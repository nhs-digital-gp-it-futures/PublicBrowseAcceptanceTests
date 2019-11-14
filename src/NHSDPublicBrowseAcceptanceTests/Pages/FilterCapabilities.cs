using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace NHSDPublicBrowseAcceptanceTests.Pages
{
    public sealed class FilterCapabilities : UITest
    {
        public FilterCapabilities(ITestOutputHelper helper) : base(helper)
        {
            pages.SolutionsList.WaitForSolutionToBeDisplayed();
        }

        /// <summary>
        /// Ensure that when the NHS logo is clicked when a filter is applied that the filter is cleared
        /// </summary>
        [Fact(Skip = "Test has been replaced")]
        public void FilterRemovedWhenLogoClicked()
        {
            var totalSolutions = pages.SolutionsList.GetSolutionsCount();

            pages.CapabilityFilter.FoundationSolutionsFilter();

            pages.Common.ClickLogo();

            pages.SolutionsList.GetSolutionsCount().Should().Be(totalSolutions);
        }
    }
}
