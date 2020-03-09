using System.Threading.Tasks;
using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
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
            _test.driver.Close();
            _test.driver.Quit();

            if (_context.ContainsKey("DeleteSolution") && (bool) _context["DeleteSolution"])
                _test.solution.Delete(_test.ConnectionString);

            await _test.AzureBlobStorage.ClearStorage();
        }
    }
}