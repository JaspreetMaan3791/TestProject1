using OpenQA.Selenium;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;

namespace TestProject1.Pages
{
    public class CartPage 
    {
        public CartPage(IWebDriver webdriver)

        {
            Driver = webdriver;
        }

        private IWebDriver Driver { get; }
    
        public IWebElement cart => Driver.FindElement(By.PartialLinkText("Cart"));

        public void ClickCart() => cart.Click();

        public IWebElement Table => Driver.FindElement(By.XPath("//table[contains(@class,'cart-items')]"));
        List<IWebElement> lstTrElem => new List<IWebElement>(Table.FindElements(By.TagName("tr")));
        public IWebElement Total => Driver.FindElement(By.XPath("//table[contains(@class,'cart-items')]//tr//td//strong[contains(@class,'total')]"));
       

        String strRowData = "";
        
        public void subTotalverify()
        {
            
            List<IWebElement> range = lstTrElem.GetRange(2, 3);
            // Traverse each row
            foreach (var elemTr in range)
            {
                // Fetch the columns from a particuler row
                List<IWebElement> lstTdElem = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));
                List<IWebElement> pricelist = new List<IWebElement>(elemTr.FindElements(By.XPath("//table[contains(@class,'cart-items')]//tr//td[2]")));
                List<IWebElement> quantity = new List<IWebElement>(elemTr.FindElements(By.XPath("//table[contains(@class,'cart-items')]//tr//td[3]//input")));
                List<IWebElement> Subtotal = new List<IWebElement>(elemTr.FindElements(By.XPath("//table[contains(@class,'cart-items')]//tr//td[4]")));
               
                if (lstTdElem.Count > 2)
                {
                    for (int i = 0; i < quantity.Count(); i++)
                    {
                        // "\t\t" is used for Tab Space between two Text
                        //strRowData = strRowData + quantity[i].GetAttribute("value") + "\t\t";
                        //strRowData1 = strRowData + pricelist[i].Text + "\t\t";
                        //strRowData2 = strRowData + Subtotal[i].Text + "\t\t";

                        var quantit = quantity[i].GetAttribute("value");
                        var price =pricelist[i].Text.Trim('$');
                        decimal verifySubtotal = System.Convert.ToDecimal(price) * Convert.ToInt32(quantit);
                        //var mul = int.Parse(price, NumberStyles.AllowCurrencySymbol) * Int16.Parse(quantit);
                        decimal subTotal = System.Convert.ToDecimal(Subtotal[i].Text.Trim('$'));
                        Assert.AreEqual(verifySubtotal, subTotal);
                    }
                }
                else
                {
                    // To print the data into the console
                    Console.WriteLine(lstTrElem[0].Text.Replace(" ", "\t\t"));
                }
                strRowData = String.Empty;
            }
        }

        public void Totalverify()
        {

            List<IWebElement> range = lstTrElem.GetRange(2, 3);
            
            foreach (var elemTr in range)
            {
                List<IWebElement> lstTdElem = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));
                List<IWebElement> pricelist = new List<IWebElement>(elemTr.FindElements(By.XPath("//table[contains(@class,'cart-items')]//tr//td[2]")));
                List<IWebElement> quantity = new List<IWebElement>(elemTr.FindElements(By.XPath("//table[contains(@class,'cart-items')]//tr//td[3]//input")));
                List<IWebElement> Subtotal = new List<IWebElement>(elemTr.FindElements(By.XPath("//table[contains(@class,'cart-items')]//tr//td[4]")));
               

                if (lstTdElem.Count > 2)
                {
                    decimal resultSubTotal = 0;
                    for (int i = 0; i < quantity.Count(); i++)
                    {
                        decimal verifySubtotal= System.Convert.ToDecimal(Subtotal[i].Text.Trim('$'));
                        resultSubTotal += verifySubtotal;
                    }
                    
                    decimal resultTotal= System.Convert.ToDecimal(Total.Text.Remove(0, 7));
                    Assert.That(resultSubTotal, Is.EqualTo(resultTotal));

                }
                else
                {
                    // To print the data into the console
                    Console.WriteLine(lstTrElem[0].Text.Replace(" ", "\t\t"));
                }
            }
        }
    }
}
