using System;
using System.Web;

namespace TestProject1.Tests
{
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using global::TestProject1.Pages;


    namespace TestProject1
    {
        public class Tests
        {

            
            IWebDriver webdriver = new ChromeDriver();
            
            [SetUp]
            public void Setup()
            {
                webdriver.Navigate().GoToUrl("http://jupiter.cloud.planittesting.com");
                webdriver.Manage().Window.Maximize();
            }

            [Test]
            public void Test1()
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
                ContactPage Contact = new ContactPage(webdriver);
                Contact.ClickContact();
                Thread.Sleep(2000);
                ((IJavaScriptExecutor)webdriver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                Contact.SubmitContact();
                Thread.Sleep(6000);
                Contact.SubmitForm("Jaspreet","Jas@gmail.com","Test1");
                Thread.Sleep(10000);
                Assert.That(Contact.IsBackExist, Is.True);
                webdriver.Quit();
            }

            [Test]
            public void Test2()
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
                ContactPage Contact = new ContactPage(webdriver);
                HomePage Home = new HomePage(webdriver);
                for (int i = 1; i < 6; i++)
                {
                    Contact.ClickContact();
                    Thread.Sleep(6000);
                    Contact.SubmitForm("Mark", "Mark@gmail.com", "Test2");
                    Thread.Sleep(15000);
                    Assert.That(Contact.IsBackExist, Is.True);
                    Console.WriteLine("Test run succeded" + i + "times");
                    Home.HomeClick();
                }
                webdriver.Quit();
            }

            [Test]
            public void Test3()
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
                HomePage home = new HomePage(webdriver);
                ShopPage shop = new ShopPage(webdriver);
                CartPage cart = new CartPage(webdriver);

                shop.ClickShop();
                Thread.Sleep(6000);
                shop.Buy(2,5,3);
                cart.ClickCart();
                Thread.Sleep(6000);
                cart.tableData();
               webdriver.Quit();
            }
        }
    }
}
