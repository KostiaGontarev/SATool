using System;
using System.Text.RegularExpressions;
using CommonClassLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerClasses.Analyzers;

namespace ClientTests
{
    [TestClass]
    public class AnalyzersTest
    {
        [TestMethod]
        public void CYTest()
        {
            var cy = new CYAnalyzer(RequestType.CY) {SiteUrl = "metalchiken.ru"};
            cy.Proceed();
            Assert.AreEqual(cy.Result, "10");
        }

        [TestMethod]
        public void PRTest()
        {
            var pr = new PRAnalyzer(RequestType.CY) { SiteUrl = "metalchiken.ru" };
            pr.Proceed();
            Assert.AreEqual(pr.Result, "2");
        }

        [TestMethod]
        public void LinksTest()
        {
            var links = new LinksAnalyzer(RequestType.CY) { SiteUrl = "metalchiken.ru" };
            links.Proceed();
            Assert.AreNotEqual(links.Result, String.Empty);
        }

        [TestMethod]
        public void CustomersTest()
        {
            var cust = new CustomersAnalyzer(RequestType.CY) { SiteUrl = "metalchiken.ru" };
            cust.Proceed();
            Assert.IsNotNull(cust.Result);
        }
    }
}
