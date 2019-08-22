using System;

namespace NHSDPublicBrowseAcceptanceTests.Utils
{
    public static class EnvironmentVariables
    {
        /// <summary>
        /// Get the required environment variables from the current process with default values for running locally
        /// </summary>
        /// <returns></returns>
        public static (string url, string hubUrl, string browser) Get()
        {
            var url = Environment.GetEnvironmentVariable("PBURL", EnvironmentVariableTarget.Process) ?? "http://10.0.75.1:3000";
            var hubUrl = Environment.GetEnvironmentVariable("HUBURL", EnvironmentVariableTarget.Process) ?? "http://localhost:4444/wd/hub";
            var browser = Environment.GetEnvironmentVariable("BROWSER", EnvironmentVariableTarget.Process) ?? "chrome-local";

            return (url, hubUrl, browser);
        }
    }
}
