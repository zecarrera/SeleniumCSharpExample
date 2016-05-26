using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumCSharpExample.Tests
{
    public class HomePageTests
    {

        private readonly IWebDriver m_Driver = BaseTests.GetDriver();

  
        [Test]
        public void NavigateToHomePage()
        {
            HomePage homePage = new HomePage(m_Driver);
            homePage.GoToHomePage();
            homePage.EnterTextToSearchBox("jose");
        }

        [TearDown]
        public void TearDown()
        {
            m_Driver.Close();
        }
    }
}