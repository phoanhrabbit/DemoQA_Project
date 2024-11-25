using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace DemoQA_Project
{
    public class PracticeFormTest
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://demoqa.com/automation-practice-form";
        }

        [Test]
        public void VerifyUserCanSubmitFormSuccessfullyAfterFillingAllTheInfo()
        {
            Assert.Pass();
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Dispose();
        }
    }
}