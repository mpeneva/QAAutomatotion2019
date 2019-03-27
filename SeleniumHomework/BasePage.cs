namespace SeleniumHomework
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;

    public abstract class BasePage
    {
        private IWebDriver _driver;
        private string _baseUrl;

        public BasePage(IWebDriver driver, string baseUrl)
        {
            _driver = driver;
            _baseUrl = baseUrl;
        }

        public IWebDriver Driver => _driver;

        public string BaseUrl => _baseUrl;

        public WebDriverWait Wait => new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
    }
}
