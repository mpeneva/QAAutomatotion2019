namespace SeleniumHomework.Google
{
    using NUnit.Framework;
    using OpenQA.Selenium;

    public class SeleniumGoogleSearch
    {
        private GoogleSearchPage _googlePage;
        public SeleniumGoogleSearch(IWebDriver driver, string url)
        {
            _googlePage = new GoogleSearchPage(driver, url);

        }

        /// <summary>
        /// Verify that google seach for 'Selenium' is the correct one and the expected selenium url is opened/clicked
        /// </summary>
        public void VerifySeleniumGoogleSearch()
        {
            string text = "Selenium";
            IWebElement googleTextField = _googlePage.GoogleSearchField;
            googleTextField.SendKeys(text);
            googleTextField.Submit();

            string textForVerifiation = "Selenium - Web Browser Automation";

            IWebElement googleSeleniumLink = _googlePage.SeleniumLink;
            Assert.True(googleSeleniumLink.Text.Contains(textForVerifiation));

            string linkForVerification = "https://www.seleniumhq.org/";
            googleSeleniumLink.Click();
            Assert.True(_googlePage.Driver.Url.Contains(linkForVerification));
        }

    }
}
