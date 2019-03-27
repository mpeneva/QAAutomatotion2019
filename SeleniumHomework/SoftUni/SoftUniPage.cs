namespace SeleniumHomework.SoftUni
{
    using OpenQA.Selenium;
    public partial class SoftUniPage : BasePage
    {
        public SoftUniPage(IWebDriver driver, string baseUrl) : base(driver, baseUrl)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
        }
    }
}
