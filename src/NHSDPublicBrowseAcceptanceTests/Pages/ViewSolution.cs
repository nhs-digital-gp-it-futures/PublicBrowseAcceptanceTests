using FluentAssertions;
using OpenQA.Selenium;
using Xunit;
using Xunit.Abstractions;

namespace NHSDPublicBrowseAcceptanceTests.Pages
{
    public sealed class ViewSolution : UITest
    {
        IWebElement solution;
        public ViewSolution(ITestOutputHelper helper) : base(helper)
        {
            pages.SolutionsList.WaitForSolutionToBeDisplayed();
        }

        /// <summary>
        /// Ensure that a solution opens when the name is clicked
        /// </summary>
        [Fact(Skip = "Funtionality not currently delivered")]
        public void SolutionCanBeOpened()
        {
            var solutionName = pages.SolutionsList.SolutionCanBeViewed();

            pages.ViewSolution.GetSolutionName().Should().Be(solutionName);
        }

        /// <summary>
        /// Ensure a solution shows the same capabilities that the solution list displays
        /// </summary>
        [Fact(Skip = "Funtionality not currently delivered")]
        public void SolutionDisplaysCorrectCapabilities()
        {
            solution = pages.SolutionsList.GetFirstSolution();
            var capabilties = pages.SolutionsList.GetCapabilitiesForSolution(solution);

            pages.SolutionsList.SolutionCanBeViewed(solution);

            var solCapabilites = pages.ViewSolution.GetCapabilities();

            solCapabilites.Should().BeEquivalentTo(capabilties);
        }
    }
}
