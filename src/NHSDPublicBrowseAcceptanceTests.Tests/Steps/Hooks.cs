namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps
{
    using System.Threading.Tasks;
    using BoDi;
    using Microsoft.Extensions.Configuration;
    using NHSDPublicBrowseAcceptanceTests.TestData.Extensions;
    using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext context;
        private readonly IObjectContainer objectContainer;

        public Hooks(ScenarioContext context, IObjectContainer objectContainer)
        {
            this.context = context;
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            objectContainer.RegisterInstanceAs<IConfiguration>(configurationBuilder);
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            var test = objectContainer.Resolve<UITest>();
            test.Driver.Quit();

            if (context.ContainsKey("DeleteSolution") && (bool)context["DeleteSolution"])
            {
                await test.Solution.DeleteAsync(test.ConnectionString);
                await test.CatalogueItem.DeleteAsync(test.ConnectionString);
            }
        }
    }
}
