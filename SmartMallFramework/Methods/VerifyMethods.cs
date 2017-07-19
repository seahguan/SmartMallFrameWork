using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using NUnit.Framework;
using AventStack.ExtentReports;


namespace SmartMallFramework
{

    public static class Config
    {
        public static readonly TimeSpan ImplicitWait = new TimeSpan(0, 0, 0, 10);
        public static readonly TimeSpan NoWait = new TimeSpan(0, 0, 0, 0);
    }

    /// <summary>
    /// TO define the verification to verify elements appear in the webpage or not.
    /// </summary>
    public static class VerifyMethods
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        /// <summary>
        /// Verify the element using the class method
        /// </summary>
        /// <param name="element"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public static bool HasClass(this IWebElement element, string className)
        {
            try
            {
                Assert.IsTrue(element.GetAttribute("class").Split(' ').Contains(className));
                log.Info("INFO : verify By CSS method " + className + " successfully");
                ExtentManager.test.Log(Status.Pass, "Success open the chorme browser and open pefamall homepage");
                // screen shot in extent report =>> test.Log(Status.Pass, MediaEntityBuilder.CreateScreenCaptureFromPath(""))
                return true;
            }
            catch (Exception e)
            {
                log.Warn("Fail : verify By CSS method " + className + " Failed", e);
                ExtentManager.test.Fail(e);                
                return false;
            }

        }

        //public List<string> GetValidations()
        //{
        //    IList<IWebElement> elementList = Browser.Cdriver.FindElements(By.CssSelector("aa"));
        //    List<string> validations = new List<string();
        //    foreach (IWebElement element in elementList)
        //    {
        //        validations.Add(element.ToString());
        //    }
        //    return validations;
        //}

        /// <summary>
        /// Verify the element using the Css attribute method
        /// </summary>
        /// <param name="element"></param>
        /// <param name="cssname"></param>
        /// <param name="elementname"></param>
        /// <param name="sourcetype"></param>
        /// <returns></returns>
        public static bool HasElementByCssGetAlt(this IWebElement element, string cssname, string elementname, string sourcetype)
        {
            try
            {
                IList<IWebElement> ByCSSattributes = Browser.driver.FindElements(By.CssSelector(cssname));
                foreach (IWebElement option in ByCSSattributes)
                {
                    string actualvalue = option.GetAttribute(sourcetype);                    
                    Assert.IsTrue(actualvalue.Contains(elementname));
                    log.Info("INFO : verify By CSS method " + elementname + " Vs " + actualvalue + " successfully");
                }
                
                return true;
            }
            catch (Exception e)
            {
                log.Warn("FAIL : verify By CSS method " + elementname + " Failed", e); 
                return false;
            }
        }

        /// <summary>
        /// Verify the element using the Css to get the text method
        /// </summary>
        /// <param name="element"></param>
        /// <param name="elementname"></param>
        /// <returns></returns>
        public static bool HasElementByCssGetText(this IWebElement element, string elementname)
        {
            try
            {
                string actualvalue = element.GetText();
                Assert.IsTrue(actualvalue.Contains(elementname));
                log.Info("INFO : verify By CSS method " + elementname + " successfully");
                return true;
            }
            catch (Exception e)
            {
                log.Warn("Fail : verify By CSS method " + elementname + " Failed", e);
                return false;
            }
        }

        /// <summary>
        /// Verify the element using the ID method
        /// </summary>
        /// <param name="element"></param>
        /// <param name="idname"></param>
        /// <param name="elementname"></param>
        /// <returns></returns>
        public static bool HasElementById(this IWebElement element, string idname, string elementname)
        {
            try
            {
                string actualvalue = Browser.driver.FindElement(By.Id(idname)).Text;
                Assert.IsTrue(actualvalue.Contains(elementname));
                log.Info("INFO : verify By Id method " + elementname + " successfully");
                return true;
            }
            catch (Exception e)
            {
                log.Warn("Fail : verify By Id method " + elementname + " Failed", e);
                return false;
            }

        }
    }
}
