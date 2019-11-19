using System;
using System.Data;
using System.Data.SqlClient;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;
using NHSDPublicBrowseAcceptanceTests.TestData.Utils.SqlDataReaders;

namespace NHSDPublicBrowseAcceptanceTests.TestData.Utils
{
    public static class SqlHelper
    {
        public static string GetSolutionSummary(string solutionId, string connectionString)
        {
            var query = Queries.GetSolution;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read(connectionString, query, parameters, DataReaders.GetSolutionSummary);

            return result;
        }

        public static string GetSolutionDescription(string solutionId, string connectionString)
        {
            var query = Queries.GetSolution;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read(connectionString, query, parameters, DataReaders.GetSolutionDescription);

            return result;
        }

        public static void CreateBlankSolution(Solution solution, string connectionString)
        {
            // Create a new solution that is absolutely bare bones
            var solutionQuery = Queries.CreateNewSolution;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solution.Id),
                new SqlParameter("@solutionName", solution.Name),
                new SqlParameter("@solutionVersion", solution.Version)
            };

            SqlReader.Read(connectionString, solutionQuery, parameters, DataReaders.NoReturn);
        }

        public static void DeleteSolution(string solutionId, string connectionString)
        {
            // Remove automated solution
            var solutionQuery = Queries.DeleteSolution;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            SqlReader.Read(connectionString, solutionQuery, parameters, DataReaders.NoReturn);
        }

        private static void NoReturn(IDataReader arg)
        {
            throw new NotImplementedException();
        }

        public static int GetSolutionStatus(string solutionId, string connectionString)
        {
            var query = Queries.GetSolution;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read(connectionString, query, parameters, DataReaders.GetSupplierStatus);

            return result;
        }

        public static int GetNumberOfSolutions(string connectionString)
        {
            var query = Queries.GetSolutionsCount;
            var result = SqlReader.Read(connectionString, query, new SqlParameter[0], DataReaders.GetCount);

            return result;
        }

        public static int GetNumberOfFoundationSolutions(string connectionString)
        {
            var query = Queries.GetFoundationSolutionsCount;
            var result = SqlReader.Read(connectionString, query, new SqlParameter[0], DataReaders.GetCount);

            return result;
        }

        public static int GetNumberOfNonFoundationSolutions(string connectionString)
        {
            var query = Queries.GetNonFoundationSolutionsCount;
            var result = SqlReader.Read(connectionString, query, new SqlParameter[0], DataReaders.GetCount);

            return result;
        }

        public static int GetSolutionsWithCapabilityCount(string capabilityName, string connectionString)
        {
            var query = Queries.GetSolutionsWithCapabilityCount;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@capabilityName", capabilityName)
            };

            var result = SqlReader.Read(connectionString, query, parameters, DataReaders.GetCount);

            return result;
        }

        public static SolutionDto GetSolutionDetailsObject(string solutionId, string connectionString)
        {
            var query = Queries.GetSingleSolution;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read(connectionString, query, parameters, DataReaders.GetSolutionObject);

            return result;
        }

        public static string GetSolutionCapabilities(string solutionId, string connectionString)
        {
            var query = Queries.GetSingleSolutionCapabilities;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read(connectionString, query, parameters, DataReaders.GetSolutionCapabilities);

            return result;
        }
    }
}
