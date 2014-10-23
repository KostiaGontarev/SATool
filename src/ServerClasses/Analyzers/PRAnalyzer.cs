using System;
using System.Globalization;
using CommonClassLib;
using System.Net;

namespace ServerClasses.Analyzers
{
    public class PRAnalyzer : Analyzer
    {
        public PRAnalyzer(String url, RequestType type) : base(url, type) { }
        public PRAnalyzer(RequestType type) : base(type) { }

        protected override bool ParseInfo()
        {
            if (!IsReady()) return false;
            try
            {
                Result = GooglePR.MyPR(SiteUrl).ToString(CultureInfo.InvariantCulture);
                Status = AnalyzeResult.Done;
                return true;
            }
            catch (WebException)
            {
                Console.WriteLine("Не удалось соединиться с сервером!");
                Status = AnalyzeResult.NotCriticalError;
                return false;
            }
            catch (Exception)
            {
                Status = AnalyzeResult.CriticalError;
                return false;
            }
        }
        protected override void SetUrlToParse() { }

        public override string ToString()
        {
            return String.Format("PR:{0};", Result);
        }
    }
}
