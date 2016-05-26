using System;
using OpenQA.Selenium;

namespace SeleniumCSharpExample
{
    public class HomePage
    {
        private readonly IWebDriver m_Driver;
        //private readonly WebDriverWait m_Wait;
        public readonly By searchBox = By.Name("q");

        public HomePage(IWebDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver is coming as null");
            }
            m_Driver = driver;
           // m_Wait = new WebDriverWait(m_Driver, TimeSpan.FromSeconds(30));
        }

        public void GoToHomePage()
        {
            m_Driver.Navigate().GoToUrl("http://www.google.com");
        }

        public void EnterTextToSearchBox(string textInput)
        {
            m_Driver.FindElement(searchBox).SendKeys(textInput);
        }
        
        
    }
}