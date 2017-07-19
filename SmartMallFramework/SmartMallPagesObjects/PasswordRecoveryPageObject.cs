using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using AventStack.ExtentReports;

namespace SmartMallFramework
{
    class PasswordRecoveryPageObject
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PasswordRecoveryPageObject()
        {
            // to initialize all the object in this page
            PageFactory.InitElements(Browser.driver, this);
        }

        [FindsBy(How = How.Name, Using = "Email")]
        public IWebElement txtEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.button-1.password-recovery-button")]
        public IWebElement btnRecover { get; set; }

        [FindsBy(How = How.Name, Using = "send-email")]
        public IWebElement btnRecover2 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "//div.result")] // "//div[@class='result']
        public IWebElement txtResult { get; set; }

        [FindsBy(How = How.CssSelector, Using = "//[class=''] [for='Email']")]
        public IWebElement txtEmailverfication { get; set; }

        /// <summary>
        ///  Receover password 
        /// </summary>
        /// <param email= provide the email address for the password recovery></param>
        /// <param tmpResult= provide the email address for the password recovery></param>
        /// <returns></returns>
        public HomePageObject Recoverpassword(string email, string tmpResult)
        {
            try
            {
                //UserName
                txtEmail.SendKeys(email);

                //clcik button
                btnRecover.Submit();

                Assert.IsTrue(txtResult.GetAttribute("class").Split(' ').Contains(tmpResult));
                log.Info("INFO : verify Recovery password result By CSS method " + tmpResult + " successfully");
                ExtentManager.test.Log(Status.Pass, "Success open the chorme browser and open pefamall homepage");


                //Return the page object
                return new HomePageObject();
            }
            catch (Exception e)
            {
                log.Fatal("FATAL : Fail at verify Recovery password result By CSS method " + tmpResult + " successfully");

                //Return the page object
                return new HomePageObject();
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public void verifyEmailaddress()
        //{
        //    //try
        //    //{
        //    //    Assert.IsTrue(txtResult.GetAttribute("for").Split(' ').Contains("Enter Your email"));
        //    //    log.Info("INFO : verify enter email address at Recovery password By CSS method successfully");

        //    //    Assert.IsTrue(txtResult.GetAttribute("for").Split(' ').Contains("Wrong email"));

        //    //}
        //    //catch (Exception e)
        //    //{
        //    //    log.Fatal("FATAL : Fail at verify Recovery password result By CSS method " + tmpResult + " successfully");

        //    //}
        //}

    }
}
