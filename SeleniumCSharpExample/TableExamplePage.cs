using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumCSharpExample.Utils;

namespace SeleniumCSharpExample
{
    public class TableExamplePage:Base
    {

        public TableExamplePage(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            PageFactory.InitElements(Driver, this); //Initializes the driver and page elements
        }

        [FindsBy(How =How.Id, Using = "table1")]
        public IWebElement TableOne { get; set; }

        public void NavigateToUrl()
        {
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/tables");
        }


        public string GetValue(string columnName, int rowNumber)
        {
            var test = new Utilties();
            test.ReadTable(TableOne);
            return test.ReadCell(columnName,rowNumber);
        }
    }
}