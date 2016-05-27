using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumCSharpExample.Tests
{
    public class LoginTests
    {
        private readonly IWebDriver m_Driver = BaseTests.GetDriver();

        [Test]
        public void LoginWithValidData()
        {
            var loginPage = new LoginPage(m_Driver);
            loginPage.NavigateToLoginPage();
            loginPage.EnterUsername("userTst");
            loginPage.EnterPassword("userPass");
            loginPage.ClickLoginButton();
        }
    }
}