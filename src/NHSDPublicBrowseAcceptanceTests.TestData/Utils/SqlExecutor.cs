using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace NHSDPublicBrowseAcceptanceTests.TestData.Utils
{
    public static class SqlExecutor
    {
        internal static T Read<T>(string connectionString, string query, SqlParameter[] sqlParameters,
            Func<IDataReader, T> mapDataReader)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    //add the params
                    command.Parameters.AddRange(sqlParameters);

                    var reader = command.ExecuteReader();
                    try
                    {
                        return mapDataReader(reader);
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }
        }

        public static IEnumerable<T> Execute<T>(string connectionString, string query, object param)
        {
            IEnumerable<T> returnValue = null;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Policies.RetryPolicy().Execute(() => { returnValue = connection.Query<T>(query, param); });
            }

            return returnValue;
        }

        public static int ExecuteScalar(string connectionString, string query, object param)
        {
            var result = 0;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Policies.RetryPolicy().Execute(() => { result = connection.ExecuteScalar<int>(query, param); });
            }

            return result;
        }
    }
}