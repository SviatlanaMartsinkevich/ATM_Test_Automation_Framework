using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using WebDriverManager.Helpers;
using log4net;
using OpenQA.Selenium.Interactions;

namespace Core.Core
{
    public static class DriverFactory
    {
        static ILog Log
        {
            get { return LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); }
        }
        public static IWebDriver CreateDriver(string browser)
        {
            IWebDriver driver;

            switch (browser.ToLower())
            {
                case "chrome":

                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

                    Log.Info("Set up chrome driver...");
                    driver = new ChromeDriver(GetChromeOptions());
                    break;

                case "firefox":

                    new DriverManager().SetUpDriver(new FirefoxConfig(), "Latest", Architecture.Auto);

                    Log.Info("Set up firefox driver...");
                    driver = new FirefoxDriver(GetFirefoxOptions());
                    break;

                case "edge":

                    new DriverManager().SetUpDriver(new EdgeConfig(), "Latest", Architecture.Auto);
                    
                    Log.Info("Set up edge driver");
                    driver = new EdgeDriver(GetEdgeOptions());
                    break;

                default:

                    Log.Info("This type of browser is not supported.");
                    throw new Exception("This type of browser is not supported.");
            }

            return driver;
        }

        public static EdgeOptions GetEdgeOptions() 
        {
            EdgeOptions edgeOptions = new EdgeOptions();
            edgeOptions.PageLoadStrategy = PageLoadStrategy.Normal;

             if (ConfigurationsManager.GetHeadless().Equals("true"))
             {
                Log.Info("Broser is working in headless mode");
                edgeOptions.AddArguments("headless");
                edgeOptions.AddArguments("--window-size=1920,1080");
             }

            return edgeOptions;
        }

        public static FirefoxOptions GetFirefoxOptions()
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.PageLoadStrategy = PageLoadStrategy.Normal;

            if (ConfigurationsManager.GetHeadless().Equals("true"))
            {
                Log.Info("Broser is working in headless mode");
                firefoxOptions.AddArguments("-headless");
            }

            return firefoxOptions;
        }

        public static ChromeOptions GetChromeOptions()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
            chromeOptions.AddArguments("--disable-extensions");
  
            if (ConfigurationsManager.GetHeadless().Equals("true"))
            {
                Log.Info("Broser is working in headless mode");
                chromeOptions.AddArguments("headless");
                chromeOptions.AddArguments("--window-size=1920,1080");
            }

            chromeOptions.AddArguments("--disable-gpu");
            chromeOptions.AddArgument("--no-sandbox");


            return chromeOptions;
        }
    }
}
