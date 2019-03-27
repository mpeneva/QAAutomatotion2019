namespace SeleniumHomework.SoftUni
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    public class SeleniumSoftUniSearch
    {   
        private SoftUniPage _softUniPage;

        public SeleniumSoftUniSearch(IWebDriver driver, string url)
        {   
            _softUniPage = new SoftUniPage(driver, url);
            
        }

        /// <summary>
        /// Verify the qa course contains the desired heading tag
        /// </summary>
        public void VerifyQAAutomationCourseHeadingTag()
        {
            IWebElement coursesLink = _softUniPage.Courses;
            coursesLink.Click();

            IWebElement qaCourseLink = _softUniPage.QACourse;
            qaCourseLink.Click();

            IWebElement qaCourseContent = _softUniPage.QACourseContent;
            string expectedHeadingTag = "h1";
            Assert.AreEqual(qaCourseContent.TagName, expectedHeadingTag);

        }
    }
}
