using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpExample
{
    public class UserFormPage
    {
        private readonly IWebDriver m_Driver;
        //private readonly WebDriverWait m_Wait;
        public const string BaseUrl = "http://executeautomation.com/demosite/index.html";
        public readonly By Title = By.Name("TitleId");
        public readonly By Initial = By.Name("Initial");
        public readonly By FirstName = By.Name("FirstName");
        public readonly By MiddleName = By.Name("MiddleName");
        public readonly By GenderMale = By.Name("Male");
        public readonly By GenderFemale = By.Name("Female");
        public readonly By EnglishLanguage = By.Name("english");
        public readonly By HindiLanguage = By.Name("Hindi");
        public readonly By SaveButton = By.Name("Save");

        public UserFormPage(IWebDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException();
            }
            m_Driver = driver;
            m_Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            //m_Wait = new WebDriverWait(m_Driver, TimeSpan.FromSeconds(30));
        }

        public void GoToHomePage()
        {
            m_Driver.Navigate().GoToUrl(BaseUrl);
        }

        public void EnterInitial(string textInput)
        {
            m_Driver.FindElement(Initial).SendKeys(textInput);
        }

        public void EnterFirstName(string textInput)
        {
            m_Driver.FindElement(FirstName).SendKeys(textInput);
        }

        public void EnterMiddleName(string textInput)
        {
            m_Driver.FindElement(MiddleName).SendKeys(textInput);
        }

        public void SelectGender(bool isMale)
        {
            var gender = GenderFemale;
            if (isMale)
            {
                gender = GenderMale;
            }
            m_Driver.FindElement(gender).Click();
        }

        public void SelectKnownLanguage(string language)
        {
            var elementToCheck = EnglishLanguage;
            if(language.ToLower().Equals("hindi"))
            {
                elementToCheck = HindiLanguage;
            }
            if(!m_Driver.FindElement(elementToCheck).Selected)
                m_Driver.FindElement(elementToCheck).Click();
        }

        public void ClickSaveButton()
        {
            m_Driver.FindElement(SaveButton).Click();
        }

        public void SelectTitle(string input)
        {
            new SelectElement(m_Driver.FindElement(Title)).SelectByText(input);
        }

        public void FillOutUserForm(string title, string initial, string firstName, string middleName, bool isMale,
            string language)
        {
            SelectTitle(title);
            EnterInitial(initial);
            EnterFirstName(firstName);
            EnterMiddleName(middleName);
            SelectGender(isMale);
            SelectKnownLanguage(language);
        }
    }
}