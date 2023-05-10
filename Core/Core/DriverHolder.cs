using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace Core.Core
{
    public static class DriverHolder
    {
        private static IWebDriver instance;
                
        public static IWebDriver Driver
        {
            get
            {
                if (instance == null)
                {
                    instance = DriverFactory.CreateDriver(ConfigurationsManager.GetBrowser());
                }
                return instance;
            }
        }
    }
}
