namespace SeleniumHomework.Google
{
    using OpenQA.Selenium;
    public partial class GoogleSearchPage
    {
        const string textForVerifiation = "Selenium - Web Browser Automation";
        public IWebElement SeleniumLink => Wait.Until((d) => { return d.FindElement(By.PartialLinkText(textForVerifiation)); });

        public IWebElement GoogleSearchField => Wait.Until((d) => { return d.FindElement(By.XPath("/html/body/div/div[3]/form/div[2]/div/div[1]/div/div[1]/input")); });
    }
}
