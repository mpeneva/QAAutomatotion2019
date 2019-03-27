namespace SeleniumHomework.SoftUni
{
    using OpenQA.Selenium;
    public partial class SoftUniPage
    {
        const string courseName = "QA Automation - януари 2019";
        public IWebElement Courses => Wait.Until((d) => { return d.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[1]/ul/li[2]")); });
        public IWebElement QACourse => Wait.Until((d) => { return d.FindElement(By.PartialLinkText(courseName)); });
        public IWebElement QACourseContent => Wait.Until((d) => { return d.FindElement(By.XPath("/html/body/div[2]/header/h1")); });
    }
}
