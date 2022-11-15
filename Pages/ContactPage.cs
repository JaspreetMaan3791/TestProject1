using OpenQA.Selenium;
using System;
using System.Web;

namespace TestProject1.Pages
{
    public class ContactPage 
    {
       public ContactPage(IWebDriver webdriver)

        {
            Driver = webdriver;
        }

        private IWebDriver Driver { get; }
        public IWebElement contact => Driver.FindElement(By.LinkText("Contact"));

        public IWebElement Submit => Driver.FindElement(By.PartialLinkText("Submit"));

        public IWebElement Back => Driver.FindElement(By.PartialLinkText("Back"));
        public void ClickContact()=> contact.Click();
        public void SubmitContact() => Submit.Click();

        public bool IsBackExist() => Back.Displayed;

        IWebElement Forename => Driver.FindElement(By.Name("forename"));
        IWebElement Email => Driver.FindElement(By.Name("email"));
        IWebElement Message => Driver.FindElement(By.Name("message"));

        public void SubmitForm(String forename, String email, String message)
        {
            Forename.SendKeys(forename);
            Email.SendKeys(email);
            Message.SendKeys(message);
            SubmitContact();
        }
    }
}
