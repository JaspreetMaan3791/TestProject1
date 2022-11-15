using OpenQA.Selenium;
using System;
using System.Web;

namespace TestProject1.Pages
{
    public class HomePage 
    {
        public HomePage(IWebDriver webdriver)

        {
            Driver = webdriver;
        }

        private IWebDriver Driver { get; }
        public IWebElement home => Driver.FindElement(By.LinkText("Home"));
        public void HomeClick() => home.Click();
    }
}
