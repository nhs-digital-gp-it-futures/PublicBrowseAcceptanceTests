using NHSDPublicBrowseAcceptanceTests.Objects.Pages;

namespace NHSDPublicBrowseAcceptanceTests.Objects
{
    public sealed class PageObjects
    {
        public PageCollection Pages;

        public PageObjects()
        {
            Pages = new PageCollection
            {
                SolutionsList = new SolutionsList(),
                CapabilityFilter = new CapabilityFilter(),
                Common = new Common(),
                Homepage = new Homepage(),
                Footer = new Footer(),
                Header = new Header(),
                BrowseSolutions = new BrowseSolutions(),
                ViewSingleSolution = new ViewSingleSolution(),
                BuyersGuide = new BuyersGuide(),
                Login = new Login()
            };
        }
    }
}