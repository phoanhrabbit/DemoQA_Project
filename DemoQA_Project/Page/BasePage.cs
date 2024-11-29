using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace DemoQA_Project.Page
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected string url = "https://demoqa.com/automation-practice-form";

        [SetUp]
        public void SetUp()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Dispose();
        }
    }
}
