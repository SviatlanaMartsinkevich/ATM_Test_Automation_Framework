using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using log4net;

namespace Core.BaseEntities
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        protected ILog Log
        {
            get { return LogManager.GetLogger(this.GetType()); }
        }
    }
}
