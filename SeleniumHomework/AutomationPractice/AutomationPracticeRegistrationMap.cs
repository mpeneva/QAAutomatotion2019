namespace SeleniumHomework.AutomationPractice
{
    using OpenQA.Selenium;
    public partial class AutomationPracticeRegistration
    {

        //Define here only the mandatory user registration props 
        public IWebElement FirstName => Wait.Until((d) => { return d.FindElement(By.Id("customer_firstname")); });
        public IWebElement LastName => Wait.Until((d) => { return d.FindElement(By.Id("customer_lastname")); });
        public IWebElement Mail => Wait.Until((d) => { return d.FindElement(By.Id("email")); });
        public IWebElement Password => Wait.Until((d) => { return d.FindElement(By.Id("passwd")); });

        //Define the mandatory user address registration fields
        public IWebElement Address_FirstName => Wait.Until((d) => { return d.FindElement(By.Id("firstname")); });
        public IWebElement Address_LastName => Wait.Until((d) => { return d.FindElement(By.Id("lastname")); });
        public IWebElement Address_Company => Wait.Until((d) => { return d.FindElement(By.Id("company")); });
        public IWebElement Address_Address => Wait.Until((d) => { return d.FindElement(By.Id("address1")); });
        public IWebElement Address_City => Wait.Until((d) => { return d.FindElement(By.Id("city")); });
        public IWebElement Address_State => Wait.Until((d) => { return d.FindElement(By.Id("id_state")); });
        public IWebElement Address_ZipCode => Wait.Until((d) => { return d.FindElement(By.Id("postcode")); });
        public IWebElement Address_Country => Wait.Until((d) => { return d.FindElement(By.Id("id_country")); });
        public IWebElement Address_MobilePhone => Wait.Until((d) => { return d.FindElement(By.Id("phone_mobile")); });
        public IWebElement Address_AdressAlias => Wait.Until((d) => { return d.FindElement(By.Id("alias")); });
        public IWebElement RegisterUser_Button => Wait.Until((d) => { return d.FindElement(By.Id("submitAccount")); });
        public IWebElement ErrorText => Wait.Until((d) => { return d.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div")); });
    }
}
