using Core.BaseEntities;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Business.Pages
{
    public class JobDetailPage : BasePage
    {
        private By detailedContentField = By.XPath("//section[contains(@class, '_content')]");

        public JobDetailPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement GetDetailedContentField()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(detailedContentField));
        }
    }
}
