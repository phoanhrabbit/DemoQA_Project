using DemoQA_Project.Page;
using FluentAssertions;

namespace DemoQA_Project
{
    public class PracticeFormTest: BasePage
    {
        /// <summary>
        /// Happy Flow - Verify the user can submit the form successfully after filling all the information in the form
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Email"></param>
        /// <param name="Mobile"></param>
        /// <param name="Subject"></param>
        /// <param name="Address"></param>
        [TestCase("Oanh", "Nguyen", "oanh@gmail.com", "0978317491", "Maths", "21 Le Thi Hong")]
        public void VerifyUserCanSubmitFormSuccessfullyAfterFillingAllTheInfo(string FirstName, string LastName, string Email, string Mobile, string Subject, string Address)
        {
            driver.Navigate().GoToUrl(url);
            var practiceFormPage = new PracticeFormPage(driver);
            practiceFormPage.FillOutInformation(firstName: FirstName, lastName: LastName, email: Email, mobile: Mobile , subject: Subject, address: Address);
            practiceFormPage.GetSuccessMessage().Should().BeEquivalentTo(MessagesInForm.SuccessMessage);
            TestContext.WriteLine("The form is able to submit successfully!!");
        }
        /// <summary>
        /// Unhappy Flow - Verify the user can receive error color when input without mobile number
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Email"></param>
        /// <param name="Mobile"></param>
        /// <param name="Subject"></param>
        /// <param name="Address"></param>
        [TestCase("Oanh", "Nguyen", "oanh@gmail.com", "", "Maths", "21 Le Thi Hong")]
        public void VerifyFormShouldPresentErrorWhenUserInputWithoutMobile(string FirstName, string LastName, string Email, string Mobile, string Subject, string Address)
        {
            driver.Navigate().GoToUrl(url);
            var practiceFormPage = new PracticeFormPage(driver);
            practiceFormPage.FillOutInformation(firstName: FirstName, lastName: LastName, email: Email, mobile: Mobile, subject: Subject, address: Address);
            practiceFormPage.GetColorErrorMobileField.Should().Contain("rgba(73, 80, 87, 1)", "Color is not matched. Please check again!");
            TestContext.WriteLine($"The Error color is being displayed as {practiceFormPage.GetColorErrorMobileField}");
        }
    }
}