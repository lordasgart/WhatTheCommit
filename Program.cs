using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using Flurl.Http;

namespace WhatTheCommit
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                await GetTheCommitMessageFromWhatTheCommit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static async Task GetTheCommitMessageFromWhatTheCommit()
        {
            var htmlString = await "http://whatthecommit.com".GetAsync().ReceiveString();

            Trace.WriteLine(htmlString);

            XmlDocument htmlResponse = new XmlDocument();

            //Remove non-XML-compatible HTML elements
            htmlResponse.LoadXml(htmlString.Replace("<!doctype html>",string.Empty).Replace("<meta charset=\"UTF-8\">", string.Empty));

            //Get the commit message from the corresponding HTML element
            var commitMessage = htmlResponse.SelectSingleNode("/html/body/div/p").InnerText.Trim();

            //Output commit message
            Console.WriteLine(commitMessage);

            //Write commit message to history
            var historyFileName = "history.txt";

            if (!File.Exists(historyFileName))
            {
                File.Create(historyFileName);
            }

            File.AppendAllLines(historyFileName, new [] {commitMessage});
        }
    }
}
