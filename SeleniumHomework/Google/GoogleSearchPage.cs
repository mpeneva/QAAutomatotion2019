namespace SeleniumHomework.Google
{
    using OpenQA.Selenium;
    public partial class GoogleSearchPage : BasePage
    {
        public GoogleSearchPage(IWebDriver driver, string baseUrl) : base(driver, baseUrl)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
        }
    }
}
