using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Utils
{
    public static class DownloadFileUtility
    {
        public static WebClient DownloadFile(string fileName, string downloadPath, string downloadLink, IDictionary<string,string> headers = null)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            downloadLink = TransformLocalHost(downloadLink);
            Directory.CreateDirectory(downloadPath);
            using (var client = new WebClient())
            {
                if(headers != null)
                {
                    foreach (var pair in headers)
                    {
                        client.Headers.Add(pair.Key, pair.Value);
                    }
                }

                Console.WriteLine(downloadLink);

                client.DownloadFile(downloadLink, Path.Combine(downloadPath, fileName));
                return client;
            }
        }

        public static string TransformLocalHost(string urlIn)
        {
            return urlIn
                //.Replace("host.docker.internal", "localhost")
                .Replace("gpitfutures-bc-pb.buyingcatalogue", "host.docker.internal");
        }

        public static bool CompareTwoFiles(string filePath1, string filePath2)
        {
            return new FileInfo(filePath1).Length == new FileInfo(filePath2).Length &&
                   File.ReadAllBytes(filePath1).SequenceEqual(File.ReadAllBytes(filePath2));
        }

        public static IDictionary<string,string> GetHeadersFromDriver(IWebDriver driver)
        {
            var useragent = ((IJavaScriptExecutor)driver).ExecuteScript("return navigator.userAgent;");
            var referer = ((IJavaScriptExecutor)driver).ExecuteScript("return navigator.referer;");
            IDictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("user-agent", (string)useragent);
            headers.Add("referer", (string)referer);
            return headers;
        }
    }
}