namespace NHSDPublicBrowseAcceptanceTests.TestData.Utils
{
    using System;
    using System.Data.SqlClient;
    using Polly;

    internal static class Policies
    {
        internal static IAsyncPolicy RetryPolicy()
        {
            return Policy.Handle<SqlException>()
                .Or<TimeoutException>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromMilliseconds(500));
        }
    }
}
