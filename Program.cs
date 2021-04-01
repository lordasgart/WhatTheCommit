using System;
using System.Threading.Tasks;
using System.Xml;
using Flurl.Http;

namespace WhatTheCommit
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var result = await "http://whatthecommit.com".GetAsync().ReceiveString();

            Console.WriteLine(result);

            XmlDocument htmlResponse = new XmlDocument();
            htmlResponse.LoadXml(result.Replace("<!doctype html>",string.Empty).Replace("<meta charset=\"UTF-8\">", string.Empty));

            var commitMessage = htmlResponse.SelectSingleNode("/html/body/div/p").InnerText.Trim();

            Console.WriteLine(commitMessage);
        }
    }
}
