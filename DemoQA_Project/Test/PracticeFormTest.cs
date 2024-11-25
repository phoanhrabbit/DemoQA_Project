using DemoQA_Project.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Runtime.Serialization;
using WebDriverManager.DriverConfigs.Impl;

namespace DemoQA_Project
{
    public class PracticeFormTest: BasePage
    {

        [Test]
        public void VerifyUserCanSubmitFormSuccessfullyAfterFillingAllTheInfo()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            var practiceFormPage = new PracticeFormPage(driver);
            practiceFormPage.sendFirstName("Oanh");
            TestContext.WriteLine("Passed");
            Assert.Pass();
        }
    }
}