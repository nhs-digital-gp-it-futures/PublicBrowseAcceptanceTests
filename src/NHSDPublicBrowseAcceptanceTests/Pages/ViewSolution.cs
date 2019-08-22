using FluentAssertions;
using OpenQA.Selenium;
using Xunit;

namespace NHSDPublicBrowseAcceptanceTests.Pages
{
    public sealed class ViewSolution : UITest
    {
        IWebElement solution;
        public ViewSolution()
        {
            pages.SolutionsList.WaitForSolutionToBeDisplayed();
        }

        /// <summary>
        /// Ensure a solution shows the same capabilities that the solution list displays
        /// </summary>
        [Fact]
        public void SolutionDisplaysCorrectCapabilities()
        {
            solution = pages.SolutionsList.GetFirstSolution();
            var capabilties = pages.SolutionsList.GetCapabilitiesForSolution(solution);

            pages.SolutionsList.SolutionCanBeViewed(solution);

            var solCapabilites = pages.ViewSolution.GetCapabilities();

            solCapabilites.Should().BeEquivalentTo(capabilties);
        }

        /// <summary>
        /// Ensure a solution displays the same features that the solution list displays
        /// </summary>
        [Fact]
        public void SolutionDisplaysCorrectFeatures()
        {
            solution = pages.SolutionsList.GetFirstSolution();
            var features = pages.SolutionsList.GetFeaturesForSolution(solution);

            pages.SolutionsList.SolutionCanBeViewed(solution);

            var solFeatures = pages.ViewSolution.GetFeatures();

            solFeatures.Should().BeEquivalentTo(features);
        }
    }
}
