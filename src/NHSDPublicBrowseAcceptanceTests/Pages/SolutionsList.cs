using FluentAssertions;
using Xunit;

namespace NHSDPublicBrowseAcceptanceTests.Pages
{
    public sealed class SolutionsList : UITest
    {
        public SolutionsList()
        {
            pages.SolutionsList.WaitForSolutionToBeDisplayed();
        }

        [Fact]
        public void SolutionDisplaysName()
        {
            pages.SolutionsList.SolutionHasTitle().Should().BeTrue();
        }

        [Fact(Skip = "Funtionality not currently delivered")]
        public void SolutionCanBeOpened()
        {            
            var solutionName = pages.SolutionsList.SolutionCanBeViewed();

            pages.ViewSolution.GetSolutionName().Should().Be(solutionName);
        }
    }
}
