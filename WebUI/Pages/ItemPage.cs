using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebUI.Pages
{
    internal class ItemPage : BasePage
    {
        private static By addToCartLocator = By.XPath("//*[@id=\"tbodyid\"]/div[2]/div/a");

        public ItemPage(WebDriver driver) : base(driver)
        {
            return;
        }


        public ItemPage AddItemToCart()
        {
            WebDriverWait waitToLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            waitToLoad.Until(e => driver.FindElement(addToCartLocator));
            driver.FindElement(addToCartLocator).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public CartPage OpenCart()
        {   
            driver.Navigate().GoToUrl("https://www.demoblaze.com/cart.html");
            return new CartPage(driver);
        }

    }
}
