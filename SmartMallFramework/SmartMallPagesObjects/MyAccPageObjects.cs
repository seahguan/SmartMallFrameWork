using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using AventStack.ExtentReports;

namespace SmartMallFramework
{
    class MyAccPageObjects
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MyAccPageObjects()
        {
            PageFactory.InitElements(Browser.driver, this);
        }


        /// <summary>
        /// Below with this patter [FindsBy ....] is to decalre all the object element to be used 
        /// in the screen which using the Page Object Method (POM).
        /// </summary>
        /// 

        //Customer Info Tab
        [FindsBy(How = How.CssSelector, Using = ".customer-info")]
        public IWebElement tabCustomerInfo { get; set; }

        [FindsBy(How = How.Id, Using = "FirstName")]
        public IWebElement txtFirstName { get; set; }

        [FindsBy(How = How.Id, Using = "LastName")]
        public IWebElement txtLastName { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement txtEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.master-wrapper-content > div.master-column-wrapper > div.center-2 > div > div.page-body > form > div:nth-child(2) > div.form-fields > div:nth-child(4) > label:nth-child(2)")]
        public IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "CountryId")]
        public IWebElement ddlCountryId { get; set; }

        [FindsBy(How = How.Id, Using = "Phone")]
        public IWebElement txtPhone { get; set; }

        [FindsBy(How = How.Name, Using = "save-info-button")]
        public IWebElement btnCustInfoSave { get; set; }

        // Address Tab Objects
        [FindsBy(How = How.CssSelector, Using = ".customer-addresses")]
        public IWebElement tabAddress { get; set; }

        [FindsBy(How = How.Id, Using = "Address_FirstName")]
        public IWebElement txtAddrFirstName { get; set; }

        [FindsBy(How = How.Id, Using = "Address_LastName")]
        public IWebElement txtAddrLastName { get; set; }

        [FindsBy(How = How.Id, Using = "Address_Email")]
        public IWebElement txtAddrEmail { get; set; }

        [FindsBy(How = How.Id, Using = "Address_CountryId")]
        public IWebElement ddlAddrCountryId { get; set; }

        [FindsBy(How = How.Id, Using = "Address_StateProvinceId")]
        public IWebElement ddlAddress_StateProvinceId { get; set; }

        [FindsBy(How = How.Id, Using = "Address_City")]
        public IWebElement txtAddressCity { get; set; }

        [FindsBy(How = How.Id, Using = "Address_Address1")]
        public IWebElement txtAddressAddress1 { get; set; }

        [FindsBy(How = How.Id, Using = "Address_ZipPostalCode")]
        public IWebElement txtAddressZipPostalCode { get; set; }

        [FindsBy(How = How.Id, Using = "Address_PhoneNumber")]
        public IWebElement txtAddressPhoneNumber { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.master-wrapper-content > div.master-column-wrapper > div.center-2 > form > div > div.page-body > div.buttons > input")]
        public IWebElement btnAddressSave { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.master-wrapper-content > div.master-column-wrapper > div.center-2 > div > div.page-body > div.add-button > input")]
        public IWebElement btnAddNewAddr { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='section address-item']")]
        public IList<IWebElement> MainAddreList { get; set; }

        [FindsBy(How = How.XPath, Using = "//*div[@class='title']")]
        public IList<IWebElement> ArrListAddress_list { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.button-2.edit-address-button")]
        public IList<IWebElement> ArrListAddr_editbtn { get; set; }

        // Orders Tab Page Objects
        [FindsBy(How = How.CssSelector, Using = ".customer-orders")]
        public IWebElement tabOrders { get; set; }

        [FindsBy(How = How.Id, Using = "OrderShippingStatusId")]
        public IWebElement ddlOrderShippingStatusId { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".title-order")]
        public IList<IWebElement> ListOrdersList { get; set; }
        
        // Cancel / Return Tab
        [FindsBy(How = How.CssSelector, Using = ".return-requests")]
        public IWebElement tabCXReturn { get; set; }

        [FindsBy(How = How.Id, Using = "ActionId")]
        public IWebElement ddlActionStatus { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".section.request-item.title")]
        public IList<IWebElement> ListCXReturnList { get; set; }

        //Change Password Tab Page Objects
        [FindsBy(How = How.CssSelector, Using = ".change-password")]
        public IWebElement tabChangePassword { get; set; }

        [FindsBy(How = How.Id, Using = "OldPassword")]
        public IWebElement txtOldPassword { get; set; }

        [FindsBy(How = How.Id, Using = "NewPassword")]
        public IWebElement txtNewPassword { get; set; }

        [FindsBy(How = How.Id, Using = "ConfirmNewPassword")]
        public IWebElement txtConfirmNewPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='buttons'][@class='button-1 change-password-button']")]
        public IWebElement btnChangePassword { get; set; }

        // Transaction history tab Page Objects
        [FindsBy(How = How.CssSelector, Using = ".forum-subscriptions")]
        public IWebElement tabTransactionHist { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#rpRecord.date.sorting_desc")]
        public IWebElement DateSortingDesc { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#rpRecord.date.sorting_asc")]
        public IWebElement DateSortingAsc { get; set; }

        [FindsBy(How = How.CssSelector, Using = "rpRecord_filter")]
        public IWebElement txtFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "rpRecord_previous")]
        public IWebElement PrevRecBtn { get; set; }

        [FindsBy(How = How.Id, Using = "rpRecord_next")]
        public IWebElement NextRecBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#rpRecord_paginate.paginate_button.current")]
        public IWebElement CurrPaginateBtn { get; set; }

        [FindsBy(How = How.Id, Using = "goToTop")]
        public IWebElement GoToTopBtn { get; set; }

        /// <summary>
        ///  To call the Customer Information Tab in the My Account Page
        /// </summary>        
        public void clicktabCustomerInfo()
        {
            tabCustomerInfo.Clicks();
        }

        /// <summary>
        ///     upadte the Customer information only restrict to FirstName; Last name & Country
        /// </summary>
        /// <param newFirstname=field that store the First name to be update.></param>
        /// <param newLastName=field that store the Last name to be update.></param>
        /// <param newCountry=field that store the country ID to be update.></param>
        public void updateCustInfo(string newFirstname, string newLastName, string newCountry)
        {
            try
            {
                txtFirstName.SendKeys(newFirstname);
                txtLastName.SendKeys(newLastName);
                SelectElement UpdateCoutry = new SelectElement(ddlCountryId);
                UpdateCoutry.SelectByText(newCountry);
                btnCustInfoSave.Click();
            }
            catch (Exception e)
            {
                log.Fatal("Fail. Encounter Unexpected error at the updating Customer Personal info. Err Code : ", e);
            }
        }

        /// <summary>
        ///     To verify the an element by providing the name and the attribute.
        ///     element to verify is FirstName 
        /// </summary>
        /// <param txtelementname=Element Name in Text to verify></param>
        /// <param txtAttribute=type of attribute (e.g. "href", "test" & etc></param>
        public void verifyMyAccFirstName(string txtelementname, string txtAttribute)
        {
            string actualvalue = txtFirstName.GetAttribute(txtAttribute);

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
        ///     To verify the an element by providing the name and the attribute.
        ///     element to verify is Lastname
        /// </summary>
        /// <param txtelementname=Element Name in Text to verify></param>
        /// <param txtAttribute=type of attribute (e.g. "href", "test" & etc></param>
        public void verifyMyAccLastName(string txtelementname, string txtAttribute)
        {
            string actualvalue = txtLastName.GetAttribute(txtAttribute);

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
        ///     To verify the an element by providing the name and the attribute.
        ///     element to verify is Email.
        /// </summary>
        /// <param txtelementname=Element Name in Text to verify></param>
        /// <param txtAttribute=type of attribute (e.g. "href", "test" & etc)></param>
        public void verifyMyAccEmail(string txtelementname, string txtAttribute)
        {
            string actualvalue = txtEmail.GetAttribute(txtAttribute);

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
        ///     To verify the an element by providing the name and the attribute.
        ///     element to verify is Country Drop Down Listing.
        /// </summary>
        /// <param txtelementname=Element Name in Text to verify></param>
        /// <param txtAttribute=type of attribute (e.g. "href", "test" & etc></param>
        public void verifyCountry(string txtelementname, string txtAttribute)
        {
            string actualvalue = ddlAddrCountryId.GetAttribute(txtAttribute);

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
        ///    send the value into the FirstName filed.
        /// </summary>
        /// <param firstname=value to be send to.></param>
        public void FillFirstName(string firstname)
        {
            txtFirstName.EnterText(firstname);
        }

        /// <summary>
        ///    send the value into the lastname filed.
        /// </summary>
        /// <param lastname=value to be send to.></param>
        public void FillLastName(string lastname)
        {
            txtLastName.EnterText(lastname);
        }

        /// <summary>
        ///     To verify the email address element exist in the screen or not.
        ///     ** Will be to change the checing by using 1 verification function.
        /// </summary>
        /// <param txtcssname=>cssname of the element.</param>
        /// <param txtelementname=> Element name to be verified.</param>
        /// <param txtsourcetype=> source attribute</param>
        
        public void verifyEmailaddr(string txtcssname, string txtelementname, string txtsourcetype)
        {
            txtEmail.HasElementByCssGetAlt(txtcssname, txtelementname, txtsourcetype);
        }

        /// <summary>
        ///     To verify the User Name element exist in the screen or not.
        ///     ** Will be to change the checing by using 1 verification function.
        /// </summary>
        /// <param txtcssname=>cssname of the element.</param>
        /// <param txtelementname=> Element name to be verified.</param>
        /// <param txtsourcetype=> source attribute</param>
        public void verifyUserName(string txtcssname, string txtelementname, string txtsourcetype)
        {
            txtUserName.HasElementByCssGetAlt(txtcssname, txtelementname, txtsourcetype);
        }

        /// <summary>
        /// upadate country which is a drop down listing field
        /// </summary>
        /// <param txtddlCountryId=Country ID to be change to></param>
        public void UpdMyAccCountryId(string txtddlCountryId)
        {
            SelectElement element = new SelectElement(ddlAddrCountryId);
            element.SelectByText(txtddlCountryId);
            btnCustInfoSave.Clicks();
        }

        /// <summary>
        ///  Verify the phone no
        /// </summary>
        /// <param txtcssname= css value></param>
        /// <param txtelementname= Phone Element name ></param>
        public void verifytxtPhone(string txtcssname, string txtelementname)
        {
            txtPhone.HasElementById(txtcssname, txtelementname);
        }

        /// <summary>
        /// Verify the User Name field
        /// </summary>
        /// <param txtcssname= css value for the user name field></param>
        /// <param txtelementname= element name to be verify ></param>
        public void verifyUserName(string txtcssname, string txtelementname)
        {
            txtUserName.HasElementById(txtcssname, txtelementname);
        }

        /// <summary>
        /// click on the address tab in the My Account Page.
        /// </summary>
        public void clicktabAddress()
        {
            tabAddress.Click();
        }

        /// <summary>
        ///  set the selected address to be come default address.
        /// </summary>
        /// <param txtaddresstitle=Address title name to be set as default address></param>
        public void SetDefaultAddr(string txtaddresstitle)
        {
            try
            {
                IList<IWebElement> ListofAddr = MainAddreList;

                //IWebElement abc = Browser.driver.FindElement(By.Id("Username"));

                string txtListofAddrTitle = "";
                int i = 0;

                foreach (IWebElement element in ListofAddr)
                {

                    IList<IWebElement> ListofAddrTitle = element.FindElements(By.CssSelector(".title"));
                    IList<IWebElement> ListofDefBtn = element.FindElements(By.CssSelector("input.set-default-address-button"));

                    txtListofAddrTitle = ListofAddrTitle[i].Text;

                    if (txtListofAddrTitle == null)
                        continue;

                    if (txtListofAddrTitle.Contains(txtaddresstitle))
                    {
                        ListofDefBtn[i].Click();
                    }

                    i = i++;
                }
            }
            catch (Exception e)
            {
                log.Fatal("FAIL : Encounter error at set default Address. Err Msg : ", e);
            }
        }

        /// <summary>
        ///  update the selected address by providing the following information :
        ///  string txtaddresstitle, string AddrFirstName, string AddrLastName, string AddrEmail, string AddrCountry, string AddrStateProvince, string AddressCity,
        ///  string AddressAddress1, string AddressZipPostalCode, string AddressPhoneNumber
        /// </summary>
        /// <param txtaddresstitle= address title to be selected to update></param>
        /// <param AddrFirstName= firtname to be change to ></param>
        /// <param AddrLastName=Last Name to be change to ></param>
        /// <param AddrEmail=Email address to be change to ></param>
        /// <param AddrCountry=country name to be chande to ></param>
        /// <param AddrStateProvince=State Province name to be change to></param>
        /// <param AddressCity=Address city to be change to ></param>
        /// <param AddressAddress1=Address 1 to be change to ></param>
        /// <param AddressZipPostalCode=Zip Code to be change to></param>
        /// <param AddressPhoneNumber=Phone number to be change to></param>
        public void EditAddr(string txtaddresstitle, string AddrFirstName, string AddrLastName, string AddrEmail, string AddrCountry, string AddrStateProvince, string AddressCity,
                             string AddressAddress1, string AddressZipPostalCode, string AddressPhoneNumber)
        {
            try
            {
                IList<IWebElement> ListofAddr = MainAddreList;

                string txtListofAddrTitle = "";
                int i = 0;

                foreach (IWebElement element in ListofAddr)
                {
                    IList<IWebElement> ListofAddrTitle = element.FindElements(By.CssSelector(".title"));
                    IList<IWebElement> ListofEditBtn = element.FindElements(By.CssSelector("input.button-2.edit-address-button"));
                    
                    txtListofAddrTitle = ListofAddrTitle[i].Text;

                    if (txtListofAddrTitle == null)
                        continue;

                    if (txtListofAddrTitle.Equals(txtaddresstitle))
                    {
                        ListofEditBtn[i].Click();

                        // here will call this function to clear all the fields in the address before update the latest.
                        ClearAddrFields();

                        txtAddrFirstName.SendKeys(AddrFirstName);
                        txtAddrLastName.SendKeys(AddrLastName);
                        txtAddrEmail.SendKeys(AddrEmail);

                        SelectElement SelAddrCountry = new SelectElement(ddlAddrCountryId);
                        SelAddrCountry.SelectByText(AddrCountry);

                        SelectElement SelStateProvinceId = new SelectElement(ddlAddress_StateProvinceId);
                        SelStateProvinceId.SelectByText(AddrStateProvince);
                                                
                        txtAddressCity.SendKeys(AddressCity);
                        txtAddressAddress1.SendKeys(AddressAddress1);
                        txtAddressZipPostalCode.SendKeys(AddressZipPostalCode);
                        txtAddressPhoneNumber.SendKeys(AddressPhoneNumber);

                        btnAddressSave.Click();
                    }
                }
            }
            catch (Exception e)
            {
                log.Fatal("FAIL : Encounter error in updating the Customer Address. Err Msg : ", e);
            }
        }

        /// <summary>
        ///  Use to clear all the address field before updated.
        /// </summary>
        public void ClearAddrFields()
        {
            txtAddrFirstName.Clear();
            txtAddrLastName.Clear();
            txtAddrEmail.Clear();            
            txtAddressCity.Clear();
            txtAddressAddress1.Clear();
            txtAddressZipPostalCode.Clear();
            txtAddressPhoneNumber.Clear();
        }

        /// <summary>
        ///  to delete the selected address
        /// </summary>
        /// <param txtaddresstitle=Address title to be deleted.></param>
        public void DelAddr(string txtaddresstitle)
        {
            try
            {
                IList<IWebElement> ListofAddr = MainAddreList;

                string txtListofAddrTitle = "";
                int i = 0;

                foreach (IWebElement element in ListofAddr)
                {

                    IList<IWebElement> ListofAddrTitle = element.FindElements(By.CssSelector(".title"));
                    IList<IWebElement> ListofDelBtn = element.FindElements(By.CssSelector("input.button-2.delete-address-button"));

                    txtListofAddrTitle = ListofAddrTitle[i].Text;

                    if (txtListofAddrTitle == null)
                        continue;

                    if (txtListofAddrTitle.Equals(txtaddresstitle))
                    {
                        ListofDelBtn[i].Click();
                        
                        Browser.driver.SwitchTo().Alert().Accept();
                    }

                    i = i++;
                }
            }
            catch (Exception e)
            {
                log.Fatal("FAIL : Encounter error at delete Address. Err Msg : ", e);
            }
        }

        /// <summary>
        ///  To add new address 
        /// </summary>
        /// <param AddrFirstName= First Name for New Addresss ></param>
        /// <param AddrLastName=Last name for New Addresss ></param>
        /// <param AddrEmail= Email for New Address></param>
        /// <param AddrCountry= Country Name for the New Address></param>
        /// <param AddrStateProvince= State Province Name for the New Addresss ></param>
        /// <param AddressCity=City Name for the New Addresss ></param>
        /// <param AddressAddress1= Address 1 for the New Addresss ></param>
        /// <param AddressZipPostalCode=Postcode for the New Addresss ></param>
        /// <param AddressPhoneNumber=Phone Number for the New Addresss ></param>
        public void AddNewAddr(string AddrFirstName, string AddrLastName, string AddrEmail, string AddrCountry, string AddrStateProvince, string AddressCity,
                             string AddressAddress1, string AddressZipPostalCode, string AddressPhoneNumber)
        {
            try
            {
                btnAddNewAddr.Click();
                txtAddrFirstName.SendKeys(AddrFirstName);
                txtAddrLastName.SendKeys(AddrLastName);
                txtAddrEmail.SendKeys(AddrEmail);

                SelectElement SelAddrCountry = new SelectElement(ddlAddrCountryId);
                SelAddrCountry.SelectByText(AddrCountry);

                SelectElement SelStateProvinceID = new SelectElement(ddlAddress_StateProvinceId);
                SelStateProvinceID.SelectByText(AddrStateProvince);
                                
                txtAddressCity.SendKeys(AddressCity);
                txtAddressAddress1.SendKeys(AddressAddress1);
                txtAddressZipPostalCode.SendKeys(AddressZipPostalCode);
                txtAddressPhoneNumber.SendKeys(AddressPhoneNumber);

                btnAddressSave.Click();
            }
            catch (Exception e)
            {
                log.Fatal("Encounter Enexpected Error at add New Address. Err Code : ", e);
            }
        }

        
        /// <summary>
        /// click on the order Tab in the My Account Page
        /// </summary>
        public void clickOrdersTab()
        {
            tabOrders.Click();
        }

        /// <summary>
        /// Change the Shipping status
        /// </summary>
        /// <param txtShippingStatus= dropdown listing - All to left 3days or from left 3 days to All></param>
        public void SelShippingStatus(string txtShippingStatus)
        {
            try
            {
                SelectElement SelShippingStatus = new SelectElement(ddlOrderShippingStatusId);
                SelShippingStatus.SelectByText(txtShippingStatus);
            }
            catch (Exception e)
            {
                log.Fatal("Fail : Encounter error at Order Tab by change the Shipping status. Error : ", e);
            }
        }

        /// <summary>
        /// Click on the details of the selected order Id
        /// </summary>
        /// <param txtOrderid=Order id listed in the order tab page to be seleted></param>
        public void ClickOrdersDet(string txtOrderid)
        {
            try
            {
                IList<IWebElement> ListofOrderId = ListOrdersList;
                
                string txtListofOrderId = "";
                int i = 0;

                foreach (IWebElement element in ListofOrderId)
                {
                    txtListofOrderId = element.Text;
                    IWebElement detOrderlink = element.FindElement(By.PartialLinkText(txtOrderid));


                    if (txtListofOrderId == null)
                        continue;

                    if (txtListofOrderId.Equals(txtOrderid))
                    {                        
                        detOrderlink.Click();
                    }
                    
                    i = i++;
                }
            }
            catch (Exception e)
            {
                log.Fatal("Fail : Encounter error at Order Tab click orders id : " + txtOrderid + ". Error : ", e);
            }
        }

        
        /// <summary>
        /// Click on the CX Return Tab in the My Account Page
        /// </summary>
        public void clickCXReturnTab()
        {
            tabCXReturn.Click();
        }

        /// <summary>
        /// Select the Cancel / Return status = All / Cancel / Return 
        /// </summary>
        /// <param txtCXReturnStatus=></param>
        public void SelCXReturnStatus(string txtCXReturnStatus)
        {
            try
            {
                SelectElement SelCXReturnStatus = new SelectElement(ddlActionStatus);
                SelCXReturnStatus.SelectByText(txtCXReturnStatus);
            }
            catch (Exception e)
            {
                log.Fatal("Fail : Encounter error at Cancel/Return Tab by change the Cancl / Return  status. Error : ", e);
            }
        }

        /// <summary>
        ///  to verify the Cancel / Return ID appear in the Cancel / Return Tab
        /// </summary>
        /// <param txtCXReturnid= Cancel/Return ID to be verified></param>
        /// <param checkCXIDInd= return the result true = appear || false = not appear ></param>
        public void ClickCXReturnDet(string txtCXReturnid, ref bool checkCXIDInd)
        {
            try
            {
                IList<IWebElement> ListofCXReturnId = ListCXReturnList;
                                
                string txtListofCXReturnId = "";
                int i = 0;

                foreach (IWebElement element in ListofCXReturnId)
                {
                    txtListofCXReturnId = element.Text;
                    
                    if (txtListofCXReturnId == null)
                        continue;
                    try
                    {
                        Assert.IsTrue(txtListofCXReturnId.Contains(txtCXReturnid));
                        checkCXIDInd = true;
                    }
                    catch (Exception )
                    {
                        checkCXIDInd = false;
                    }

                    i = i++;
                }
            }
            catch (Exception e)
            {
                log.Fatal("Fail : Encounter error at Order Tab click orders id : " + txtCXReturnid + ". Error : ", e);
            }
        }

        /// <summary>
        /// click on the Change password tab in the transaction history web page.
        /// </summary>
        public void clickChgPasswdTab()
        {
            tabChangePassword.Click();
        }

        ///
        /// <summary>
        ///  To change the login password.
        /// </summary>
        /// <param txtOldPassdEnt=Provide the current password.></param>
        /// <param txtNewPasswd=Provide the password to be change to.></param>
        public void ChangePasswd(string txtOldPasswdEnt, string txtNewPasswd)
        {
            try
            {
                txtOldPassword.SendKeys(txtOldPasswdEnt);
                txtNewPassword.SendKeys(txtNewPasswd);
                txtConfirmNewPassword.SendKeys(txtNewPasswd);
                btnChangePassword.Click();
            }
            catch (Exception e)
            {
                log.Fatal("Fail : Encounter error at Cancel/Return Tab by change the Cancl / Return  status. Error : ", e);
            }
        }

        /// <summary>
        ///  To call the Transaction History Tab in the My Account Page
        /// </summary>
        /// 
        public void clickTrxHistTab()
        {
            tabTransactionHist.Click();
        }

        /// <summary>
        /// click on the Next page in the transaction history web page.
        /// </summary>
        public void ClickNextRev()
        {
            NextRecBtn.Click();
        }

        /// <summary>
        /// click on the previod page in the transaction history web page.
        /// </summary>
        public void ClickPrevRec()
        {
            PrevRecBtn.Click();
        }

        /// <summary>
        /// to filter the iterm by enter the text into the 
        /// </summary>
        /// <param txtfilterdet=Item to be filter in txt></param>
        public void Filter(string txtfilterdet)
        {
            txtFilter.SendKeys(txtfilterdet);
        }

        /// <summary>
        /// Click on the Go Back TO Top button
        /// </summary>
        public void clickGoToTop()
        {
            GoToTopBtn.Click();
        }
    }
}
