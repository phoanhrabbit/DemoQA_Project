using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
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
        private IWebElement dateField => driver.FindElement(By.CssSelector("div[aria-label='Choose Sunday, September 5th, 1999']"));
        private IWebElement subjectField => driver.FindElement(By.XPath("//input[@id='subjectsInput']"));
        // option Reading
        private IWebElement hobbiesReadingField => driver.FindElement(By.XPath("(//div[@class='custom-control custom-checkbox custom-control-inline'])[1]"));
        private IWebElement FileField => driver.FindElement(By.CssSelector("#uploadPicture"));
        private IWebElement currentAddressField => driver.FindElement(By.CssSelector("#currentAddress"));
        private IWebElement dropdownStateField => driver.FindElement(By.XPath("(//div[@class=' css-1hwfws3'])[1]"));
        private IWebElement dropdownStateOption => driver.FindElement(By.XPath("//div[text()='NCR']"));
        private IWebElement dropdownCityField => driver.FindElement(By.XPath("(//div[@class=' css-1wa3eu0-placeholder'])[1]"));
        private IWebElement dropdownCityOption => driver.FindElement(By.XPath("//div[text()='Delhi']"));
        private IWebElement submitButton => driver.FindElement(By.CssSelector("#submit"));
        private IWebElement SuccessMessage => driver.FindElement(By.CssSelector("#example-modal-sizes-title-lg"));






        #endregion
        public void FillOutInformation(string firstName, string lastName, string email, string mobile, string subject, string address)
        {
            // enter first name + last name
            firstNameField.SendKeys(firstName);
            lastNameField.SendKeys(lastName);
            // enter email
            emailField.SendKeys(email);
            // select gender
            genderField.Click();
            // enter mobile
            mobileField.SendKeys(mobile);
            // select date of birth
            dateOfBirthField.Click();
            yearField.Click();
            monthField.Click();
            dateField.Click();
            //enter subject
            subjectField.SendKeys(subject);
            subjectField.SendKeys(Keys.Enter);
            //scroll down to bottom
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            //select hobbies
            WaitForElementToBeClicked(driver, hobbiesReadingField);
            hobbiesReadingField.Click();
            //upload file
            FileField.SendKeys(Environment.CurrentDirectory.Replace(@"\", @"/") + "/File/auto.png");
            //enter address
            currentAddressField.SendKeys(address);
            //select from state dropdown 
            dropdownStateField.Click();
            dropdownStateOption.Click();
            //select from city dropdown 
            dropdownCityField.Click();
            dropdownCityOption.Click();
            //Click submit button
            submitButton.Click();
        }
        public string GetColorErrorMobileField => mobileField.GetCssValue("color");
        public string GetSuccessMessage() => SuccessMessage.Text;
        public bool IsElementPresent(By element, int waitTime)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitTime);
            var isPresent = driver.FindElement(element).Displayed;
            return true;
        }
        public IWebElement WaitForElementToBeClicked(IWebDriver driver, IWebElement element)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                return wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (NoSuchElementException ex)
            {
                throw new Exception($"The {element} is not clickable. Please try again!");
            }
        }
        /// <summary>
        /// Get all elements from dropdown list
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public List<string> GetAllItemsDropDown(IWebElement element)
        {
            List<string> dropdownItems = new List<string>();
            var select = new SelectElement(element).Options;
            select.ToList().ForEach(x => dropdownItems.Add(x.Text));
            return dropdownItems;
        }
        public void SelectInDropDown(IWebElement element, string option)
        {
            var options = element.FindElements(By.XPath("child::*"));
            var webElement = options.FirstOrDefault(p => p.Equals(option));
            element.Click();
        }
    }
}
