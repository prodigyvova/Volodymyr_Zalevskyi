using System;
using OpenQA.Selenium;
using WebUI.Entities;
using OpenQA.Selenium.Support.UI;

namespace WebUI.Pages
{
    class CartPage : BasePage
    {

        private static By placeOrderButton = By.XPath("//button[text()='Place Order']");
        private static By nameField = By.XPath("//*[@id=\"name\"]");
        private static By countryField = By.XPath("//*[@id=\"country\"]");
        private static By cityField = By.XPath("//*[@id=\"city\"]");
        private static By creditCardField = By.XPath("//*[@id=\"card\"]");
        private static By monthField = By.XPath("//*[@id=\"month\"]");
        private static By yearField = By.XPath("//*[@id=\"year\"]");
        private static By purchaseButton = By.XPath("//*[@id=\"orderModal\"]/div/div/div[3]/button[2]");
        private static By confirmationPopUp = By.XPath("//h2[text()='Thank you for your purchase!']");

        private static By okBtn = By.XPath("//button[text()='OK']");
        private static By elementLocator = By.XPath("//tr*[contains(@class, 'success')]");

        public CartPage(WebDriver driver) : base(driver)
        {
            return;
        }


        public CartPage PlaceOrder()
        {
            WebDriverWait waitToLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            waitToLoad.Until(e => driver.FindElement(placeOrderButton));

            driver.FindElement(placeOrderButton).Click();
            return this;
        }

        public CartPage SetName(string name)
        {
            driver.FindElement(nameField).SendKeys(name);
            return this;
        }

        public CartPage SetCountry(string country)
        {
            driver.FindElement(countryField).SendKeys(country);
            return this;
        }
        public CartPage SetCity(string city)
        {
            driver.FindElement(cityField).SendKeys(city);
            return this;
        }
        public CartPage SetCreditCard(string creditCard)
        {
            driver.FindElement(creditCardField).SendKeys(creditCard);
            return this;
        }
        public CartPage SetMonth(string month)
        {
            driver.FindElement(monthField).SendKeys(month);
            return this;
        }
        public CartPage SetYear(string year)
        {
            driver.FindElement(yearField).SendKeys(year);
            return this;
        }

        public CartPage FillForm(OrderEntity orderInfo)
        {
            WebDriverWait waitToLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            waitToLoad.Until(e => driver.FindElement(nameField).Enabled);
            SetName(orderInfo.Name);
            SetCountry(orderInfo.Country);
            SetCity(orderInfo.City);
            SetCreditCard(orderInfo.CreditCard);
            SetMonth(orderInfo.Month);
            SetYear(orderInfo.Year);
            return this;
        }

        public CartPage Purchase()
        {
            WebDriverWait waitToLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            waitToLoad.Until(e => driver.FindElement(purchaseButton).Enabled);
            driver.FindElement(purchaseButton).Click();
            return this;
        }

        private By BuildPopUpNameLocator(string name)
        {
            return By.XPath("//p[text()='Name: " + name + "']");
        }

        private By BuildPopUpCardLocator(string card)
        {
            return By.XPath("//p[text()='Card Number: " + card + "']");
        }


        public string CheckConfirmationPopUp(OrderEntity orderInfo)
        {
            WebDriverWait waitToLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            waitToLoad.Until(e => driver.FindElement(confirmationPopUp).Enabled);
            try
            {
                if (!driver.FindElement(confirmationPopUp).Enabled)
                    return "No confirmation pop-up appeared";
                if (!driver.FindElement(BuildPopUpNameLocator(orderInfo.Name)).Enabled)
                    return "Wrong name in confirmation pop-up";
                if (!driver.FindElement(BuildPopUpCardLocator(orderInfo.CreditCard)).Enabled)
                    return "Wrong creditcard in confirmation pop-up";

                return "Success";
            }
            catch (NoSuchElementException ex)
            {
                return "No confirmation pop-up appeared";
            }
        }

        public CartPage ConfirmPopUp()
        {
            driver.FindElement(okBtn).Click();
            return this;
        }

        public string CheckIfCartIsEmpty()
        {
            try
            {
                driver.FindElement(elementLocator);
                return "Cart is not empty";
            }
            catch (NoSuchElementException ex)
            {
                return "Cart is empty";
            }
        }
    }
}


