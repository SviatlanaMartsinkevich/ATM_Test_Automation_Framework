using Core.BaseEntities;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;

namespace Business.Pages
{
    public class CareersPage : BasePage
    {
        public static string LOCATION = "{LOCATION}";

        private By keywordField = By.Id("new_form_job_search-keyword");
        private By searchLocationField = By.ClassName("recruiting-search__location");
        private By remoteCheckbox = By.XPath("//fieldset//label[contains(text(), 'Remote')]");
        private By findButton = By.XPath("//form[@id = 'jobSearchFilterForm']//child::button[@type = 'submit']");
        private By viewAndApplyButton = By.XPath("//a[contains(text(), 'View and apply')]");

        public static string CHOOSE_LOCATION = "//li[contains(text(), '" + LOCATION + "')]";

        public CareersPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement GetKeywordField()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(keywordField));
        }

        public IWebElement GetSearchLocationField()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(searchLocationField));
        }

        public IWebElement GetRemoteCheckbox()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(remoteCheckbox));
        }

        public IWebElement GetFindButton()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(findButton));
        }

        public List<IWebElement> GetViewAndApplyButtons()
        {
            return new List<IWebElement>(wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(viewAndApplyButton)));
        }

        public IWebElement GetChooseLocation(string location)
        {
           return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(CHOOSE_LOCATION.Replace(LOCATION, location))));
        }     
    }
}
