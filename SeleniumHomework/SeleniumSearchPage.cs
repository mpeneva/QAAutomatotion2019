namespace SeleniumHomework
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using SeleniumHomework.AutomationPractice;
    using SeleniumHomework.Google;
    using SeleniumHomework.SoftUni;
    using System.IO;
    using System.Reflection;
    public class SeleniumSearchPage
    {
        private SeleniumSoftUniSearch _seleniumSoftUniPage;
        private SeleniumGoogleSearch _seleniumGooglePage;
        private SeleniumAutomationPracticeSearch _automationPracticePage;
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void VerifySoftUniSearch()
        {
            _seleniumSoftUniPage = new SeleniumSoftUniSearch(_driver, "https://softuni.bg");
            _seleniumSoftUniPage.VerifyQAAutomationCourseHeadingTag();
        }

        [Test]
        public void VerifyGoogleSearch()
        {
            _seleniumGooglePage = new SeleniumGoogleSearch(_driver, "https://www.google.com");
            _seleniumGooglePage.VerifySeleniumGoogleSearch();
        }

        [Test]
        public void VerifyAutomationPractice()
        {
            _automationPracticePage = new SeleniumAutomationPracticeSearch(_driver, "http://automationpractice.com/index.php");
            _automationPracticePage.VerifyRegistrationPageIsOpened();
            _automationPracticePage.VerifyInvalidUserFirstName();
            _automationPracticePage.VerifyInvalidUserLastName();
            _automationPracticePage.VerifyInvalidUserMail();
            _automationPracticePage.VerifyInvalidUserPassword();
            _automationPracticePage.VerifyInvalidUserAddressZipCode();
            _automationPracticePage.VerifyInvalidCity();
            _automationPracticePage.VerifyInvalidAddress();
        }
    }
}
