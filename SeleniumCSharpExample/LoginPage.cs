using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumCSharpExample
{
    public class LoginPage:Base
    {
        //private readonly IWebDriver m_Driver;

        public LoginPage(IWebDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException();
            }
            Driver = driver;
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            //m_Wait = new WebDriverWait(m_Driver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(Driver, this); //Initializes the driver and page elements
        }

        [FindsBy(How = How.Name, Using = "UserName")]
        public IWebElement UsernameTxt { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement PasswordTxt { get; set; }

        [FindsBy(How = How.Name, Using = "Login")]
        public IWebElement LoginBtn { get; set; }

        public void EnterUsername(string username)
        {
            UsernameTxt.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            PasswordTxt.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginBtn.Click();
        }

        public void PerformLogin(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
        }

        public void NavigateToLoginPage()
        {
            Driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
        }
    }
}