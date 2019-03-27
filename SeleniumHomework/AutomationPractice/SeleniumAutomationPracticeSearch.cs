using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using System.Text.RegularExpressions;

namespace SeleniumHomework.AutomationPractice
{
    public class SeleniumAutomationPracticeSearch
    {
        private AutomationPracticePage _automationPage;
        private AutomationPracticeRegistration _registrationPage;

        public SeleniumAutomationPracticeSearch(IWebDriver driver, string url)
        {
            _automationPage = new AutomationPracticePage(driver, url);
            _registrationPage = new AutomationPracticeRegistration(driver, url);
        }

        /// <summary>
        /// Verify the proper and successful navigation to the registration page
        /// </summary>        
        public void VerifyRegistrationPageIsOpened()
        {
            IWebElement signInButton = _automationPage.SignInButton;
            signInButton.Click();

            IWebElement mailInput = _automationPage.MailInput;
            mailInput.SendKeys("test_mail2@gmail.com");

            IWebElement createButton = _automationPage.CreateAccountButton;
            createButton.Click();

            string partialTextForVerification = "authentication";
            Assert.True(_automationPage.Driver.Url.Contains(partialTextForVerification));
        }

        public string GetErrorMessageSetup(string jsonFileName)
        {
            var path = Path.GetFullPath(Path.Combine((Directory.GetCurrentDirectory() + "/../../../Jsons"), jsonFileName + ".json"));
            var user = RegistrationUser.FromJson(File.ReadAllText(path));
            return _registrationPage.RegisterUserAccount(user); 
        }

        public void VerifyInvalidUserFirstName()
        {
            string errorMessage = GetErrorMessageSetup("InvalidUserFirstName");
            Assert.True(Regex.IsMatch(errorMessage, ErrorMessages.InvalidUserFirstName));
        }

        public void VerifyInvalidUserLastName()
        {
            string errorMessage = GetErrorMessageSetup("InvalidUserLastName");
            Assert.True(Regex.IsMatch(errorMessage, ErrorMessages.InvalidUserLastName));
        }

        public void VerifyInvalidUserMail()
        {
            string errorMessage = GetErrorMessageSetup("InvalidUserMail");
            Assert.True(Regex.IsMatch(errorMessage, ErrorMessages.InvalidUserEmail));
        }

        public void VerifyInvalidUserPassword()
        {
            string errorMessage = GetErrorMessageSetup("InvalidUserPassword");
            Assert.True(Regex.IsMatch(errorMessage, ErrorMessages.InvalidUserPassword));
        }

        public void VerifyInvalidUserAddressZipCode()
        {
            string errorMessage = GetErrorMessageSetup("InvalidUserZipCode");
            Assert.True(Regex.IsMatch(errorMessage, ErrorMessages.InvalidZipCode));
        }

        public void VerifyInvalidCity()
        {
            string errorMessage = GetErrorMessageSetup("InvalidUserCity");
            Assert.True(Regex.IsMatch(errorMessage, ErrorMessages.InvalidCity));
        }

        public void VerifyInvalidAddress()
        {
            string errorMessage = GetErrorMessageSetup("InvalidUserAddress1");
            Assert.True(Regex.IsMatch(errorMessage, ErrorMessages.InvalidAdress));
        }
    }

}
