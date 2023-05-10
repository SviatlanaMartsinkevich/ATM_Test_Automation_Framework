using Core.BaseEntities;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Business.Pages
{
    public class AboutPage : BasePage
    {
        private By factSheetSection = By.XPath("//*[contains(text(), 'EPAM at')]");
        private By downloadButton = By.XPath("//*[contains(text(), 'DOWNLOAD')][1]");

        public AboutPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        
         public IWebElement GetFactSheetSection()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(factSheetSection));
        }

        public IWebElement GetDownloadButton()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(downloadButton));
        }
    }
}
