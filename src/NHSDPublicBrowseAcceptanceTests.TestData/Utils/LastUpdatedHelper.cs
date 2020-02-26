using System;
using System.Collections.Generic;
using System.Linq;

namespace NHSDPublicBrowseAcceptanceTests.TestData.Utils
{
    public static class LastUpdatedHelper
    {
        public static void UpdateLastUpdated(DateTime lastUpdated, string table, string whereKey, string whereValue, string connectionString)
        {
            var query = Queries.UpdateLastUpdated;
            query = query.Replace("@table", table).Replace("@whereKey", whereKey);
            SqlExecutor.Execute<object>(connectionString, query, new { whereValue, lastUpdated });
        }

        public static DateTime GetLastUpdated(string table, string whereKey, string whereValue, string connectionString)
        {
            var query = Queries.GetLastUpdated;
            query = query.Replace("@table", table).Replace("@whereKey", whereKey);
            return SqlExecutor.Execute<DateTime>(connectionString, query, new { whereValue }).Single();
        }

        public static DateTime GetLatestUpdated(string[] tables, string whereValue, string connectionString)
        {
            List<DateTime> lastUpdatedValues = new List<DateTime>();
            foreach (var table in tables)
            {
                var whereKeyParsed = table.Equals("Solution") ? "Id" : "SolutionId";
                var result = GetLastUpdated(table, whereKeyParsed, whereValue, connectionString);
                lastUpdatedValues.Add(result);
            }

            return lastUpdatedValues.Max();
        }
    }
}
