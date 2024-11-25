using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Project.Page
{
    public class PracticeFormPage
    {
        private IWebDriver driver;
        //constructor
        public PracticeFormPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        //Locators
        #region Locators
        private IWebElement firstNameField => driver.FindElement(By.Id("firstName"));

        #endregion
        public void sendFirstName(string firstName)
        {
            firstNameField.SendKeys(firstName);
        }
    }
}
