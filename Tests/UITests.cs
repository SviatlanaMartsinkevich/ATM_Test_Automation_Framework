using Business.Pages;
using Business.Steps;
using Core.BaseEntities;
using Core.Core;
using log4net;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class UITests : BaseTest
    {
         private static string filePath = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";

         [Category("UI")]
         [TestCase("PHP", "All Locations")]
         [Test, Description("Task#1")]
         public void ValidateThatUserCanSearchForAPositionBasedOnCriteriaTest(string programmingLanguage, string location)
         {
            Log.Info("Start ValidateThatUserCanSearchForAPositionBasedOnCriteriaTest");
            HomePageActions homePgeActions = new HomePageActions(DriverHolder.Driver);
            homePgeActions.ClickCareersLink();

            CareersPageAction careersPageAction = new CareersPageAction(DriverHolder.Driver);
            careersPageAction.EnterDataInSearchSectionWitnInputDataAndRemoteCheckbox(programmingLanguage, location);

            JobDetailPage jobDetailPage = careersPageAction.ClickLastViewAndApplyButton();

            Log.Info("Checking that JobDetailField contains inputData...");
            Assert.That(jobDetailPage.GetDetailedContentField().Text.Contains(programmingLanguage));
         }

         [Category("UI")]
         [TestCase("BLOCKCHAIN")]
         [TestCase("Cloud")]
         [TestCase("Automation")]
         [Test, Description("Task#2")]
         public void ValidateGlobalSearchWorksAsExpectedTest(string inputData)
         {
            Log.Info("Start ValidateGlobalSearchWorksAsExpectedTest");
            HomePageActions homePageActions = new HomePageActions(DriverHolder.Driver);

            ResultPage resultPage = homePageActions.EnterDataInSearchIcon(inputData);

            ResultPageActions resultPageActions = new ResultPageActions(DriverHolder.Driver);

            Log.Info("Checking that all links in ResultPage contains inputData...");
            Assert.AreEqual(resultPage.GetResults().Count,
                 resultPageActions.GetResultWithFilter(inputData).Count, "Not all links in a list contain a word '" + inputData + "' in the text");
         }

         [Category("UI")]
         [TestCase("EPAM_Corporate_Overview_2023.pdf")]
         [Test, Description("Task#3")]
         public void ValidateFileDownloadFunctionWorksAsExpectedTest(string fileName)
         {
            Log.Info("Start ValidateFileDownloadFunctionWorksAsExpectedTest");
            HomePageActions homePageActions = new HomePageActions(DriverHolder.Driver);
            homePageActions.ClickAboutLink();

            AboutPageActions aboutPageActions = new AboutPageActions(DriverHolder.Driver);
            string downloadedFileName = aboutPageActions.DownloadFileAndWaitTillFileDownloaded(filePath);

            Log.Info("Checking that DownloadedFileName equal parametrize data.");
            Assert.AreEqual(fileName, downloadedFileName);
         }

         [Category("UI")]
         [TestCase("How Machine Learning & Differential Privacy Can Be Used to Anonymize Production Data")]
         [Test, Description("Task#4")]
         public void ValidateTitleOfTheArticleMatchesWithTitleInCarouselTest(string articleName)
         {
            Log.Info("Start ValidateTitleOfTheArticleMatchesWithTitleInCarouselTest");
            HomePageActions homePageActions = new HomePageActions(DriverHolder.Driver);
            homePageActions.ClickInsightsLink();

            InsightsPageAction insightsPageAction = new InsightsPageAction(DriverHolder.Driver);
            insightsPageAction.ClickSwipeRightCarousel();
            insightsPageAction.ClickSwipeRightCarousel();

            InsightsPage insightsPage = insightsPageAction.ClickReadMore();

            Log.Info("Checking that ArticleName contains inputData...");
            Assert.AreEqual(articleName, insightsPage.GetArticleNameField().Text);
         }

         [OneTimeTearDown]
         public void AfterAllTests()
         {
            Log.Info("Closing Browser...");
            DriverHolder.Driver.Quit();
         }
    }
}
