using FluentAssertions;
using Xunit;

namespace NHSDPublicBrowseAcceptanceTests.Pages
{
    public sealed class FilterCapabilities : UITest
    {
        public FilterCapabilities()
        {
            pages.SolutionsList.WaitForSolutionToBeDisplayed();
        }

        /// <summary>
        /// Ensure a capability filter can be applied with the correct number of solutions returned
        /// </summary>
        [Fact]
        public void FilterCanBeApplied()
        {
            var capabilityName = pages.CapabilityFilter.GetCapabilityName();

            var solutionsWithCapability = pages.SolutionsList.GetSolutionsWithCapability(capabilityName);

            pages.CapabilityFilter.ToggleFilter(capabilityName);

            pages.SolutionsList.GetSolutionsCount().Should().Be(solutionsWithCapability);
        }

        /// <summary>
        /// Ensure that when a filter has previously been applied, that filter can be removed correctly
        /// </summary>
        [Fact]
        public void FilterCanBeRemoved()
        {
            var totalSolutions = pages.SolutionsList.GetSolutionsCount();

            var capabilityName = pages.CapabilityFilter.GetCapabilityName();

            pages.CapabilityFilter.ToggleFilter(capabilityName);

            pages.CapabilityFilter.ToggleFilter(capabilityName);

            pages.SolutionsList.GetSolutionsCount().Should().Be(totalSolutions);
        }

        /// <summary>
        /// Ensure that the foundation capabilities can be filtered to in a single button press
        /// </summary>
        [Fact]
        public void FilterToFoundationSolutionsOnly()
        {
            var totalSolutions = pages.SolutionsList.GetSolutionsCount();

            pages.CapabilityFilter.FoundationSolutionsFilter();

            pages.SolutionsList.GetSolutionsCount().Should().BeLessThan(totalSolutions);
        }

        /// <summary>
        /// Ensure that when the NHS logo is clicked when a filter is applied that the filter is cleared
        /// </summary>
        [Fact]
        public void FilterRemovedWhenLogoClicked()
        {
            var totalSolutions = pages.SolutionsList.GetSolutionsCount();

            pages.CapabilityFilter.FoundationSolutionsFilter();

            pages.Common.ClickLogo();

            pages.SolutionsList.GetSolutionsCount().Should().Be(totalSolutions);
        }
    }
}
