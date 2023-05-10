using Business.Pages;
using Core.BaseEntities;
using OpenQA.Selenium;

namespace Business.Steps
{
    public class AboutPageActions : BaseStep
    {
        AboutPage page;
        public AboutPageActions(IWebDriver driver) : base(driver) 
        {
            this.driver = driver;
        }

        public AboutPage ScrollToFactSheetSection()
        {
            page = new AboutPage(driver);
            Log.Info("Scrool to Fact sheet section...");
            ScrollToElementWithIJSExecutor(page.GetFactSheetSection());
            return page;
        }

        public AboutPage ClickDownloadButton()
        {
            page = new AboutPage(driver);
            Log.Info("Click download button...");
            ScrollToElementWithIJSExecutor(page.GetDownloadButton());
            ClickButtonWithIJSExecutor(page.GetDownloadButton());
            return page;
        }

        public string DownloadFileAndWaitTillFileDownloaded(string filePath)
        {
            ScrollToFactSheetSection();
            ClickDownloadButton();
            return CheckFileDownloadedAndGetFileName(filePath);
        }
    }
}
