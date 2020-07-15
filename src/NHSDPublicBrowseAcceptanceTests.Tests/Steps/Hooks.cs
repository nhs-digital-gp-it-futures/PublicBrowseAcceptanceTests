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
        private readonly IObjectContainer _objectContainer;

        public Hooks(ScenarioContext context, IObjectContainer objectContainer)
        {
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
            var test = _objectContainer.Resolve<UITest>();
            test.Driver.Close();
            test.Driver.Quit();

            if (_context.ContainsKey("DeleteSolution") && (bool)_context["DeleteSolution"])
            {
                test.Solution.Delete(test.ConnectionString);
                test.CatalogueItem.Delete(test.ConnectionString);
            }

            await test.AzureBlobStorage.ClearStorage();
        }
    }
}