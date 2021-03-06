﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using CommonClassLib;
using System.Net;
using System.IO;

namespace ServerClasses.Analyzers
{
    public class CustomersAnalyzer : Analyzer
    {
        public CustomersAnalyzer(String url, RequestType type) : base(url, type) { }
        public CustomersAnalyzer(RequestType type) : base(type) { }

        protected override bool ParseInfo()
        {
            if (!IsReady()) return false;
            Status = AnalyzeResult.Analyzing;

            try
            {
                var sDocument = LoadParsingPage();
                var doc = new HtmlDocument();
                doc.Load(new StringReader(sDocument));
                String hosts = doc.DocumentNode.SelectSingleNode(@"//body/table[4]/tr/tr/tr/tr/td[6]").InnerText;
                String views = doc.DocumentNode.SelectSingleNode(@"//body/table[4]/tr/tr/td[6]").InnerText;
                Result = String.Format("{0}:{1}", hosts, views);
                return true;
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
                Result = String.Empty;
                Status = AnalyzeResult.NotCriticalError;
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Status = AnalyzeResult.CriticalError;
                Result = String.Empty;
                return false;
            }
        }

        protected override void SetUrlToParse()
        {
            UrlToParse = String.Format(@"http://www.liveinternet.ru/stat/{0}/", SiteUrl);
        }
    }
}
