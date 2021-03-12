namespace NHSDPublicBrowseAcceptanceTests.TestData.Utils
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Dapper;

    public static class SqlExecutor
    {
        public static async Task<IEnumerable<T>> ExecuteAsync<T>(string connectionString, string query, object param)
        {
            IEnumerable<T> returnValue = null;
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                await Policies.RetryPolicy().ExecuteAsync(async () => { returnValue = await connection.QueryAsync<T>(query, param); });
            }

            return returnValue;
        }

        public static async Task<int> ExecuteScalarAsync(string connectionString, string query, object param)
        {
            var result = 0;
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                await Policies.RetryPolicy().ExecuteAsync(async () => { result = await connection.ExecuteScalarAsync<int>(query, param); });
            }

            return result;
        }
    }
}
