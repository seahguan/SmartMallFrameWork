using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PefaMallFramework
{
    class LoginPageObjects
    {

        public LoginPageObjects()
        {
            // to initialize all the object in this login page  using Chrome Browser
            PageFactory.InitElements(PropertiesCollections.Cdriver, this);
            
            // to initialize all the object in this login page  using FireFoxBrowser
            PageFactory.InitElements(PropertiesCollections.Fdriver, this);

            // to initialize all the object in this login page  using Edge Browser
            PageFactory.InitElements(PropertiesCollections.Edriver, this);
        }

        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.button-1.login-button")]
        public IWebElement btnLogin { get; set; }

        [FindsBy(How = How.Name, Using = "RememberMe")]
        public IWebElement chkboxRememberMe { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[8]/div[4]/div[2]/div/div/div[2]/div/div[2]/form/div[2]/div/div[4]/span/a")]
        public IWebElement linkForgotPasswd { get; set; }


        public HomePageObject Login(string userName, string password)
        { 
            //UserName
            txtUserName.SendKeys(userName);

            //Password
            txtPassword.SendKeys(password);

            //clcik button
            btnLogin.Submit();

            //Return the page object
            return new HomePageObject();
        
        }
    }
}
