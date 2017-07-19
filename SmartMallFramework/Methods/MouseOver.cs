using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SmartMallFramework
{
    /// <summary>
    /// This is the action for the mouse. which it move to the define location to 
    /// allow some elemnet appear on the screen.
    /// </summary>
    class MouseHover
    {
        public static void ElementMouseOverbyCss(string target)
        {
            Actions action = new Actions(Browser.driver);
            IWebElement MyAcclabel = Browser.driver.FindElement(By.CssSelector(target));
            action.MoveToElement(MyAcclabel).Perform();
        }

        //Size currentWinSize = _driver.Manage().Window.Size;
        //        //_driver.Manage().Window.Maximize();
        //        //OpenQA.Selenium.Interactions.Actions builder = new OpenQA.Selenium.Interactions.Actions(Browser.Cdriver);
        //        //try
        //        //{
        //        //    builder.MoveToElement(targetElement).Build().Perform();
        //        //    Thread.Sleep(2000);//2 sec is just to for this blog.
        //        //    //I use custome method to wait element being appeared after mouse hover event.
        //        //    //You can use other variable wait time but make sure your give some pause
        //        //    //otherwise mouse hover will happen for fraction of seconds and then disappear.

        //        //    _driver.Manage().Window.Size = currentWinSize;
        //        }
        //        catch (Exception e)
        //        {
        //            loggerInfo.Instance.Message(e.Message);
        //            return false;
        //        }
        //        return true;
        //    }
    }
}
