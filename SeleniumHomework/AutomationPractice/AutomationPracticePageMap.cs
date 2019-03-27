using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumHomework.AutomationPractice
{
    public partial class AutomationPracticePage
    {
        public IWebElement SignInButton => Wait.Until((d) => { return d.FindElement(By.ClassName("header_user_info")); });        
        public IWebElement MailInput => Wait.Until((d) => { return d.FindElement(By.Id("email_create")); });
        public IWebElement CreateAccountButton => Wait.Until((d) => { return d.FindElement(By.Id("SubmitCreate")); });     
    }
}
