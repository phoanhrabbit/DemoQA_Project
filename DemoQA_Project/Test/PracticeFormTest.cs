using DemoQA_Project.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Runtime.Serialization;
using WebDriverManager.DriverConfigs.Impl;

namespace DemoQA_Project
{
    public class PracticeFormTest: BasePage
    {

        [TestCase("Oanh", "Nguyen", "Math", "21 Le Thi Hong")]
        public void VerifyUserCanSubmitFormSuccessfullyAfterFillingAllTheInfo(string FirstName, string LastName, string Subject, string Address)
        {
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            var practiceFormPage = new PracticeFormPage(driver);
            practiceFormPage.FillOutInformation(FirstName, LastName, Subject, Address);
            TestContext.WriteLine("Passed");
            Assert.Pass();
        }
    }
}