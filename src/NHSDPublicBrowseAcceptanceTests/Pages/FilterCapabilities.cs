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

        [Fact]
        public void FilterCanBeRemoved()
        {
            var totalSolutions = pages.SolutionsList.GetSolutionsCount();

            var capabilityName = pages.CapabilityFilter.GetCapabilityName();

            var solutionsWithCapability = pages.SolutionsList.GetSolutionsWithCapability(capabilityName);

            pages.CapabilityFilter.ToggleFilter(capabilityName);

            pages.CapabilityFilter.ToggleFilter(capabilityName);

            pages.SolutionsList.GetSolutionsCount().Should().Be(totalSolutions);
        }
    }
}
