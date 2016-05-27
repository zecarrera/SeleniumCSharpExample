using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumCSharpExample.Tests
{
    public class TableExampleTests
    {
        private readonly IWebDriver m_Driver = BaseTests.GetDriver();

        [Test]
        public void Test()
        {
            var tableExamplePage = new TableExamplePage(m_Driver);
            tableExamplePage.NavigateToUrl();
            Assert.That(tableExamplePage.GetValue("Email",1).Equals("jsmith@gmail.com"));
        }
    }
}