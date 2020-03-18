using System.Threading.Tasks;
using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly UITest _test;

        public Hooks(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            _test.Driver.Close();
            _test.Driver.Quit();

            if (_context.ContainsKey("DeleteSolution") && (bool) _context["DeleteSolution"])
                _test.Solution.Delete(_test.ConnectionString);

            await _test.AzureBlobStorage.ClearStorage();
        }
    }
}