namespace NHSDPublicBrowseAcceptanceTests.TestData.Helpers
{
    using System.Linq;
    using System.Threading.Tasks;
    using NHSDPublicBrowseAcceptanceTests.TestData.Utils;

    public static class FrameworkHelper
    {
        public static async Task<string> GetFrameworkIdAsync(string frameworkName, string connectionString)
        {
            return (await SqlExecutor.ExecuteAsync<string>(connectionString, Queries.GetFrameworkId, new { frameworkName })).Single();
        }
    }
}
