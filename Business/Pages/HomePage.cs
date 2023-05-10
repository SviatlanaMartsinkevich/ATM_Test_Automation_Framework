﻿using Core.BaseEntities;
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
            return wait.Until(ExpectedConditions.ElementIsVisible(careersLink));
        }

        public IWebElement GetAboutLink()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(aboutLink));
        }
        public IWebElement GetInsightsLink()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(insightsLink));
        }

        public IWebElement GetMagnifierIconField()
        {while (true)
            {
                try
                {
                    return driver.FindElement(magnifierIconField);
                }
                catch (NoSuchElementException)
                {
                    Log.Info("magnifierIconField doesnt visible. Reloading page...");
                    Helper.ReloadPage();
                }
            }
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
