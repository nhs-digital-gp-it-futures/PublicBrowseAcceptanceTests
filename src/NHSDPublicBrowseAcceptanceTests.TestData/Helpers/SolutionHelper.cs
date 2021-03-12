namespace NHSDPublicBrowseAcceptanceTests.TestData.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
    using NHSDPublicBrowseAcceptanceTests.TestData.Utils;

    public static class SolutionHelper
    {
        public static async Task<IEnumerable<string>> RetrieveAllAsync(string connectionString)
        {
            var query = Queries.GetAllSolutions;

            return (await SqlExecutor.ExecuteAsync<Solution>(connectionString, query, null)).Select(s => s.Id);
        }
    }
}
