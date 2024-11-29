using OpenQA.Selenium;

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
        /// <summary>
        ///  Fill all the information of the form
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="mobile"></param>
        /// <param name="subject"></param>
        /// <param name="address"></param>
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
        /// <summary>
        /// Get the error color of the mobile number field
        /// </summary>
        public string GetColorErrorMobileField => mobileField.GetCssValue("color");
        /// <summary>
        /// Get the text of the success message when submit the form successfully
        /// </summary>
        /// <returns></returns>
        public string GetSuccessMessage() => SuccessMessage.Text;
    }
}
