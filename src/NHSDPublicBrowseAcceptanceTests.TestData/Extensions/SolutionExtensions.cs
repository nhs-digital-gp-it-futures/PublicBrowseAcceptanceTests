namespace NHSDPublicBrowseAcceptanceTests.TestData.Extensions
{
    using System.Linq;
    using System.Threading.Tasks;
    using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
    using NHSDPublicBrowseAcceptanceTests.TestData.Utils;

    public static class SolutionExtensions
    {
        public static async Task<Solution> RetrieveAsync(this Solution solution, string connectionString)
        {
            var query = Queries.GetSolution;
            return (await SqlExecutor.ExecuteAsync<Solution>(connectionString, query, new { solution.SolutionId })).Single();
        }

        public static async Task CreateAsync(this Solution solution, string connectionString)
        {
            var query = Queries.CreateNewSolution;
            await SqlExecutor.ExecuteAsync<Solution>(connectionString, query, solution);
        }

        public static async Task UpdateAsync(this Solution solution, string connectionString)
        {
            var query = Queries.UpdateSolution;
            await SqlExecutor.ExecuteAsync<Solution>(connectionString, query, solution);
        }

        public static async Task DeleteAsync(this Solution solution, string connectionString)
        {
            var query = Queries.DeleteSolution;
            await SqlExecutor.ExecuteAsync<Solution>(connectionString, query, solution.SolutionId);
        }
    }
}
