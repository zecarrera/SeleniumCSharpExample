using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumCSharpExample.Tests
{
    public class UserFormTests
    {

        private readonly IWebDriver m_Driver = BaseTests.GetDriver();

  
        [Test]
        public void FillOutFormWithValidData_stepByStep()
        {
            var userFormPage = new UserFormPage(m_Driver);
            userFormPage.GoToHomePage();
            userFormPage.SelectTitle("Mr.");
            userFormPage.EnterInitial("j");
            userFormPage.EnterFirstName("Jose");
            userFormPage.EnterMiddleName("carrera");
            userFormPage.SelectGender(true);
            userFormPage.SelectKnownLanguage("English");
            userFormPage.ClickSaveButton();
        }

        [Test]
        public void FillOutFormWithValidData()
        {
            var userFormPage = new UserFormPage(m_Driver);
            userFormPage.GoToHomePage();
            userFormPage.FillOutUserForm("Mr.", "J", "Jose", "carrera", true, "english");
            userFormPage.ClickSaveButton();
        }

        [TearDown]
        public void TearDown()
        {
            m_Driver.Close();
        }
    }
}