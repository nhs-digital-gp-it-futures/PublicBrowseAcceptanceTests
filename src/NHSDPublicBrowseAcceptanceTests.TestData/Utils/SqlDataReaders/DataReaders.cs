using System;
using System.Data;
using NHSDPublicBrowseAcceptanceTests.TestData.Solutions;

namespace NHSDPublicBrowseAcceptanceTests.TestData.Utils.SqlDataReaders
{
    public static class DataReaders
    {
        internal static object NoReturn(IDataReader dr)
        {
            dr.Read();
            return null;
        }

        internal static string GetSolutionSummary(IDataReader dr)
        {
            dr.Read();
            return dr["Summary"].ToString();
        }

        internal static string GetSolutionDescription(IDataReader dr)
        {
            dr.Read();
            return dr["FullDescription"].ToString();
        }

        internal static string GetFeatures(IDataReader dr)
        {
            dr.Read();
            return dr["Features"].ToString();
        }

        internal static int GetSupplierStatus(IDataReader dr)
        {
            dr.Read();
            int.TryParse(dr["SupplierStatusId"].ToString(), out int result);
            return result;
        }

        internal static int GetCount(IDataReader dr)
        {
            dr.Read();
            int.TryParse(dr["count"].ToString(), out int result);
            return result;
        }

        internal static SolutionDto GetSolutionObject(IDataReader dr)
        {
            dr.Read();

            SolutionDto dto = new SolutionDto
            {
                Id = dr["Id"].ToString(),
                Name = dr["Name"].ToString(),
                Summary = dr["Summary"].ToString(),
                LastUpdated = DateTime.Parse(dr["LastUpdated"].ToString()),
                SupplierName = dr["SupplierName"].ToString(),
                AboutUrl = dr["AboutUrl"].ToString(),
                FullDescription = dr["FullDescription"].ToString(),
            };

            SolutionContactDetails contactDetails = new SolutionContactDetails
            {
                ContactName = dr["Contactname"].ToString(),
                Email = dr["Email"].ToString(),
                PhoneNumber = dr["PhoneNumber"].ToString(),
                Department = dr["Department"].ToString()
            };

            dto.SolutionContactDetails = contactDetails;

            return dto;
        }

        internal static string GetSolutionCapabilities(IDataReader dr)
        {
            dr.Read();
            return dr["Capabilities"].ToString();
        }

        /// <summary>
        /// The Last Updated Date as seen on the UI and API is the latest of a number of dates
        /// Each table in the DB has it's own LastUpdated column
        /// And in order to display accurate information, we need to find the latest of those dates
        /// At the time of writing, the only dates included in this calculation are:
        /// -Solution
        /// -SolutionDetail
        /// -MarketingContact
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>DateTime</returns>
        internal static DateTime GetLatestLastUpdated(IDataReader dr)
        {
            dr.Read();
            //var SolutionLastUpdated = dr["SolutionLastUpdated"].ToString();
            //var SolutionDetailLastUpdated = dr["SolutionDetailLastUpdated"].ToString();
            //var MarketingContactLastUpdated = dr["MarketingContactLastUpdated"].ToString();
            var val = dr["LastestLastUpdated"].ToString();
            return Convert.ToDateTime(val);
        }
    }
}
