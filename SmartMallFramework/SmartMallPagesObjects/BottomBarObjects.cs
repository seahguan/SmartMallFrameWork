using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using AventStack.ExtentReports;
using NUnit.Framework;

namespace SmartMallFramework
{
    class BottomBarObjects
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public BottomBarObjects()
        {
            PageFactory.InitElements(Browser.driver, this);
        }

        /// <summary>
        ///   Declare all the Bottom bar / footer objects as POM method
        /// </summary>
        /// 
        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(1) > div > div")]

        public IWebElement lblInformations { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(1) > ul > li:nth-child(1) > a")]
        public IWebElement linkAboutUs { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(1) > ul > li:nth-child(2) > a")]
        public IWebElement linkAnnoucement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(2) > div > div")]
        public IWebElement lblMyAcc { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(2) > ul > li:nth-child(1) > a")]
        public IWebElement linkCustomerInfo { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(2) > ul > li:nth-child(2) > a")]
        public IWebElement linkPurchaseFlow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(2) > ul > li:nth-child(3) > a")]
        public IWebElement linkReturn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(2) > ul > li:nth-child(4) > a")]
        public IWebElement linkVendorReg { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(2) > ul > li:nth-child(5) > a")]
        public IWebElement linkFAQ { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(3) > div > strong")]
        public IWebElement lblPoliciesnPrinciples { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(3) > ul > li:nth-child(1) > a")]
        public IWebElement linkCopyright { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(3) > ul > li:nth-child(2) > a")]
        public IWebElement linkLegalNotice { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(3) > ul > li:nth-child(3) > a")]
        public IWebElement linkTermofService { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(3) > ul > li:nth-child(4) > a")]
        public IWebElement linkPrivacyStatement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(4) > div:nth-child(1) > div")]
        public IWebElement lblCustomerServ { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(4) > ul:nth-child(2) > li:nth-child(2) > div > div:nth-child(1)")]
        public IWebElement lblOperatingdays { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(4) > ul:nth-child(2) > li:nth-child(2) > div > div:nth-child(2)")]
        public IWebElement lblOperatinghours { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(4) > div:nth-child(3) > div")]
        public IWebElement lblContactUs { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(4) > ul:nth-child(4) > li > div > div:nth-child(2)")]
        public IWebElement lblEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-lower > div > div.footer-disclaimer")]
        public IWebElement lblDisclaim { get; set; }

        [FindsBy(How = How.Id, Using = "ph-title")]
        public IWebElement txtPhTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#ph-topic > div.page-body > p > img")]
        public IWebElement imgpurchaseflow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#ph-topic > div.page-body > p:nth-child(16) > span > img")]
        public IWebElement imgreturnflow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.footer > div.footer-middle > div > div:nth-child(2) > ul > li:nth-child(6) > a")]
        public IWebElement linkVendorRegistor { get; set; }

        /// <summary>
        ///     Declare all the Verify function for all the display info on the bottom bar/Footer
        /// </summary>

        // Verify the Information label at the bottom bar menu
        public void verifylblInformations(string txtelementname, string txtAttribute)
        {            
            string actualvalue = lblInformations.Text;

            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Label \"Information\" verify sucessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Label \"Information\" verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify \"Information\" label. Error Code : ", e);
            }
        }

        // Verify the About Us Link at the bottom bar menu
        public void verifylinkAboutUs(string txtelementname, string txtAttribute)
        {
            string actualvalue = linkAboutUs.GetAttribute(txtAttribute);

            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Abouts Us link Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Abouts Us link  Verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Abouts Us link. Error Code : ", e);
            }
        }

        // Verify the Annoucement Link at the bottom bar menu
        public void verifylinkAnnoucement(string txtelementname, string txtAttribute)
        {
            string actualvalue = linkAnnoucement.GetAttribute(txtAttribute);

            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Annoucement link Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Annoucement link  Verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Annoucement link. Error Code : ", e);
            }
        }

        // Verify the My Account label at bottom at the bottom bar menu
        public void verifylblMyAcc(string txtelementname, string txtAttribute)
        {
            //string actualvalue = lblMyAcc.GetAttribute(txtAttribute);
            string actualvalue = lblMyAcc.Text;

            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Bottom Bar My Account Label Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Bottom Bar My Account Label Verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Bottom Bar My Account Label. Error Code : ", e);
            }
        }

        // Verify the Customer Info Link at bottom at the bottom bar menu
        public void verifylinkCustomerInfo(string txtelementname, string txtAttribute)
        {
            string actualvalue = linkCustomerInfo.GetAttribute(txtAttribute);

            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Customer Info Link Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Customer Info Link Verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Customer Info Link. Error Code : ", e);
            }
        }

        // Verify the Purchase Flow Link at the bottom bar menu
        public void verifylinkPurchaseFlow(string txtelementname, string txtAttribute)
        {
            string actualvalue = linkPurchaseFlow.GetAttribute(txtAttribute);

            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Purchase Flow link Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Purchase Flow link  Verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Purchase Flow link. Error Code : ", e);
            }
        }

        // Verify the Return Link at the bottom bar menu
        public void verifylinkReturn(string txtelementname, string txtAttribute)
        {
            string actualvalue = linkReturn.GetAttribute(txtAttribute);

            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Return link Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Return link Verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Return link. Error Code : ", e);
            }
        }

        public void verifylinkVendorReg(string txtelementname, string txtAttribute)
        {
            string actualvalue = linkFAQ.GetAttribute(txtAttribute);

            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Vendor Registration link Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Vendor Registration link Verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Vendor Registration link. Error Code : ", e);
            }
        }

        // Verify the FAQ Link at the bottom bar menu
        public void verifylinkFAQ(string txtelementname, string txtAttribute)
        {
            string actualvalue = linkFAQ.GetAttribute(txtAttribute);

            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "FAQ link Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "FAQ link Verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify FAQ link. Error Code : ", e);
            }
        }

        // Verify the Contact Us Info at bottom at the bottom bar menu
        public void verifylblContactUs(string txtelementname, string txtAttribute)
        {
            // string actualvalue = lblContactUs.GetAttribute(txtAttribute);

            string actualvalue = lblContactUs.Text;

            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Contact Us Label Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Contact Us Label Verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Contact Us Label. Error Code : ", e);
            }
        }

        // Verify the Email Address info at bottom at the bottom bar menu
        public void verifylblEmail(string txtelementname, string txtAttribute)
        {
            string actualvalue = lblEmail.Text;

            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Email Address Info Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Email Address Info Verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Email Address Info. Error Code : ", e);
            }
        }

        // Verify the Footer Disclaim info at bottom at the bottom bar menu
        public void verifylblDisclaim(string txtelementname, string txtAttribute)
        {         
            string actualvalue = lblDisclaim.Text;

            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Footer Disclaim Info Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Footer Disclaim Info Verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Footer Disclaim Info. Error Code : ", e);
            }
        }

        // Verify for the Title for each link page of About Us, Annoucement, Privacy Policy, Term & Condition, Purchase Flow, Return, Refund & FAQ
        public void verifyLinkPageTitle(string txtelementname, string txtAttribute)
        {
            string actualvalue = txtPhTitle.GetAttribute(txtAttribute);

            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Link Page Title Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Link Page Title Verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Link Page Title. Error Code : ", e);
            }
        }

        // Verify the Purchase flow image 
        public void verifypurchaseflowimg(string txtelementname, string txtAttribute)
        {
            string actualvalue = imgpurchaseflow.GetAttribute(txtAttribute);

            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Purchase Flow Image Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Purchase Flow Image Verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Purchase Flow Image. Error Code : ", e);
            }
        }

        // Verify the Return flow image 
        public void verifyReturnflowimg(string txtelementname, string txtAttribute)
        {
            string actualvalue = imgreturnflow.GetAttribute(txtAttribute);

            try
            {
                Assert.IsTrue(actualvalue.Contains(txtelementname));
                ExtentManager.test.Log(Status.Pass, "Return Flow Image Verify Successfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
            }
            catch (Exception e)
            {
                ExtentManager.test.Log(Status.Fail, "Return Flow Image Verify UnSuccessfull.  Source : " + actualvalue + " Vs Verify Item :" + txtelementname);
                log.Fatal("Encounter error at verify Return Flow Image. Error Code : ", e);
            }
        }


        /// <summary>
        ///     Declare all the click function on the bottom bar
        /// </summary>

        public void ClicklinkAboutUs()
        {
            linkAboutUs.Clicks();
        }

        public void ClicklinkAnnoucement()
        {
            linkAnnoucement.Clicks();
        }

        public void ClicklinkPurchaseFlow()
        {
            linkPurchaseFlow.Clicks();
        }

        public void ClicklinkReturn()
        {
            linkReturn.Clicks();
        }

        public void ClicklinkFAQ()
        {
            linkFAQ.Clicks();
        }

        public void ClicklinkCustomerInfo()
        {
            linkCustomerInfo.Clicks();
        }

        public void ClickVendorRegistration()
        {
            linkVendorRegistor.Click();
        }
    }
}
