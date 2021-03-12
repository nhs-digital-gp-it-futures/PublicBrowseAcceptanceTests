namespace NHSDPublicBrowseAcceptanceTests.TestData.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class LastUpdatedHelper
    {
        public static async Task UpdateLastUpdated(
            DateTime lastUpdated,
            string table,
            string whereKey,
            string whereValue,
            string connectionString)
        {
            var query = Queries.UpdateLastUpdated;
            query = query.Replace("@table", table).Replace("@whereKey", whereKey);
            await SqlExecutor.ExecuteAsync<object>(connectionString, query, new { whereValue, lastUpdated });
        }

        public static async Task<DateTime> GetLastUpdatedAsync(string table, string whereKey, string whereValue, string connectionString)
        {
            var query = Queries.GetLastUpdated;
            query = query.Replace("@table", table).Replace("@whereKey", whereKey);
            return (await SqlExecutor.ExecuteAsync<DateTime>(connectionString, query, new { whereValue })).Single();
        }

        public static async Task<DateTime> GetLatestUpdatedAsync(string[] tables, string whereValue, string connectionString)
        {
            List<DateTime> lastUpdatedValues = new();
            foreach (var table in tables)
            {
                var whereKeyParsed = table.Equals("Solution") ? "Id" : "SolutionId";
                var result = await GetLastUpdatedAsync(table, whereKeyParsed, whereValue, connectionString);
                lastUpdatedValues.Add(result);
            }

            return lastUpdatedValues.Max();
        }
    }
}
