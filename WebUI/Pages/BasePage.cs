using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace WebUI.Pages
{
    class BasePage
    {
        protected WebDriver driver;

        public BasePage(WebDriver driver)
        {
            this.driver = driver;
        }
    }
}
