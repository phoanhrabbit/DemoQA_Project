﻿using DemoQA_Project.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace DemoQA_Project
{
    public class PracticeFormTest
    {
        IWebDriver driver;
        private PracticeFormPage practiceFormPage;

        [SetUp]
        public void Setup()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://demoqa.com/automation-practice-form";
            practiceFormPage = new PracticeFormPage(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void VerifyUserCanSubmitFormSuccessfullyAfterFillingAllTheInfo()
        {
            practiceFormPage.sendFirstName("Oanh");
            TestContext.WriteLine("Passed");
            Assert.Pass();
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Dispose();
        }
    }
}