using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Configuration;
using NUnit;
using NUnit.Framework;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;


// for the used to write the log report
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace SmartMallFramework
{
    [TestFixture]
    [Parallelizable]
    public class ChromeTesting : Hook
    {
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ChromeTesting() : base(BrowserType.Chrome)
        {

        }

        [SetUp]
        public void SetupTest()
        {
            try
            {
                driver = new ChromeDriver();
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);

                baseURL = "https://testwww.smartmall2u.com/";
                verificationErrors = new StringBuilder();

                // Extent Report => at here is to declare the test report objects                
                ExtentManager.GetExtent();
            }
            catch (Exception e)
            {
                log.Fatal("Create driver encounter error : ", e);
            }
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
                ExtentManager.extent.Flush();
            }
            catch (Exception e)
            {
                // Ignore errors if unable to close the browser
                log.Fatal("Ignore errors if unable to close the browser. Error Code : ", e);
            }
        }

        [Test]
        public void ChromeTest()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.Manage().Window.Maximize();
            TopMenuBarObjects topmenu = new TopMenuBarObjects();
            LoginPageObject LogIn = new LoginPageObject();

            // Mouse Hover on MY ACC to appear new register panel => which is move the mouse cursor to the dedicated place
            MouseHover.ElementMouseOverbyCss("body > div.master-wrapper-page > div.header > div.header-upper > div.center > div.header-links-wrapper > label");

            // Click on the login link to call the login page 
            topmenu.ClickLogin();

            LogIn.Login("seahguan", "123abc", false);

            MouseHover.ElementMouseOverbyCss("body > div.master-wrapper-page > div.header > div.header-upper > div.center > div.header-links-wrapper > label");
            topmenu.ClickLogOutBtn();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                Browser.driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                Browser.driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = Browser.driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }

    [TestFixture]
    [Parallelizable]
    public class FireFoxTesting : Hook
    {
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FireFoxTesting() : base(BrowserType.FireFox)
        {
        }

        [SetUp]
        public void SetupTest()
        {
            try
            {
                Browser.driver = new ChromeDriver();
                Browser.driver.Manage().Cookies.DeleteAllCookies();
                Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                Browser.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);

                baseURL = "https://testwww.smartmall2u.com/";
                verificationErrors = new StringBuilder();

                // Extent Report => at here is to declare the test report objects                
                ExtentManager.GetExtent();
            }
            catch (Exception e)
            {
                log.Fatal("Create driver encounter error : ", e);
            }
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                Browser.driver.Quit();
                ExtentManager.extent.Flush();
            }
            catch (Exception e)
            {
                // Ignore errors if unable to close the browser
                log.Fatal("Ignore errors if unable to close the browser. Error Code : ", e);
            }
        }

        [Test]
        public void FireFoxTest()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.Manage().Window.Maximize();
            TopMenuBarObjects topmenu = new TopMenuBarObjects();
            LoginPageObject LogIn = new LoginPageObject();

            // Mouse Hover on MY ACC to appear new register panel => which is move the mouse cursor to the dedicated place
            MouseHover.ElementMouseOverbyCss("body > div.master-wrapper-page > div.header > div.header-upper > div.center > div.header-links-wrapper > label");

            // Click on the login link to call the login page 
            topmenu.ClickLogin();

            LogIn.Login("seahguan", "123abc", false);

            MouseHover.ElementMouseOverbyCss("body > div.master-wrapper-page > div.header > div.header-upper > div.center > div.header-links-wrapper > label");
            topmenu.ClickLogOutBtn();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                Browser.driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                Browser.driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = Browser.driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

    }


    [TestFixture]
    class Program
    {
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        /// this is only log for "program.cs" or define as "/test/program.cs"
        // private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Program.cs");

        // for  .net4.5 can be using this method to write log which 
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // this will no need to declare the "private static readonly..." in every class
        // YouTube tutorial => "https://www.youtube.com/watch?v=2lAdQ_QwNww"
        // private static readonly log4net.ILog log = LogHelper.GetLogger(); 

        static void Main(string[] args)
        {
            //    // Get the current window handle so you can switch back later.
            //    string currentHandle = Browser.driver.CurrentWindowHandle;

            //    // Find the element that triggers the popup when clicked on.
            //    // IWebElement element = Browser.driver.FindElement(By.XPath("//*[@id='webtraffic_popup_start_button']"));

            //    // The Click method of the PopupWindowFinder class will click the desired element, 
            //    // wait for the popup to appear, and return the window handle to the popped-up browser window.
            //    // Note that you still need to switch to the window to manipulate the page displayed by the popup window.
            //    PopupWindowFinder finder = new PopupWindowFinder(Browser.driver);
            //    string popupWindowHandle = finder.Click(element);

            //    Browser.driver.SwitchTo().Window(popupWindowHandle);

            //    // Do whatever you need to on the popup browser, then...
            //    Browser.driver.Close();
            //    Browser.driver.SwitchTo().Window(currentHandle);
            //try
            //{
            //    Browser.driver = new ChromeDriver();

            //    string baseURL = "https://testwww.smartmall2u.com/";

            //    Browser.driver.Navigate().GoToUrl(baseURL + "/");
            //    Browser.driver.Manage().Window.Maximize();

            //    TopMenuBarObjects topmenu = new TopMenuBarObjects();
            //    LoginPageObject LogIn = new LoginPageObject();
            //    HomePageObject HP = new HomePageObject();
            //    SearchResult SR = new SearchResult();
            //    MouseHover.ElementMouseOverbyCss("body > div.master-wrapper-page > div.header > div.header-upper > div.center > div.header-links-wrapper > label");
            //    topmenu.ClickLogin();
            //    LogIn.Login("seahguan", "123abc", false);

            //    string searchproductname = "【Skincode Essentials】Gentle Cleansing Lotion (200ml)";
            //    topmenu.Fillsearch(searchproductname);

            //    Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            //    SR.SelSearchResult(ref searchproductname);

            //    ProductDetailsPageObjects PD = new ProductDetailsPageObjects();

            //IList<IWebElement> shippingcountry = Browser.driver.FindElements(By.XPath("//ul[@class='option-list']/li"));
            //String[] txtshippingcountry = new String[shippingcountry.Count];

            //foreach (IWebElement ele in shippingcountry)
            //{
            //    string txtctry = ele.Text;
            //}

            //Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            //PD.SelectShipTo("Malaysia");
            //PD.ClickWishList();

            //IWebElement alertwin = Browser.driver.FindElement(By.CssSelector(".productAddedToCartWindowTitle"));
            //alertwin.Click();                

            //PD.ClickAddToCart();

            //IWebElement btn = Browser.driver.FindElement(By.CssSelector("input.button-1.productAddedToCartWindowCheckout"));                
            //IWebElement btn2 = Browser.driver.FindElement(By.XPath("//*[@class='continueShoppingLink']"));

            //btn.Click();
            //btn2.Click();
            //    Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            //    PD.ClickGoTOCart();

            //    ShoppingCartPageObjects SC = new ShoppingCartPageObjects();

            //    Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            //    // click on the continue button or checkout button at shopping cart
            //    SC.ClickContinuebtn();

            //    string ShippingAddressName = "LSG - China test - China addr";

            //    ShippingAddressPageObjects SPAddr = new ShippingAddressPageObjects();

            //    Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            //    SPAddr.SelShippingAddress(ShippingAddressName);

            //    ShoppingCartCfmPageObjects SPCfmPage = new ShoppingCartCfmPageObjects();

            //    Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            //    SPCfmPage.ClickConfrmationBtn(true);

            //    ThankYouPageObjects THK = new ThankYouPageObjects();

            //    Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            //    THK.ClickContinueBtn();

            //    MouseHover.ElementMouseOverbyCss("body > div.master-wrapper-page > div.header > div.header-upper > div.center > div.header-links-wrapper > label");

            //    //Logout from the system
            //    topmenu.ClickLogOutBtn();
            //    Browser.driver.Quit();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("error : " + e);
            //}

        }

        [SetUp]
        public void SetupTest()
        {
            try
            {
                Browser.driver = new ChromeDriver();
                Browser.driver.Manage().Cookies.DeleteAllCookies();
                Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                Browser.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);

                //Browser.driver = new FirefoxDriver();
                //Browser.driver = new EdgeDriver();

                // This part is the setting for the used of selenium grid that allow us to run
                //// on different browser and different machine
                //DesiredCapabilities capababilities = new DesiredCapabilities();
                //capababilities = DesiredCapabilities.Chrome();
                //capababilities.SetCapability(CapabilityType.BrowserName, "Chrome");
                //capababilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));

                //Browser.driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capababilities);



                baseURL = "https://testwww.smartmall2u.com/";
                verificationErrors = new StringBuilder();

                // Extent Report => at here is to declare the test report objects                
                ExtentManager.GetExtent();
            }
            catch (Exception e)
            {
                log.Fatal("Create driver encounter error : ", e);
            }
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                Browser.driver.Quit();
                ExtentManager.extent.Flush();
            }
            catch (Exception e)
            {
                // Ignore errors if unable to close the browser
                log.Fatal("Ignore errors if unable to close the browser. Error Code : ", e);
            }
        }

        /// <summary>
        /// Register New Customer 
        /// </summary>
        /// 

        [Test]
        public void ExecuteVerifyObjectsTestCase()
        {
            // set the Screen Shot Name to be used in this test case
            string ScreenshotName = "ExecuteVerifyObjects";
            DefinePath DP = new DefinePath();
            string ActualImgPath = DP.setupExtenImagesPath(out ActualImgPath);
            string ActualProPath = DP.setupExtenReportPath(out ActualProPath);
            string ExtentImdPath = "";

            //IWebElement lsg = Browser.driver.FindElement(By.)

            try
            {
                // Create the Test case Name in the Extent Report
                ExtentManager.test = ExtentManager.extent.CreateTest("QAVSite", "New Registration Test Case");
                ExtentManager.test.Log(Status.Info, "Open Browser & SmartMall Home Page");


                // test = extent.CreateTest("QAVSite", "New Registration Test Case");
                // test.Log(Status.Info, "Open Browser & PEFA Mall Home Page");

                //ExtentManager.test.Log(Status.Info, "Open Browser & PEFA Mall Home Page");

                // Open the Browser and Navigate to the PEFA Mall home Page                
                Browser.driver.Navigate().GoToUrl(baseURL + "/");
                Browser.driver.Manage().Window.Maximize();

                // Define the Screen shot objects
                GrabFullHeigthScreen ss = new GrabFullHeigthScreen();

                // declare all the objects name to be used
                TopMenuBarObjects TopMB = new TopMenuBarObjects();
                BottomBarObjects BottMB = new BottomBarObjects();

                var ChildTest1 = ExtentManager.test.CreateNode("QAVSite", "Verifying the Top Menu Objects availbility");

                // Verify Top menu bar info                

                TopMB.verifylogoimg("Glorious Chain Stores Sdn Bhd (1009362-W)", "alt");
                TopMB.verifymyacc("My account", "title");
                TopMB.verifymyacclbl("My Account", "label");
                TopMB.verifybtnLogin(baseURL + "login", "href");
                TopMB.verifylanguagelbl("Language", "label");
                TopMB.verifyddllanguage("customerlanguage", "id");
                TopMB.verifysearchstore("q", "name");
                TopMB.verifybtnSearch("button-1 search-box-button", "class");
                TopMB.verifyshoppingcart("cart-trigger", "class");

                // Create child test node status
                // ChildTest1.Pass("Successful verify the Top menu Objects");

                //Verify Bottom / footer menu bar info
                BottMB.verifylblInformations("INFORMATION", "class");
                BottMB.verifylinkAboutUs(baseURL + "about-us-2", "href");
                BottMB.verifylinkAnnoucement(baseURL + "announcement", "href");
                BottMB.verifylinkPurchaseFlow(baseURL + "purchase-flow", "href");
                BottMB.verifylinkReturn(baseURL + "return-refund", "href");
                BottMB.verifylinkFAQ(baseURL + "faq", "href");
                BottMB.verifylblMyAcc("MY ACCOUNT", "class");
                BottMB.verifylinkCustomerInfo(baseURL + "customer/info", "href");
                BottMB.verifylblContactUs("CONTACT US", "class");
                BottMB.verifylblEmail("cs@pefamall.com", "class");
                BottMB.verifylblDisclaim("Copyright © 2017 Glorious Chain Stores Sdn Bhd (1009362-W). All rights reserved.", "class");

                // Create child test node status
                ChildTest1.Pass("Successful verify the Bottom / Footer Objects");

                ChildTest1 = ExtentManager.test.CreateNode("QAVSite", "Verifying the Bottom / Foooter Objects availbility");

                // After Verify all the objects proceed to capture screen
                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                //test.Log(Status.Pass, "Verify Home Page Info Successful", MediaEntityBuilder.CreateScreenCaptureFromPath(ActualImgPath + "\\" + ScreenshotName).Build());
                ExtentManager.test.Log(Status.Pass, "Verify Home Page Info Successful", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                // Mouse Hover on MY ACC to appear new register panel
                MouseHover.ElementMouseOverbyCss("body > div.master-wrapper-page > div.header > div.header-upper > div.center > div.header-links-wrapper > label");

                ExtentImdPath = "";
                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "New Registraion Screen Successfull Open.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                ExtentImdPath = "";
                // fill in new registration details

                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "New Regitration - Fill in all fields", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                // At here is to check the user name avaibility and if not available, will auto add in counter at the end of the user name
                // and recheck until available then continue the registration.

                ExtentImdPath = "";
                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "New Regitration Member Successful.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());
            }
            catch (Exception e)
            {
                log.Fatal("Encounter Error ", e);
                ExtentManager.extent.Flush();
            }
        }

        [Test]
        public void ExecuteSingleMemberActivityTestcase()
        {
            // set the Screen Shot Name to be used in this test case
            string ScreenshotName = "ExecuteSingleMemberActivityTestcase";

            // Declare the DP as a object that store all the function in the DefinePath.cs
            DefinePath DP = new DefinePath();

            // Define the output path folder for the report and the image capture store at
            string ActualImgPath = DP.setupExtenImagesPath(out ActualImgPath);
            string ActualProPath = DP.setupExtenReportPath(out ActualProPath);
            string ExtentImdPath = "";

            try
            {
                // Create the Test case Name in the Extent Report
                ExtentManager.test = ExtentManager.extent.CreateTest("QAVSite", "New Registration Test Case");
                ExtentManager.test.Log(Status.Info, "Open Browser & PEFA Mall Home Page");

                // Open the Browser and Navigate to the PEFA Mall home Page
                ExtentManager.test.Log(Status.Info, "Open Browser & PEFA Mall Home Page");
                Browser.driver.Navigate().GoToUrl(baseURL + "/");
                Browser.driver.Manage().Window.Maximize();

                // Declare the Top Menu Object
                TopMenuBarObjects topmenu = new TopMenuBarObjects();
                LoginPageObject LogIn = new LoginPageObject();

                // Get the current window handle so can switch back later. (in the mid of study)
                string currentHandle = Browser.driver.CurrentWindowHandle;

                // Define the Screen shot objects
                GrabFullHeigthScreen ss = new GrabFullHeigthScreen();

                // Capture the SmartMall Home Page
                ExtentImdPath = "";
                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "Verify Home Page Info Successful", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                // Mouse Hover on MY ACC to appear new register panel => which is move the mouse cursor to the dedicated place
                MouseHover.ElementMouseOverbyCss("body > div.master-wrapper-page > div.header > div.header-upper > div.center > div.header-links-wrapper > label");

                // Click on the login link to call the login page 
                topmenu.ClickLogin();

                // capture the screen after click the login button => Login page
                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "Successful Call the Login Page.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                // Fill up the user name and password. Then click on the login button.
                LogIn.Login("seahguan", "123abc", false);

                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "Successful Login into PEFAMall.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                string searchproductname = "【Skincode Essentials】Gentle Cleansing Lotion (200ml)";
                // send a Product anme in the search box
                topmenu.Fillsearch(searchproductname);
                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "Successful search out the product.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                // click on the product details and add into the shopping cart
                // Delcare search result screen objects
                SearchResult SR = new SearchResult();

                // here i declare the search product name into the "searchproductname" and send this to searchresult.cs function name "Resultlist"
                // this is due to the search  result will be dynamic. so in the Resultlist function i will used the POM to list out all the elements
                // at the search result class and compare to the "searchproductname" then select it to go into the details of the product.

                SR.SelSearchResult(ref searchproductname);
                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "Successful go into the product details page.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                // Declare the Product Details object
                ProductDetailsPageObjects PD = new ProductDetailsPageObjects();

                // select the shipping country
                PD.SelectShipTo("Malaysia");

                PD.ClickWishList();
                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "Successfull add the product into wishlist.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                PD.ClickCtnShopping();
                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "Continue shopping link work accordingly after click on the wishlist.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                //PD.ClickWishListB();

                // add the product into the shopping cart
                PD.ClickAddToCart();
                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "Product add into cart and next will click on continue shopping button.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                // Click on the continue shopping button
                PD.ClickCtnShopping();

                //click back to the SmartMall Home Page and proceed to search another product again.
                topmenu.ClickLogoimg();
                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "Successful back to the Smart Mall Home Page.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                //declare the homepage object
                HomePageObject HP = new HomePageObject();

                // click on the product listed on the home page 
                string SelectProductName = "【Product of Malaysia】Breath-Care (60 pcs)";
                HP.ClickFeaturesProduct(ref SelectProductName);

                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "Successful select the product at the homepage and go in the product details page.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                // put a wait element 
                Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                // add the product into cart
                PD.ClickAddToCart();
                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "Successful add product into Shopping cart then next click on the go to cart button.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                // click on the shopping cart button
                PD.ClickGoTOCart();
                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "Successful go into the shopping cart page.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                // declare the Shopping cart page object
                ShoppingCartPageObjects SC = new ShoppingCartPageObjects();

                // click on the continue button or checkout button at shopping cart
                SC.ClickContinuebtn();
                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "Successful click on the checout button at shopping cart and go to next page to select shipping address.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                // declare the shipping address page object
                ShippingAddressPageObjects SPAddr = new ShippingAddressPageObjects();

                // define the shipping address 
                string ShippingAddressName = "lsg lsg";

                SPAddr.SelShippingAddress(ShippingAddressName);
                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "Successful click on the checout button at shopping cart and go to next page to select shipping address.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                // declare the shipping confirmation page object
                ShoppingCartCfmPageObjects SPCfmPage = new ShoppingCartCfmPageObjects();

                // click on the confirmation button
                SPCfmPage.ClickConfrmationBtn(true);
                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "Click on the confirmation button and click on the accept button on the pop out confirmation screen.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                // declare the Thanks you page object
                ThankYouPageObjects THK = new ThankYouPageObjects();

                THK.ClickContinueBtn();
                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "Click on the continue button and back to the home screen.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                // Mouse Hover on MY ACC to appear new register panel
                MouseHover.ElementMouseOverbyCss("body > div.master-wrapper-page > div.header > div.header-upper > div.center > div.header-links-wrapper > label");

                //Logout from the system
                topmenu.ClickLogOutBtn();
                ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ExtentManager.test.Log(Status.Pass, "Successful Logout into PEFAMall.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());
            }
            catch (Exception e)
            {
                log.Fatal("error message......", e);
                Browser.driver.Quit();
            }
        }

        [Test]
        public void SampleSQLConnection()
        {
            try
            {
                //Define the SQL connection
                // this is hardcoded way and below is the connect to local DB using the windows authentification
                // SqlConnection Con = new SqlConnection("data source=.; database=JX; integrated security =SSPI");
                SqlConnection Con = new SqlConnection("data source=.; database=JX; User Id=sa; password=seahguan");

                // set the SQL query command
                SqlCommand cmd = new SqlCommand("select count(*) from member", Con);

                //Open the connection
                Con.Open();

                // Execute the command
                SqlDataReader rdr = cmd.ExecuteReader();

                Console.WriteLine("SQL result : " + rdr);

                // Close the connection
                Con.Close();


                // Connection Method 1 
                string connectionString = "data source=.; database=JX; User Id=sa; password=seahguan";
                try
                {
                    SqlHelper helper = new SqlHelper(connectionString);

                    if (helper.IsConnection)
                    {
                        AppSetting setting = new AppSetting();
                        setting.SaveConnectionString("cn", connectionString);
                        log.Info("Successfull open the DB Connection.");
                    }
                }
                catch (Exception e)
                {
                    log.Fatal("Fail to open the connectode in the program.", e);
                }


                // Connection to SQL - Mehthod 2 using the App.config file
                // for this need to refer to the App.config file and refer to the name = ""                
                string CS = ConfigurationManager.ConnectionStrings["PEFADBCN"].ConnectionString;
                SqlConnection Con2 = new SqlConnection(CS);

                // set the SQL query command
                SqlCommand cmd2 = new SqlCommand("select count(*) from Customer", Con2);

                //Open the connection
                Con2.Open();

                // Execute the command
                SqlDataReader rdr2 = cmd.ExecuteReader();

                Console.WriteLine("SQL result : " + rdr2);

                // Close the connection
                Con2.Close();
                // Execute the command       

                //// this is to handle the alert message if the message appear
                //// => not yet fully tested.
                //Alerthandles AH = new Alerthandles();
                //bool presentFlag = false;
                //AH.checkAlert(presentFlag);                
            }
            catch (Exception e)
            {
                log.Fatal("email", e);
                Browser.driver.Quit();
            }
            finally
            {
                Browser.driver.Quit();
            }
        }


        private bool IsElementPresent(By by)
        {
            try
            {
                Browser.driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                Browser.driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = Browser.driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

    }
}
