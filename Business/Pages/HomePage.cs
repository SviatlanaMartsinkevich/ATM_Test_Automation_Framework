using Core.BaseEntities;
using Core.Helper;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Business.Pages
{
    public class HomePage : BasePage
    {
        private By careersLink = By.LinkText("Careers");
        private By aboutLink = By.LinkText("About");
        private By insightsLink = By.LinkText("Insights");
        private By magnifierIconField = By.XPath("//span[@class = 'search-icon dark-iconheader-search__search-icon']");
        private By searchField = By.Name("q");
        private By findButton = By.XPath("//span[@class = 'header-search__submit-text']");

        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement GetCareersLink()
        {
            int count = 0;
            while (count <= 5)
            {
                try
                {
                    return driver.FindElement(careersLink);
                }
                catch (NoSuchElementException)
                {
                    Log.Info("CareersLink doesnt visible. Reloading page...");
                    count++;
                    Helper.ReloadPage();
                }
            } 
            return null;
        }

        public IWebElement GetAboutLink()
        {
            int count = 0;
            while (count <= 5)
            {
                try
                {
                    return driver.FindElement(aboutLink);
                }
                catch (NoSuchElementException)
                {
                    Log.Info("AboutLink doesnt visible. Reloading page...");
                    Helper.ReloadPage();
                    count++;
                }
            }
            return null;
        }

        public IWebElement GetInsightsLink()
        {
            int count = 0;
            while (count <= 5 )
            {
                try
                {
                    return driver.FindElement(insightsLink);
                }
                catch (NoSuchElementException)
                {
                    Log.Info("InsightsLink doesnt visible. Reloading page...");
                    Helper.ReloadPage();
                    count++;
                }
            }
            return null;
        }

        public IWebElement GetMagnifierIconField()
        {
            int count = 0;
            while (count <= 5)
            {
                try
                {
                    return driver.FindElement(magnifierIconField);
                }
                catch (NoSuchElementException)
                {
                    Log.Info("magnifierIconField doesnt visible. Reloading page...");
                    Helper.ReloadPage();
                    count++;
                }
            }
            return null;
        }

        public IWebElement GetSearchField()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(searchField));
        }

        public IWebElement GetFindButton()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(findButton));
        }
    }
}
