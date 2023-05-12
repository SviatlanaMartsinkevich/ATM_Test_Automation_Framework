using Core.BaseEntities;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Business.Pages
{
    public class InsightsPage : BasePage
    {
        private By swipeRightCarouselLink = By.ClassName("slider__right-arrow");
        private By readMoreLink = By.XPath("//button[@class = 'slider__right-arrow']/../..//child::a[1]");
        private By articleNameField = By.XPath("//div[@class = 'article__container']//span//span");

        public InsightsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement GetSwipeRightCarouselLink()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(swipeRightCarouselLink));
        }

        public IWebElement GetReadMoreLink()
        {
            return driver.FindElement(readMoreLink);
        }

        public IWebElement GetArticleNameField()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(articleNameField));
        }
    }
}
