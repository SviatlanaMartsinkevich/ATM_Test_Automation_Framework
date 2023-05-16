using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Core.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;

namespace Core.Helper
{
    public class ScreenshotMaker
    {
        private static string NewScreenshotName
        {
            get { return "_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-fff") + "." + ScreenshotImageFormat; }
        }
        private static ImageFormat ScreenshotImageFormat 
        {
            get { return ImageFormat.Jpeg; }
        }
        public static string TakeBrowserScreenshot()
        {
            var screenshotPath = Path.Combine(Environment.CurrentDirectory, "Display" + NewScreenshotName);
            var image = DriverHolder.Driver.TakeScreenshot(); 
            image.SaveAsFile(screenshotPath, OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            return screenshotPath;
        }
        public static string TakeFullDisplayScreenshot()
        {
            var screenshotPath = Path.Combine(Environment.CurrentDirectory, "FullScreen" + NewScreenshotName);
            using (Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bmpScreenCapture))
                {
                    g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                     Screen.PrimaryScreen.Bounds.Y,
                                     0, 0,
                                     bmpScreenCapture.Size,
                                     CopyPixelOperation.SourceCopy);
                }
                bmpScreenCapture.Save(screenshotPath, ScreenshotImageFormat);
            }
            return screenshotPath;
        }
    }
}
