using System.Threading.Tasks;
using BoDi;
using Microsoft.Extensions.Configuration;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
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
        private readonly IObjectContainer _objectContainer;

        public Hooks(UITest test, ScenarioContext context, IObjectContainer objectContainer)
        {
            _test = test;
            _context = context;
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            _objectContainer.RegisterInstanceAs<IConfiguration>(configurationBuilder);
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            _test.Driver.Close();
            _test.Driver.Quit();

            if (_context.ContainsKey("DeleteSolution") && (bool)_context["DeleteSolution"])
            {
                _test.Solution.Delete(_test.ConnectionString);
                _test.CatalogueItem.Delete(_test.ConnectionString);
            }

            await _test.AzureBlobStorage.ClearStorage();
        }
    }
}