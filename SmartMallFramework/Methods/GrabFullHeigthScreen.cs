using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace SmartMallFramework
{
    /// <summary>
    /// define the screen capture which to capture full screen as to solve some others browser only able to capture the screen image
    /// by using the system pre-define fucntion.
    /// </summary>
    class GrabFullHeigthScreen
    {
        static int ScreenCounter = 0;

        public void TakesScreenshotWithDate(string FileName, string OutputPath, System.Drawing.Imaging.ImageFormat Format, ref string EXImgFilePath)
        {
            ScreenCounter++;   //Updates the number of screenshots that we took during the execution

            StringBuilder TimeAndDate = new StringBuilder(System.DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");

            DirectoryInfo Validation = new DirectoryInfo(OutputPath);
            if (Validation.Exists == true) //Capture screen if the path is available
            {
                var ScreenImage = GetEntireScreenshot();
                EXImgFilePath = OutputPath + ScreenCounter.ToString() + "." + FileName + TimeAndDate.ToString() + "." + Format;
                //ScreenImage.Save(OutputPath + ScreenCounter.ToString() + "." + FileName + TimeAndDate.ToString() + "." + Format, System.Drawing.Imaging.ImageFormat.Png);
                ScreenImage.Save(EXImgFilePath, System.Drawing.Imaging.ImageFormat.Png);
            }
        }


        private Image GetEntireScreenshot()
        {

            // Get the total size of the page
            var totalWidth = (int)(long)((IJavaScriptExecutor)Browser.driver).ExecuteScript("return document.body.offsetWidth"); //documentElement.scrollWidth");
            var totalHeight = (int)(long)((IJavaScriptExecutor)Browser.driver).ExecuteScript("return  document.body.parentNode.scrollHeight");
            // Get the size of the viewport
            var viewportWidth = (int)(long)((IJavaScriptExecutor)Browser.driver).ExecuteScript("return document.body.clientWidth"); //documentElement.scrollWidth");
            var viewportHeight = (int)(long)((IJavaScriptExecutor)Browser.driver).ExecuteScript("return window.innerHeight"); //documentElement.scrollWidth");

            // We only care about taking multiple images together if it doesn't already fit
            if (totalWidth <= viewportWidth && totalHeight <= viewportHeight)
            {
                var screenshot = Browser.driver.TakeScreenshot();
                return ScreenshotToImage(screenshot);
            }
            // Split the screen in multiple Rectangles
            var rectangles = new List<Rectangle>();
            // Loop until the totalHeight is reached
            for (var y = 0; y < totalHeight; y += viewportHeight)
            {
                var newHeight = viewportHeight;
                // Fix if the height of the element is too big
                if (y + viewportHeight > totalHeight)
                {
                    newHeight = totalHeight - y;
                }
                // Loop until the totalWidth is reached
                for (var x = 0; x < totalWidth; x += viewportWidth)
                {
                    var newWidth = viewportWidth;
                    // Fix if the Width of the Element is too big
                    if (x + viewportWidth > totalWidth)
                    {
                        newWidth = totalWidth - x;
                    }
                    // Create and add the Rectangle
                    var currRect = new Rectangle(x, y, newWidth, newHeight);
                    rectangles.Add(currRect);
                }
            }

            // Build the Image
            var stitchedImage = new Bitmap(totalWidth, totalHeight);

            // Get all Screenshots and stitch them together
            var previous = Rectangle.Empty;
            foreach (var rectangle in rectangles)
            {
                // Calculate the scrolling (if needed)
                if (previous != Rectangle.Empty)
                {
                    var xDiff = rectangle.Right - previous.Right;
                    var yDiff = rectangle.Bottom - previous.Bottom;
                    // Scroll
                    ((IJavaScriptExecutor)Browser.driver).ExecuteScript(String.Format("window.scrollBy({0}, {1})", xDiff, yDiff));
                }
                // Take Screenshot
                var screenshot = Browser.driver.TakeScreenshot();
                // Build an Image out of the Screenshot
                var screenshotImage = ScreenshotToImage(screenshot);
                // Calculate the source Rectangle
                var sourceRectangle = new Rectangle(viewportWidth - rectangle.Width, viewportHeight - rectangle.Height, rectangle.Width, rectangle.Height);
                // Copy the Image
                using (var graphics = Graphics.FromImage(stitchedImage))
                {
                    graphics.DrawImage(screenshotImage, rectangle, sourceRectangle, GraphicsUnit.Pixel);
                }
                // Set the Previous Rectangle
                previous = rectangle;
            }
            return stitchedImage;
        }

        private static Image ScreenshotToImage(Screenshot screenshot)
        {
            Image screenshotImage;
            using (var memStream = new MemoryStream(screenshot.AsByteArray))
            {
                screenshotImage = Image.FromStream(memStream);
            }
            return screenshotImage;
        }
    }
}
