using Business.Pages;
using Core.BaseEntities;
using OpenQA.Selenium;

namespace Business.Steps
{
    public class HomePageActions : BaseStep
    {
        HomePage page;
        public HomePageActions(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        
        public CareersPage ClickCareersLink()
        {
            page = new HomePage(driver);
            Log.Info("Click Careers link");
            page.GetCareersLink().Click();
            return new CareersPage(driver);
        }
        public AboutPage ClickAboutLink()
        {
            page = new HomePage(driver);
            Log.Info("Click About link");
            page.GetAboutLink().Click();
            return new AboutPage(driver);
        }
        public InsightsPage ClickInsightsLink()
        {
            page = new HomePage(driver);
            Log.Info("Click Insights link");
            page.GetInsightsLink().Click();
            return new InsightsPage(driver);
        }

        public HomePage ClickMagnifierIcon()
        {
            page = new HomePage(driver);
            Log.Info("Click Magnifier icon");
            ClickButtonWithIJSExecutor(page.GetMagnifierIconField());
            return page;
        }

        public HomePage PutDataInToSearchField(string inputData)
        {
            page = new HomePage(driver);
            Log.Info("Enter data in Search field");
            PutDataWithIJSExecutor(inputData, page.GetSearchField());
            return page;
        }

        public ResultPage ClickFindButton()
        {
            page = new HomePage(driver);
            Log.Info("Click Find button on CareersPage");
            page.GetFindButton().Click();
            return new ResultPage(driver);
        }
        
        public ResultPage EnterDataInSearchIcon(string inputData)
        {
            ClickMagnifierIcon();
            PutDataInToSearchField(inputData);
            ClickFindButton();
            return new ResultPage(driver);
        }
    }
}
