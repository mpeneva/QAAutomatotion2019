using OpenQA.Selenium;

namespace SeleniumHomework.AutomationPractice
{
    public partial class AutomationPracticePage : BasePage
    {
        public AutomationPracticePage(IWebDriver driver, string baseUrl) : base(driver, baseUrl)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
        }
    }
}
