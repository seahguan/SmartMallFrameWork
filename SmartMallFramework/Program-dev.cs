using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using System.Drawing.Imaging;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.PhantomJS;
using System.Data.SqlClient;
using System.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Drawing;
using SmartMallFramework.SmartMallPagesObjects;
using OpenQA.Selenium.Support.PageObjects;

// for the used to write the log report
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace SmartMallFramework
{

    [TestFixture]
    class Program
    {
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        //ExtentReports extent;
        //ExtentTest test;

        /// this is only log for "program.cs" or define as "/test/program.cs"
        // private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Program.cs");

        // for  .net4.5 can be using this method to write log which 
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // for .net4.6 need to used together with LogHelprt.cs
        // private static readonly log4net.ILog log = LogHelper.GetLogger();

        static void Main(string[] args)
        {
            //    // Get the current window handle so you can switch back later.
            //    string currentHandle = PropertiesCollections.driver.CurrentWindowHandle;

            //    // Find the element that triggers the popup when clicked on.
            //    // IWebElement element = PropertiesCollections.driver.FindElement(By.XPath("//*[@id='webtraffic_popup_start_button']"));

            //    // The Click method of the PopupWindowFinder class will click the desired element, 
            //    // wait for the popup to appear, and return the window handle to the popped-up browser window.
            //    // Note that you still need to switch to the window to manipulate the page displayed by the popup window.
            //    PopupWindowFinder finder = new PopupWindowFinder(PropertiesCollections.driver);
            //    string popupWindowHandle = finder.Click(element);

            //    PropertiesCollections.driver.SwitchTo().Window(popupWindowHandle);

            //    // Do whatever you need to on the popup browser, then...
            //    PropertiesCollections.driver.Close();
            //    PropertiesCollections.driver.SwitchTo().Window(currentHandle);

            //IWebDriver driver = new FirefoxDriver();

            ////driver.Navigate().GoToUrl("https://testwww.smartmall2u.com");

            //// Create an interface WebElement of the div under div with **class as facetContainerDiv**
            //IWebElement WebElement = driver.FindElement(By.CssSelector("body > div.master-wrapper-page > div.header > div.header-lower > div > div.category-navigation-list-wrapper"));

            //// Create an IList and intialize it with all the elements of div under div with **class as facetContainerDiv**
            //IList<IWebElement> AllCheckBoxes = WebElement.FindElements(By.CssSelector("body > div.master-wrapper-page > div.header > div.header-lower > div > div.category-navigation-list-wrapper"));

            //// Get the count of check boxes 
            //int RowCount = WebElement.FindElements(By.CssSelector("body > div.master-wrapper-page > div.header > div.header-lower > div > div.category-navigation-list-wrapper")).Count;
            //for (int i = 0; i < RowCount; i++)
            //{
            //    // Check the check boxes based on index
            //    AllCheckBoxes[i].Click();

            //}
            //Console.WriteLine(RowCount);
            //Console.ReadLine();
        }

        [SetUp]
        public void SetupTest()
        {
            try
            {
                PropertiesCollections.driver = new ChromeDriver();

                //PropertiesCollections.driver = new FirefoxDriver();
                //PropertiesCollections.driver = new EdgeDriver();


                baseURL = "https://testwww.smartmall2u.com/";
                verificationErrors = new StringBuilder();

                // Extent Report
                //extent = ExtentManager.GetExtent();
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
                PropertiesCollections.driver.Quit();
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



            try
            {
                // Create the Test case Name in the Extent Report
                ExtentManager.test = ExtentManager.extent.CreateTest("QAVSite", "New Registration Test Case");
                ExtentManager.test.Log(Status.Info, "Open Browser & SmartMall Home Page");

                // test = extent.CreateTest("QAVSite", "New Registration Test Case");
                // test.Log(Status.Info, "Open Browser & PEFA Mall Home Page");

                //ExtentManager.test.Log(Status.Info, "Open Browser & PEFA Mall Home Page");

                // Open the Browser and Navigate to the PEFA Mall home Page                
                PropertiesCollections.driver.Navigate().GoToUrl(baseURL + "/");
                PropertiesCollections.driver.Manage().Window.Maximize();

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
            DefinePath DP = new DefinePath();
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
                PropertiesCollections.driver.Navigate().GoToUrl(baseURL + "/");
                PropertiesCollections.driver.Manage().Window.Maximize();

                //// Get the current window handle so you can switch back later.
                //string currentHandle = PropertiesCollections.driver.CurrentWindowHandle;

                //// Define the Screen shot objects
                //GrabFullHeigthScreen ss = new GrabFullHeigthScreen();

                //// Declare the Top Menu Object
                //TopMenuBarObjects topmenu = new TopMenuBarObjects();
                //LoginPageObject LogIn = new LoginPageObject();

                //// Capture the PEFA Mall Home Page
                //ExtentImdPath = "";
                //ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                //ExtentManager.test.Log(Status.Pass, "Verify Home Page Info Successful", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                //// Mouse Hover on MY ACC to appear new register panel
                //MouseHover.ElementMouseOverbyCss("body > div.master-wrapper-page > div.header > div.header-upper > div.center > div.header-links-wrapper > label");

                //// Click on the login link to call the login page 
                //topmenu.ClickLogin();
                //ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                //ExtentManager.test.Log(Status.Pass, "Successful Call the Login Page.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                //// Fill up the user name and password. Then click on the login button.
                //LogIn.Login("seahguan", "123abc", true);
                //ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                //ExtentManager.test.Log(Status.Pass, "Successful Login into PEFAMall.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                //Alerthandles AH = new Alerthandles();
                //bool presentFlag = false;
                //AH.checkAlert(presentFlag);


                /// sample to locate the parent node
                /// IWebElement selectDayContainer = PropertiesCollections.driver.FindElement(By.XPath("//select[@name='day']//ancestor::div[contains(@class, 'select-container')]"));
                /// String toolTip = selectDayContainer.getAttribute("data-tooltip");


                // IList<IWebElement> allOptions = PropertiesCollections.driver.FindElements(By.XPath("//div[@class='product-item']//decestor::div[contains(@class, 'product-title')]"));
                //IList<IWebElement> allOptions = PropertiesCollections.driver.FindElements(By.XPath("//div[@class='item-box']"));
                IList<IWebElement> allOptions = PropertiesCollections.driver.FindElements(By.XPath("//div[@class='product-item']"));
                IList<IWebElement> productid = PropertiesCollections.driver.FindElements(By.XPath("//div[@class='product-item']/span[(@data-productid)]"));
                var lsg1 = allOptions[18].GetAttribute("data-productid");
                string prid = allOptions[18].Text;

                //IList<IWebElement> productid = PropertiesCollections.driver.FindElements(By.XPath("//div[contains @class='product-item' @data-productid]"));


                //string lsg = allOptions[19].GetAttribute("href");
                //string lsg2 = allOptions[19].Text;
                //SelectElement  select = new SelectElement(PropertiesCollections.driver.FindElement(By.XPath("//div[@class='item-box']")));
                //Select
                //IList<IWebElement> allOptionsval = select.AllSelectedOptions;

                //foreach (IWebElement option in allOptionsval)
                //{
                //    string tempaa = option.Text;
                //    Console.WriteLine(tempaa);
                //}


                //int totalcnt = allOptions.Count;

                String[] alltext = new String[allOptions.Count];
                
                int i = 0;
                
                foreach (IWebElement ele in allOptions)
                {
                    alltext[i++] = ele.Text;
                    int j = 0;
                    string txtproductid = ele.GetAttribute("data-");
                }
                                


               //IList<IWebElement> tempproduct = new List<IWebElement>();

                IWebElement tempproduct = PropertiesCollections.driver.FindElement(By.CssSelector("div#picture title"));
                string hrefvalue = tempproduct.GetAttribute("href");


                //  "ul#fruit li:nth-of-type(2)"

                //string textP = tempproduct.Text;

                //IWebElement selectproductid = PropertiesCollections.driver.FindElement(By.CssSelector("//href:contains(" + txtproduct + ")//ancestor::div[contains(@class, 'product-item')]"));
                //string productid = selectproductid.GetAttribute("data-productid");






                //HomePageObject HomePg = new HomePageObject();




                //topmenu.ClickMyAcc();
                //topmenu.

                //string subcategory = "Grocery";
                //topmenu.SelSubcategory(ref subcategory);

                //subcategory = "Food & Beverage";
                //topmenu.SelSubcategory(ref subcategory);

                /// Remark this bottom part as to debug the List<IWebelements></IWebelements>

                ////////// Enter a Product in the search box
                ////////topmenu.Fillsearch("【Skincode Essentials】Alpine White Brightening Day Cream SPF 15 (50ml)-MJ2+");
                ////////ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ////////ExtentManager.test.Log(Status.Pass, "Successful search out the product.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                ////////// click on the product details and add into the shopping cart
                ////////// Delcare search result screen objects

                ////////SearchResult SR = new SearchResult();

                ////////// click on the product go to the product details
                //////////SR.ClickBYTagName();
                //////////SR.ClickByClsName();
                ////////// here i declare the search product name into the "searchproductname" and send this to searchresult.cs function name "Resultlist"
                ////////// this is due to the search  result will be dynamic. so in the Resultlist function i will used the POM to list out all the elements
                ////////// at the search result class and compare to the "searchproductname" then select it to go into the details of the product.

                ////////string searchproductname = "Skincode Essentials】Alpine White Brightening Day Cream SPF 15 (50ml)-MJ2+";
                ////////SR.Resultlist(ref searchproductname);
                ////////ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ////////ExtentManager.test.Log(Status.Pass, "Successful go into the product details page.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                ////////// Declare the Product details Page objects
                ////////ProductDetailsPageObjects PD = new ProductDetailsPageObjects();

                ////////// At Product Details page click add the product into cart 
                ////////PD.clickAddToCart();
                ////////ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ////////ExtentManager.test.Log(Status.Pass, "Successful add product into Shopping cart.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                ////////// Click on the continue shopping button
                ////////PD.clickContinueShoppingbtn();
                ////////ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ////////ExtentManager.test.Log(Status.Pass, "Successful return to the product page.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                ////////// search another product 
                ////////topmenu.Fillsearch("OXY 10 Acne Pimple Medication 10g");
                ////////ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ////////ExtentManager.test.Log(Status.Pass, "Successful search out anothet new the product.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                ////////// click on the product go to the product details
                ////////SR.ClickBYTagName();
                ////////ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ////////ExtentManager.test.Log(Status.Pass, "Successful go into the product details page.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                ////////// add the product into cart
                ////////PD.clickAddToCart();
                ////////ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ////////ExtentManager.test.Log(Status.Pass, "Successful add product into Shopping cart.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                ////////// click on the shopping cart button
                ////////PD.clickGoToCartbtn();
                ////////ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ////////ExtentManager.test.Log(Status.Pass, "Successful go into the shopping cart page.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                ////////// click on the pefamall logo as to go back to the homepage
                ////////topmenu.ClickLogoimg();
                ////////ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ////////ExtentManager.test.Log(Status.Pass, "Successful go back to Hompe page screen.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                ////////// click on the shopping cart link on the home page.
                ////////topmenu.ClickShoppingCart();
                ////////ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ////////ExtentManager.test.Log(Status.Pass, "Successful go into shoping cart page.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());

                ////////// declare the shopping cart page objects
                ////////ShoppingCartPageObjects SC = new ShoppingCartPageObjects();

                ////////// at the shopping cart click onthe update cart and proceed to make payment.
                ////////SC.ClickContinuebtn();

                //////////// to be continue..... after test out a complete teat case 21/05/2017

                ////////// Mouse Hover on MY ACC to appear new register panel
                ////////MouseHover.ElementMouseOverbyCss("body > div.master-wrapper-page > div.header > div.header-upper > div.center > div.header-links-wrapper > label");

                ////////// put a waiting time as let the browser to load the page items.
                ////////PropertiesCollections.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));

                ////////// Logout from the system
                ////////topmenu.ClickLogOutBtn();
                ////////ss.TakesScreenshotWithDate(ScreenshotName, ActualImgPath, ImageFormat.Png, ref ExtentImdPath);
                ////////ExtentManager.test.Log(Status.Pass, "Successful Logout into PEFAMall.", MediaEntityBuilder.CreateScreenCaptureFromPath(ExtentImdPath).Build());
            }
            catch (Exception e)
            {
                log.Fatal("error message......", e);
                PropertiesCollections.driver.Quit();
            }
        }

        [Test]
        public void ExecuteMultipleMemberActivityTestcase()
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


                // Connection - test 1 
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

                // connect using the app.config way
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
            }
            catch (Exception e)
            {
                log.Fatal("email", e);
                PropertiesCollections.driver.Quit();
            }
            finally
            {
                PropertiesCollections.driver.Quit();
            }
        }


        /// <summary>
        /// Demo with Scenario by login and search 1 product and add 1 product into shopping cart and log out
        /// where here is capture the screen and log using extent report.
        /// </summary>
        //string Constr = ConfigurationManager.ConnectionStrings["PEFADBCN"].ConnectionString;
        //SqlConnection Conn = new SqlConnection(Constr);

        //try
        //{
        //    SqlHelper helper = new SqlHelper(Constr);

        //    if (helper.IsConnection)
        //    {
        //        log.Info("Successfull open the DB Connection.");
        //        Conn.Open();
        //    }
        //}
        //catch (Exception e)
        //{
        //    log.Fatal("Fail to open the connectode in the program.", e);
        //}

        //Conn.Close();

        private bool IsElementPresent(By by)
        {
            try
            {
                PropertiesCollections.driver.FindElement(by);
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
                PropertiesCollections.driver.SwitchTo().Alert();
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
                IAlert alert = PropertiesCollections.driver.SwitchTo().Alert();
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
