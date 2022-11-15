using OpenQA.Selenium;
using System;
using System.Web;

namespace TestProject1.Pages
{
    public class ShopPage
    {

        public ShopPage(IWebDriver webdriver)

        {
            Driver = webdriver;
        }

        private IWebDriver Driver { get; }
        public IWebElement shop => Driver.FindElement(By.LinkText("Shop"));
        public IWebElement cart => Driver.FindElement(By.PartialLinkText("Cart"));

        public void ClickShop() => shop.Click();
        public void ClickCart() => cart.Click();


       IWebElement StuffedFrog => Driver.FindElement(By.XPath("//li[@id='product-2']/div/p/a[text()='Buy']"));
       IWebElement FluffyBunny => Driver.FindElement(By.XPath("//li[@id='product-4']/div/p/a[text()='Buy']"));
       IWebElement ValentineBear => Driver.FindElement(By.XPath("//li[@id='product-7']/div/p/a[text()='Buy']"));

      
        public void Buy(int sf, int fb, int vb)
        {
           for (int i=0; i< sf; i++)
            {
                StuffedFrog.Click();
            }
            for (int i = 0; i < fb; i++)
            {
                FluffyBunny.Click();
            }
            for (int i = 0; i < vb; i++)
            {
                ValentineBear.Click();
            }
        }
    }


}
    

