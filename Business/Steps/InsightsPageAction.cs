using Business.Pages;
using Core.BaseEntities;
using OpenQA.Selenium;

namespace Business.Steps
{
    public class InsightsPageAction : BaseStep
    {
        InsightsPage page;

        public InsightsPageAction(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

         public InsightsPage ClickSwipeRightCarousel()
        {
            page = new InsightsPage(driver);
            Log.Info("Swipe right carousel");
            ClickButtonWithIJSExecutor(page.GetSwipeRightCarouselLink());
            return page;
        }

        public InsightsPage ClickReadMore()
        {
            page = new InsightsPage(driver);
            Log.Info("Click Read more on InsightsPage...");
            ClickButtonWithIJSExecutor(page.GetReadMoreLink());
            return page;
        }
    }
}
