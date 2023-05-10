using log4net;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace Core.BaseEntities
{
    public class BaseStep
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BaseStep(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected ILog Log
        {
            get { return LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); }
        }

        public void PutDataWithIJSExecutor(string inputData, IWebElement webElement)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[1].value = arguments[0]; ", inputData, webElement);
        }

        public void ClickButtonWithIJSExecutor(IWebElement webElement)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", webElement);
        }

        public void ScrollToElementWithIJSExecutor(IWebElement webElement)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
        }
        
        public void ScrollToElementWithActions(IWebElement webElement)
        {
            Actions builder = new Actions(driver);
            builder.ScrollToElement(webElement).Build();
            builder.Perform();
        }
        
        public void ScrollToElementAndClickWithActions(IWebElement webElement)
        {
            Actions builder = new Actions(driver);
            builder.ScrollToElement(webElement).Click(webElement).Build();
            builder.Perform();
        }


        public IEnumerable<IWebElement> GetFilteredListContainingText(List<IWebElement> results, string inputData)
        {
            IEnumerable<IWebElement> query = from IWebElement iWebElement in results
                                             where iWebElement.Text.ToLower().Contains(inputData.ToLower())
                                             select iWebElement;

            return query;
        }

        public string CheckFileDownloadedAndGetFileName(string filePath)
        {
            bool fileExist = false;

            int maxCount = 0;
            var files = Directory.GetFiles(filePath);
            int lenght = files.Length;
            Thread.Sleep(5000);
            var fileName = "";

            while (maxCount < 10)
            {
                if (lenght == files.Length)
                {
                    Thread.Sleep(5000);
                    files = Directory.GetFiles(filePath);
                    maxCount++;
                }
                else
                {
                    var file = files.OrderBy(x => new FileInfo(x).CreationTimeUtc).LastOrDefault();
                    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                    wait.Until<bool>(x => fileExist = File.Exists(new FileInfo(file).FullName));
                    fileName = new FileInfo(file).Name;
                    File.Delete(new FileInfo(file).FullName);
                    break;
                }

            }

            return fileName;
        }
    }
}
