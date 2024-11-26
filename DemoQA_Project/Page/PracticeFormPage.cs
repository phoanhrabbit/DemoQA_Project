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
        private IWebElement lastNameField => driver.FindElement(By.CssSelector("#lastName"));
        private IWebElement emailField => driver.FindElement(By.CssSelector("#userEmail"));
        private IWebElement genderField => driver.FindElement(By.XPath("//label[@for='gender-radio-2']"));
        private IWebElement mobileField => driver.FindElement(By.CssSelector("#userNumber"));
        // date of birth elements
        private IWebElement dateOfBirthField => driver.FindElement(By.CssSelector("#dateOfBirthInput"));
        // Year field
        private IWebElement yearField => driver.FindElement(By.XPath("//option[text()='1999']"));
        //Month field
        private IWebElement monthField => driver.FindElement(By.XPath("//option[text()='September']"));
        //Date field
        private IWebElement dateField => driver.FindElement(By.XPath("//div[@class='react-datepicker__week']/[7]"));
        private IWebElement subjectField => driver.FindElement(By.XPath("//input[@id='subjectsInput']"));
        // option Sports
        private IWebElement hobbiesSportsField => driver.FindElement(By.CssSelector("#hobbies-checkbox-1"));
        // option Music
        private IWebElement hobbiesMusicField => driver.FindElement(By.CssSelector("#hobbies-checkbox-3"));
        private IWebElement FileField => driver.FindElement(By.CssSelector("#uploadPicture"));


        #endregion
        public void FillOutInformation(string firstName, string lastName, string subject)
        {
            firstNameField.SendKeys(firstName);
            lastNameField.SendKeys(lastName);
            dateOfBirthField.Click();
            yearField.Click();
            monthField.Click();
            dateField.Click();
            //click out the date time picker
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.body.click();");
            subjectField.SendKeys(subject);
            hobbiesSportsField.Click();
            hobbiesMusicField.Click();
            FileField.SendKeys(Environment.CurrentDirectory.Replace(@"\", @"/") + "/File/File/auto.png");



            Thread.Sleep(30000);

        }
    }
}
