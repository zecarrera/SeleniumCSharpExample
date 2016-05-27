using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpExample
{
    public class UserFormPage:Base
    {
        //private readonly WebDriverWait m_Wait;
        public const string BaseUrl = "http://executeautomation.com/demosite/index.html";

        [FindsBy(How = How.Id, Using = "TitleId")]
        public IWebElement TitleDropDown { get; set; }

        [FindsBy(How=How.Name, Using= "Initial")]
        public IWebElement InitialTxt { get; set;}

        [FindsBy(How = How.Name, Using = "FirstName")]
        public IWebElement FirstNameTxt { get; set; }

        [FindsBy(How = How.Name, Using = "MiddleName")]
        public IWebElement MiddleNameTxt { get; set; }

        [FindsBy(How = How.Name, Using = "Male")]
        public IWebElement GenderMale { get; set; }

        [FindsBy(How = How.Name, Using = "Female")]
        public IWebElement GenderFemale { get; set; }

        [FindsBy(How = How.Name, Using = "english")]
        public IWebElement EnglishLanguage { get; set; }

        [FindsBy(How = How.Name, Using = "Hindi")]
        public IWebElement HindiLanguage { get; set; }

        [FindsBy(How = How.Name, Using = "Save")]
        public IWebElement SaveBtn { get; set; }

        public UserFormPage(IWebDriver driver)
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

        public void GoToHomePage()
        {
            Driver.Navigate().GoToUrl(BaseUrl);
        }

        public void EnterInitial(string textInput)
        {
            InitialTxt.SendKeys(textInput);
        }

        public void EnterFirstName(string textInput)
        {
            FirstNameTxt.SendKeys(textInput);
        }

        public void EnterMiddleName(string textInput)
        {
            MiddleNameTxt.SendKeys(textInput);
        }

        public void SelectGender(bool isMale)
        {
            var gender = GenderFemale;
            if (isMale)
            {
                gender = GenderMale;
            }
            gender.Click();
        }

        public void SelectKnownLanguage(string language)
        {
            var elementToCheck = EnglishLanguage;
            if(language.ToLower().Equals("hindi"))
            {
                elementToCheck = HindiLanguage;
            }
            if(!elementToCheck.Selected)
                elementToCheck.Click();
        }

        public void ClickSaveButton()
        {
            SaveBtn.Click();
        }

        public void SelectTitle(string input)
        {
            new SelectElement(TitleDropDown).SelectByText(input);
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