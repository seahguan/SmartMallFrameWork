using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SmartMallFramework
{
    class LoginPageObject
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LoginPageObject()
        {
            PageFactory.InitElements(Browser.driver, this);
        }


        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "RememberMe")]
        public IWebElement chkboxRememberMe { get; set; }
        ///html/body/div[8]/div[4]/div[2]/div/div/div[2]/div/div[2]/form/div[2]/div/div[5]/input
        [FindsBy(How = How.XPath, Using = "//*[@class='button-1 login-button']")]
        public IWebElement btnLogin { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.master-wrapper-content > div.master-column-wrapper > div > div > div.page-body > div > div.returning-wrapper.fieldset > form > div.inner-wrapper.show > div.message-error > div")]
        public IWebElement txtvalidationsummaryerrors { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page.mobile-sticky-logo > div.master-wrapper-content > div.master-column-wrapper > div > div > div.page-body > div > div.new-wrapper.register-block > div.title")]
        public IWebElement LinkNewReg { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page.mobile-sticky-logo > div.master-wrapper-content > div.master-column-wrapper > div > div > div.page-body > div > div.new-wrapper.register-block > div.inner-wrapper.show > div.buttons > input")]
        public IWebElement btnReg { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='validation-summary-errors']")]
        public IWebElement ValSummErr { get; set; }



        /// <summary>
        /// Login into Smart Mall By providing the username passwod and for the
        /// rememberMe is the indicator tru of falase
        /// </summary>
        /// <param userName=UaserName for the login into system></param>
        /// <param password= Passwod for the user name provide to login into the system.></param>
        /// <param rememberMe=Is an Boolean type. True set the Remember me checkbox to tick. 
        ///                     false is to set the Remember me funciton checkbox to untick.></param>
        /// 
        
        public void Login(string userName, string password, bool rememberMe)
        {
            //UserName
            txtUserName.SendKeys(userName);

            //Password
            txtPassword.SendKeys(password);

            //Remember me option
            if (rememberMe.Equals(true))
            {
                chkboxRememberMe.Click();
            }


            btnLogin.Submit();

            /// need to have the page checking. if successful login the page will back to homepage is not will stay at the same page
            /// then only go to the below checking. That means i need to get the current login page screen and after click the sumbit button capture again
            /// then check if same go the the checking below. if not go to the home page.

            //string Validation = ValSummErr.Text;

            //if (Validation == "帐户不是活动的")
            //{
            //    log.Error("Error, Account is not active");
            //    //ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
            //    //ExtentManager.test.Log(Status.Pass, "Successful add product into Shopping cart.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());
            //    return new HomePageObject();
            //}
            //else
            //    return new HomePageObject();

            return; //new HomePageObject();
        }

    }
}
