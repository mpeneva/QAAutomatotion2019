namespace SeleniumHomework.AutomationPractice
{
    using OpenQA.Selenium;
    public partial class AutomationPracticeRegistration :BasePage
    {
        public AutomationPracticeRegistration(IWebDriver driver, string url) : base(driver, url)
        {
        }

        public string RegisterUserAccount(RegistrationUser user)
        {
            //first name
            FirstName.Clear();
            FirstName.SendKeys(user.FirstName);
            
            //last name
            LastName.Clear();
            LastName.SendKeys(user.LastName);

            //password
            Password.Clear();
            Password.SendKeys(user.Password);

            //mail
            Mail.Clear();
            Mail.SendKeys(user.Mail);
            
            //address first name
            Address_FirstName.Clear();
            Address_FirstName.SendKeys(user.Address.FirstName);
            
            //address last name
            Address_LastName.Clear();
            Address_LastName.SendKeys(user.Address.LastName);
            
            //address1
            Address_Address.Clear();
            Address_Address.SendKeys(user.Address.Address1);
            
            //city
            Address_City.Clear();
            Address_City.SendKeys(user.Address.City);

            //state
            Address_State.SendKeys(user.Address.State + Keys.Enter);

            //zipcode
            Address_ZipCode.Clear();
            Address_ZipCode.SendKeys(user.Address.Zipcode);

            //country    
            Address_Country.SendKeys(user.Address.Country + Keys.Enter);

            //mobilephone
            Address_MobilePhone.Clear();
            Address_MobilePhone.SendKeys(user.Address.MobilePhone);
            //alias
            Address_AdressAlias.Clear();
            Address_AdressAlias.SendKeys(user.Address.Alias);

            RegisterUser_Button.Click();

            return ErrorText.Text;
        }
    }
}
