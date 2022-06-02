using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using WebUI.Pages;
using WebUI.Entities;

namespace WebUI
{
    public class Tests
    {
        private WebDriver driver;
        private static readonly string startUrl = "https://www.demoblaze.com/";

        private void DriverSetup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver(Path.GetFullPath("driver"));
            driver.Navigate().GoToUrl(startUrl);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        [SetUp]
        public void Setup()
        {
            DriverSetup();
        }


        [Test]
        public void PurchaseItemScenario()
        {
            UserStorage user = new UserStorage("prodigyvova", "password123");
            OrderEntity orderInfo = new OrderEntity("vova", "Ukraine", "Kyiv", "1231230", "May", "2022");

            MainPage mainPage = new MainPage(driver);
            ItemPage itemPage = mainPage.LoginAs(user).OpenLaptopsCategory().OpenItemPage(MainPage.deli_i7_8gb);
            CartPage cartPage = itemPage.AddItemToCart().OpenCart();
            cartPage = cartPage.PlaceOrder().FillForm(orderInfo).Purchase();
            string resultMessage = cartPage.CheckConfirmationPopUp(orderInfo);

       
            if (resultMessage == "Success")
            {
                cartPage = cartPage.ConfirmPopUp();
                Assert.AreEqual("Cart is empty", cartPage.CheckIfCartIsEmpty());
            }

            Assert.AreEqual("Success", resultMessage);
        }


        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }

    }
}


