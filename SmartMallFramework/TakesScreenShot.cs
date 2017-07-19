using System.Drawing.Imaging;
using OpenQA.Selenium;
using System.IO;
using System.Text;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace PefaMallFramework
{
    public class TakesScreenShot
    {
        static int ScreenCounter = 0;

        public static ITakesScreenshot BrowserInstance { get; set; }
        public object Global { get; private set; }

        public void TakesScreenshotWithDate(string FileName, string OutputPath, System.Drawing.Imaging.ImageFormat Format)
        {
            ScreenCounter++;   //Updates the number of screenshots that we took during the execution

            StringBuilder TimeAndDate = new StringBuilder(System.DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");

            DirectoryInfo Validation = new DirectoryInfo(OutputPath);

            if (Validation.Exists == true) //Capture screen if the path is available
            {
                Screenshot ss = ((ITakesScreenshot)PropertiesCollections.driver).GetScreenshot();
                string screenshot = ss.AsBase64EncodedString;
                byte[] screenshotAsByteArray = ss.AsByteArray;

                // Save the screenshot
                ss.SaveAsFile(OutputPath + ScreenCounter.ToString() + "." + FileName + TimeAndDate.ToString() + "." + Format, System.Drawing.Imaging.ImageFormat.Jpeg);
                ss.ToString();

                //Screenshot screenshotHandles = ((ITakesScreenshot)PropertiesCollections.driver).GetScreenshot();

                // screenshotHandles.SaveAsFile(OutputPath + ScreenCounter.ToString() + "." + FileName + TimeAndDate.ToString() + "." + Format, ImageFormat.Jpeg);

                //ITakesScreenshot screenshotHandles = PropertiesCollections.driver as ITakesScreenshot;
                //screenshotHandles.SaveAsFile(OutputPath + ScreenCounter.ToString() + "." + FileName + TimeAndDate.ToString() + "." + Format, ImageFormat.Jpeg);

                //Screenshot screencapture = screenshotHandles.GetScreenshot();
                //screencapture.SaveAsFile(OutputPath + ScreenCounter.ToString() + "." + FileName + TimeAndDate.ToString() + "." + Format, ImageFormat.Jpeg);
            }
        }
    }
}
