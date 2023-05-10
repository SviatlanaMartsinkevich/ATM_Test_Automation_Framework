using Business.Pages;
using Core.BaseEntities;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Linq;

namespace Business.Steps
{
    public class CareersPageAction : BaseStep
    {
        CareersPage page;
        public CareersPageAction(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public CareersPage PutDataInKeywordField(string programmingLanguage)
        {
            page = new CareersPage(driver);
            Log.Info("Enter Data in keyword field...");
            ScrollToElementWithIJSExecutor(page.GetKeywordField());
            page.GetKeywordField().Clear();
            page.GetKeywordField().SendKeys(programmingLanguage);
            return page;
        }

        public CareersPage ClickSearchLocationField()
        {
            page = new CareersPage(driver);
            Log.Info("Click search location field");
            page.GetSearchLocationField().Click();
            return page;
        }

        public CareersPage ChooseLocation(string location)
        {
            page = new CareersPage(driver);
            Log.Info("Choose location with parameter");
            ScrollToElementAndClickWithActions(page.GetChooseLocation(location));
            return page;
        }

        public CareersPage ClickRemoteCheckbox()
        {
            page = new CareersPage(driver);
            Log.Info("Click Remote checkbox");
            ClickButtonWithIJSExecutor(page.GetRemoteCheckbox());
            return page;
        }

        public CareersPage ClickFindButton()
        {
            page = new CareersPage(driver);
            Log.Info("Click Find button...");
            page.GetFindButton().Click();
            return page;
        }

        public JobDetailPage ClickLastViewAndApplyButton()
        {
            page = new CareersPage(driver);
            Log.Info("Click View and apply button...");
            wait.Until(ExpectedConditions.ElementToBeClickable(page.GetViewAndApplyButtons().Last()));
            ClickButtonWithIJSExecutor(page.GetViewAndApplyButtons().Last());
            return new JobDetailPage(driver);
        }

        public CareersPage EnterDataInSearchSectionWitnInputDataAndRemoteCheckbox(string programmingLanguage, string location)
        {
            PutDataInKeywordField(programmingLanguage);
            ClickSearchLocationField();
            ChooseLocation(location);
            ClickRemoteCheckbox();
            ClickFindButton();
            return page;
        }
    }
}
