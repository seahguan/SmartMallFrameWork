using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using AventStack.ExtentReports;

namespace SmartMallFramework
{
    class TopMenuBarObjects
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TopMenuBarObjects()
        {
            // to initialize all the object in this page
            PageFactory.InitElements(Browser.driver, this);
        }

        //SmartMall Logo
        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.header > div.header-middle > div > div.header-logo > a > div > img")]
        public IWebElement logoimg { get; set; }

        [FindsBy(How = How.ClassName, Using = "theme-image")]
        public IWebElement logoimg2 { get; set; }

        //Top Menu = My Acc                      
        [FindsBy(How = How.CssSelector, Using = "div.header-links")]
        public IWebElement myacc { get; set; }

        // Top Menu = My Acc Label
        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.header > div.header-upper > div.center > div.header-links-wrapper > label")]
        public IWebElement HeaderLblMyAcc { get; set; }

        //Top Menu = Login Button
        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.header > div.header-upper > div.center > div.header-links-wrapper > div > ul > li:nth-child(2) > a")]
        public IWebElement linkLogin { get; set; }

        [FindsBy(How = How.LinkText, Using = "Log in")]
        public IWebElement txtLogin { get; set; }

        //Top Menu = LogOut Button
        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.header > div.header-upper > div.center > div.header-links-wrapper > div > ul > li:nth-child(3) > a")]
        public IWebElement btnLogout { get; set; }

        [FindsBy(How = How.LinkText, Using = "Log out")]
        public IWebElement txtLogOut { get; set; }

        //Top Menu = Language Label
        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.header > div.header-upper > div.center > div.header-selectors-wrapper > label")]
        public IWebElement languagelbl { get; set; }

        //Top Menu = Language Drop Down List
        [FindsBy(How = How.Id, Using = "customerlanguage")]
        public IWebElement ddllanguage { get; set; }

        //Top Menu = Shopping cart
        [FindsBy(How = How.CssSelector, Using = "#flyout-cart > a")]
        public IWebElement shoppingcart { get; set; }

        //Top Menu = Search Store
        [FindsBy(How = How.Id, Using = "small-searchterms")]
        public IWebElement searchstore { get; set; }

        //Top Menu = Search Button
        [FindsBy(How = How.CssSelector, Using = ".button-1.search-box-button")]
        public IWebElement btnSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul [@class='category-navigation-list']")]
        public IList<IWebElement> ArrlinkSubCategory { get; set; }

        /// <summary>
        /// From this part on onwards is to create the funciton  that to execute the
        /// verificaiton on the page on the Top menu element by using the Webdriver with 
        /// CSS Selector option.
        /// 


        /// <summary>
        /// Verify Logo Image
        /// </summary>
        /// <param txtelementname=Logo Element name></param>
        /// <param txtAttribute=Attribute type for the logo></param>
        public void verifylogoimg(string txtelementname, string txtAttribute)
        {
            string actualvalue = logoimg.GetAttribute(txtAttribute);

            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Logo Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Logo Verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify logo. Error Code : ", e);
            }

        }


        /// <summary>
        /// Verify the MY Account Link on the Top Menu bar
        /// </summary>
        /// <param txtelementname=My Account link elelemnt name></param>
        /// <param txtAttribute= Attribute name of the element></param>
        public void verifymyacc(string txtelementname, string txtAttribute)
        {
            string actualvalue = myacc.GetAttribute(txtAttribute);
            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "My Account Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "My Account Verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify My Account. Error Code : ", e);
            }
        }

        /// <summary>
        /// Verify the "My Account" Label Beside the Languange
        /// </summary>
        /// <param name="txtelementname"></param>
        /// <param name="txtAttribute"></param>
        public void verifymyacclbl(string txtelementname, string txtAttribute)
        {
            string actualvalue = "";

            if (txtAttribute == "label")
            {
                var tmpvalue = HeaderLblMyAcc.Text;
                actualvalue = tmpvalue.ToString();
            }
            else
            {
                actualvalue = HeaderLblMyAcc.GetAttribute(txtAttribute);
            }

            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "My Account Label Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "My Account Label Verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify My Account. Error Code : ", e);
            }
        }

        /// <summary>
        /// verify the Login link under the "MY Account" beside the Language on top of the menu
        /// </summary>
        /// <param name="txtelementname"></param>
        /// <param name="txtAttribute"></param>
        public void verifybtnLogin(string txtelementname, string txtAttribute)
        {
            string actualvalue = linkLogin.GetAttribute(txtAttribute);
            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Login objects Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Login objects verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Login objects. Error Code : ", e);
            }
        }

        /// <summary>
        /// verify the Logout link under the "MY Account" beside the Language on top of the menu
        /// </summary>
        /// <param name="txtelementname"></param>
        /// <param name="txtAttribute"></param>
        public void verifybtnLogout(string txtelementname, string txtAttribute)
        {
            string actualvalue = btnLogout.GetAttribute(txtAttribute);
            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Logout objects Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Logout objects verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Logout objects. Error Code : ", e);
            }
        }

        /// <summary>
        /// Verify the Languange Label on top of the menu
        /// </summary>
        /// <param name="txtelementname"></param>
        /// <param name="txtAttribute"></param>
        public void verifylanguagelbl(string txtelementname, string txtAttribute)
        {
            string actualvalue = "";

            if (txtAttribute == "label")
            {
                actualvalue = languagelbl.GetText();
            }
            else
            {
                actualvalue = languagelbl.GetAttribute(txtAttribute);
            }

            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Language objects Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Language  objects verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Language  objects. Error Code : ", e);
            }
        }

        /// <summary>
        /// Verify the Language Drop Down Listing on top of the menu
        /// </summary>
        /// <param name="txtelementname"></param>
        /// <param name="txtAttribute"></param>
        public void verifyddllanguage(string txtelementname, string txtAttribute)
        {
            string actualvalue = ddllanguage.GetAttribute(txtAttribute);
            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Language Drop Down Listing objects Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Language Drop Down Listing objects verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Language Drop Down Listing objects. Error Code : ", e);
            }
        }

        /// <summary>
        /// Verify the Shopping Cart object on top of the menu
        /// </summary>
        /// <param name="txtelementname"></param>
        /// <param name="txtAttribute"></param>
        public void verifyshoppingcart(string txtelementname, string txtAttribute)
        {
            string actualvalue = shoppingcart.GetAttribute(txtAttribute);
            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Shopping Cart Listing objects Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Shopping Cart Listing objects verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Shopping Cart Listing objects. Error Code : ", e);
            }
        }

        /// <summary>
        /// Verify the search bar text field on top of the menu
        /// </summary>
        /// <param name="txtelementname"></param>
        /// <param name="txtAttribute"></param>
        public void verifysearchstore(string txtelementname, string txtAttribute)
        {
            string actualvalue = searchstore.GetAttribute(txtAttribute);
            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Search Box objects Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Search Box objects verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Search Box objects. Error Code : ", e);
            }
        }

        /// <summary>
        /// Verify the search icon field on top of the menu
        /// </summary>
        /// <param name="txtelementname"></param>
        /// <param name="txtAttribute"></param>
        public void verifybtnSearch(string txtelementname, string txtAttribute)
        {
            string actualvalue = btnSearch.GetAttribute(txtAttribute);
            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Search Button objects Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Search Button objects verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Search Button objects. Error Code : ", e);
            }
        }

        
        /// <summary>
        /// click the logo action
        /// </summary>
        public void ClickLogoimg()
        {
            logoimg.Clicks();
        }

        /// <summary>
        /// click the My Account action
        /// </summary>
        public void ClickMyAcc()
        {
            myacc.Clicks();
        }

        /// <summary>
        /// click the Logout button action
        /// </summary>
        public void ClickLogOutBtn()
        {
            btnLogout.Clicks();
        }

        /// <summary>
        /// click the Login button action
        /// </summary>
        public void ClickLogin()
        {
            linkLogin.Clicks();
        }

        /// <summary>
        /// click the Search Button action
        /// </summary>
        public void ClickSearchBtn()
        {
            btnSearch.Clicks();
        }

        /// <summary>
        /// click the Shopping Cart logo action
        /// </summary>
        public void ClickShoppingCart()
        {
            shoppingcart.Clicks();
        }

        /// <summary>
        /// Fill up the search bat field
        /// </summary>
        public void Fillsearch(string txtsearchitem)
        {
            searchstore.EnterText(txtsearchitem);
            ClickSearchBtn();
        }

        /// <summary>
        /// Choose the language or change the language of the smart mall.
        /// </summary>
        public void ChooseLanguage(string txtlanguage)
        {
            ddllanguage.SelectDRopDown(txtlanguage);
        }

        /// <summary>
        /// fill up the search bar item and click on the search button.
        /// </summary>
        /// <param name="txtsearchitem"></param>
        public void SearchStoreAction(string txtsearchitem)
        {
            searchstore.EnterText(txtsearchitem);
            btnSearch.Clicks();
        }

        /// <summary>
        /// Select the sub category in the top menu bar
        /// </summary>
        /// <param txtselcategory=Sub catetory name to be selected.></param>
        public void SelSubcategory(ref string txtselcategory)
        {
            try
            {
                IList<IWebElement> allSubcategory = ArrlinkSubCategory;

                String[] txtsubcategory = new String[allSubcategory.Count];
                int i = 0;
                foreach (IWebElement element in allSubcategory)
                {
                    txtsubcategory[i++] = element.Text;  // || .GetAttribute("href");
                    IWebElement subcatlink = element;

                    if (txtsubcategory[i].Contains(txtselcategory))
                    {
                        subcatlink.Click();
                    }
                }
            }
            catch (Exception e)
            {
                log.Warn("Error :", e);

            }
        }
    }
}
