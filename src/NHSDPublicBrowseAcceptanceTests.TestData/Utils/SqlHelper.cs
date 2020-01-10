using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        public static void CreateBlankSolution(Solution solution, SolutionDetail solutionDetail, string connectionString, SolutionContactDetails contactDetails = null)
        {
            // Create a new solution that is absolutely bare bones
            var solutionQuery = Queries.CreateNewSolution;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solution.Id),
                new SqlParameter("@solutionName", solution.Name),
                new SqlParameter("@solutionVersion", solution.Version),
                new SqlParameter("@lastUpdatedBy", Guid.Empty),
                new SqlParameter("@lastUpdated", DateTime.Now),
                new SqlParameter("@publishStatus", solution.PublishedStatusId)
            };

            SqlReader.Read(connectionString, solutionQuery, parameters, DataReaders.NoReturn);

            // Create a record in the SolutionDetail table for the new solution
            var solutionDetailQuery = Queries.CreateSolutionDetail;

            SqlParameter[] newParameters = new SqlParameter[] {
                new SqlParameter("@solutionDetailId", solutionDetail.SolutionDetailId),
                new SqlParameter("@solutionId", solutionDetail.SolutionId),
                new SqlParameter("@lastUpdatedBy", Guid.Empty),
                new SqlParameter("@lastUpdated", DateTime.Now)
            };

            SqlReader.Read(connectionString, solutionDetailQuery, newParameters, DataReaders.NoReturn);

            var updateSolutionDetail = Queries.UpdateSolutionSolutionDetailId;
            SqlParameter[] updateSolId = new SqlParameter[] {
                new SqlParameter("@solutionDetailId", solutionDetail.SolutionDetailId),
                new SqlParameter("@solutionId", solution.Id)
            };

            SqlReader.Read(connectionString, updateSolutionDetail, updateSolId, DataReaders.NoReturn);

            var randomCapabilityQuery = Queries.AddRandomSolutionCapability;

            SqlParameter[] capabilityParams = new SqlParameter[] {                
                new SqlParameter("@solutionId", solution.Id)
            };

            SqlReader.Read(connectionString, randomCapabilityQuery, capabilityParams, DataReaders.NoReturn);

            if (contactDetails != null)
            {
                CreateContactDetails(solution.Id, contactDetails, connectionString);
            }
        }

        public static void DeleteSolution(string solutionId, string connectionString)
        {
            // Remove automated solution
            var solutionQuery = Queries.DeleteSolution;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            SqlReader.Read(connectionString, solutionQuery, parameters, DataReaders.NoReturn);

            // remove solution detail related to the above solution
            var solututionDetailQuery = Queries.DeleteSolutionDetail;

            SqlParameter[] newParameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            SqlReader.Read(connectionString, solututionDetailQuery, newParameters, DataReaders.NoReturn);

            var capsParams = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            }; ;

            SqlReader.Read(connectionString, Queries.DeleteSolutionCapability, capsParams, DataReaders.NoReturn);

            //remove any contact details
            DeleteContactDetailsForSolution(solutionId, connectionString);
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

        public static void DeleteContactDetailsForSolution(string solutionId, string connectionString)
        {
            var query = Queries.DeleteMarketingContact;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@solutionId", solutionId)
            };

            SqlReader.Read(connectionString, query, parameters, DataReaders.NoReturn);
        }

        public static void CreateContactDetails(string solutionId, SolutionContactDetails contactDetail, string connectionString)
        {
            var query = Queries.CreateMarketingContact;

            var names = contactDetail.ContactName.Split(" ");

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@solutionId", solutionId),
                new SqlParameter("@firstName", names.First()),
                new SqlParameter("@lastName", names.Last()),
                new SqlParameter("@email", contactDetail.Email),
                new SqlParameter("@phoneNumber", contactDetail.PhoneNumber),
                new SqlParameter("@department", contactDetail.Department)
            };

            var result = SqlReader.Read(connectionString, query, parameters, DataReaders.NoReturn);
        }

        public static void UpdateLastUpdated(DateTime lastUpdated, string table, string whereKey, string whereValue, string connectionString)
        {
            var query = Queries.UpdateLastUpdated;
            //cant do table names as parameters
            //https://stackoverflow.com/questions/14003241/must-declare-the-table-variable-table
            //can't do the key as a parameter either as it treats it as a string with quotes
            query = query.Replace("@table", table).Replace("@whereKey", whereKey);

            SqlParameter[] newParameters = new SqlParameter[]
            {
                new SqlParameter("@lastUpdated", lastUpdated),
                new SqlParameter("@whereValue", whereValue)
            };

            SqlReader.Read(connectionString, query, newParameters, DataReaders.NoReturn);
        }

        public static DateTime GetLatestLastUpdatedDate(string solutionId, string connectionString)
        {
            var query = Queries.GetLatestLastUpdated;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read(connectionString, query, parameters, DataReaders.GetLatestLastUpdated);

            return result;
        }
    }
}
