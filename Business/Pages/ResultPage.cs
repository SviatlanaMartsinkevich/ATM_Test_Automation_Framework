using Core.BaseEntities;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;

namespace Business.Pages
{
    public class ResultPage : BasePage
    {
        private By results = By.TagName("article");

        public ResultPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public List<IWebElement> GetResults()
        {
            return new List<IWebElement>(wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(results)));
        }
    }
}
