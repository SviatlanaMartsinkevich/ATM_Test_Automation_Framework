using Business.Pages;
using Core.BaseEntities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Steps
{
    public class ResultPageActions : BaseStep
    {
        ResultPage page;
        public ResultPageActions(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public List<IWebElement> GetResultWithFilter(string filter)
        {
            page = new ResultPage(driver);
            return new List<IWebElement>(GetFilteredListContainingText(page.GetResults(), filter));
        }
    }
}
