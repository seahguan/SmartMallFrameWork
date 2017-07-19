using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace SmartMallFramework
{
    class ShippingAddressPageObjects
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ShippingAddressPageObjects()
        {
            PageFactory.InitElements(Browser.driver, this);
        }


        [FindsBy(How = How.CssSelector, Using = ".address-box")]
        public IList<IWebElement> ArrMainAddress { get; set; }

        [FindsBy(How = How.Id, Using = "NewAddress_FirstName")]
        public IWebElement txtNewAddr_FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "NewAddress_LastName")]
        public IWebElement txtNewAddr_LastName { get; set; }

        [FindsBy(How = How.Id, Using = "NewAddress_Email")]
        public IWebElement txtNewAddress_Email { get; set; }

        [FindsBy(How = How.Id, Using = "NewAddress_CountryId")]
        public IWebElement ddlNewAddress_CountryId { get; set; }

        [FindsBy(How = How.Id, Using = "NewAddress_StateProvinceId")]
        public IWebElement ddlNewAddress_StateProvinceId { get; set; }

        [FindsBy(How = How.Id, Using = "NewAddress_City")]
        public IWebElement txtNewAddress_City { get; set; }

        [FindsBy(How = How.Id, Using = "NewAddress_Address1")]
        public IWebElement txtNewAddress_Address1 { get; set; }

        [FindsBy(How = How.Id, Using = "NewAddress_ZipPostalCode")]
        public IWebElement txtNewAddress_ZipPostalCode { get; set; }

        [FindsBy(How = How.Id, Using = "NewAddress_PhoneNumber")]
        public IWebElement txtNewAddress_PhoneNumber { get; set; }


        /// <summary>
        /// TO select the shipping address
        /// </summary>
        /// <param name="txtAddrName"></param>
        public void SelShippingAddress(string txtAddrName)
        {
            try
            {
                IList<IWebElement> ListofAddr = ArrMainAddress;

                string txtListofAddrTitle = "";
                
                foreach (IWebElement element in ListofAddr)
                {

                    IWebElement ListofAddrTitle = element.FindElement(By.CssSelector(".name"));
                    IWebElement SelShippingaddrBtn = element.FindElement(By.XPath("//*[@class='button-1 select-shipping-address-button']"));
                    txtListofAddrTitle = ListofAddrTitle.Text;

                    if (txtListofAddrTitle == null || txtListofAddrTitle =="")
                        continue;

                    if (txtListofAddrTitle.Contains(txtAddrName))
                    {
                        SelShippingaddrBtn.Click();
                        break;
                    }                
                }
            }
            catch (Exception e)
            {
                log.Fatal("FAIL : Encounter error at Select Shipping Address. Err Msg : ", e);
            }
        }

        /// <summary>
        /// create a new shipping addres for by provigind the following info.
        /// string txtFirstName, string txtLastName, string txtEmail, string txtCountry, string txtStateProvince,
        /// string txtCity, string txtAddress, string txtZipPostalCode, string txtPhoneNo
        /// </summary>
        /// <param name="txtFirstName"></param>
        /// <param name="txtLastName"></param>
        /// <param name="txtEmail"></param>
        /// <param name="txtCountry"></param>
        /// <param name="txtStateProvince"></param>
        /// <param name="txtCity"></param>
        /// <param name="txtAddress"></param>
        /// <param name="txtZipPostalCode"></param>
        /// <param name="txtPhoneNo"></param>
        public void CreateNewShippingAddr(string txtFirstName, string txtLastName, string txtEmail, string txtCountry, string txtStateProvince,
                                          string txtCity, string txtAddress, string txtZipPostalCode, string txtPhoneNo)
        {
            try
            {
                txtNewAddr_FirstName.SendKeys(txtFirstName);
                txtNewAddr_LastName.SendKeys(txtLastName);
                txtNewAddress_Email.SendKeys(txtEmail);

                SelectElement SelCountry = new SelectElement(ddlNewAddress_CountryId);
                SelCountry.SelectByText(txtCountry);

                SelectElement SelStateProvince = new SelectElement(ddlNewAddress_StateProvinceId);
                SelStateProvince.SelectByText(txtStateProvince);

                txtNewAddress_City.SendKeys(txtCity);
                txtNewAddress_Address1.SendKeys(txtAddress);
                txtNewAddress_ZipPostalCode.SendKeys(txtZipPostalCode);
                txtNewAddress_PhoneNumber.SendKeys(txtPhoneNo);
            }
            catch (Exception e)
            {
                log.Fatal("FAIL : Encounter error at Select Shipping Address - Add New Shipping Address. Err Msg : ", e);
            }
        }
    }
}
