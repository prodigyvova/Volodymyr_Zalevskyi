using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using WebUI.Entities;

namespace WebUI.Pages
{
    class MainPage : BasePage
    {
        private static By loginButtonLocator = By.XPath("//*[@id=\"login2\"]");
        private static By usernameLocator = By.XPath("//*[@id=\"loginusername\"]"); 
        private static By passwordLocator = By.XPath("//*[@id=\"loginpassword\"]");
        private static By submitButtonLocator = By.XPath("//*[@id=\"logInModal\"]/div/div/div[3]/button[2]");
        private static By laptopsCategoryLocator = By.XPath("//a[text()='Laptops']");

        //items
        public static readonly By deli_i7_8gb = By.XPath("//a[text()='Dell i7 8gb']");
        //



        public MainPage(WebDriver driver) : base(driver)
        {
            return;
        }


        public MainPage OpenLogin()
        {
            driver.FindElement(loginButtonLocator).Click();

            WebDriverWait waitToLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            Thread.Sleep(100);
            waitToLoad.Until(e => driver.FindElement(usernameLocator).Enabled);
            return this;
        }

        public MainPage TypeUsername(string username)
        {
            driver.FindElement(usernameLocator).SendKeys(username);
            return this;
        }

        public MainPage TypePassword(string password)
        {
            driver.FindElement(passwordLocator).SendKeys(password);
            return this;
        }

        public MainPage SubmitLogin()
        {
            driver.FindElement(submitButtonLocator).Click();
            return this;
        }

        public MainPage LoginAs(UserStorage user)
        {
            OpenLogin();
            TypeUsername(user.Username);
            TypePassword(user.Password);
            return SubmitLogin();
        }

        public MainPage OpenLaptopsCategory()
        {
            Thread.Sleep(100);
            try
            {
                driver.FindElement(laptopsCategoryLocator).Click();
            }
            catch (StaleElementReferenceException ex)
            {
                driver.FindElement(laptopsCategoryLocator).Click();
            }

            return this;
        }

        public ItemPage OpenItemPage(By itemLocator)
        {
            WebDriverWait waitToLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waitToLoad.Until(e => driver.FindElement(itemLocator));
            driver.FindElement(itemLocator).Click();
            return new ItemPage(driver);
        }
    }
}
