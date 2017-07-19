using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SmartMallFramework.SmartMallPagesObjects
{
    class VendorRegistration
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public VendorRegistration()
        {
            PageFactory.InitElements(Browser.driver, this);
        }

        [FindsBy(How = How.Id, Using = "CompanyName")]
        public IWebElement txtCompanyName { get; set; }

        [FindsBy(How = How.Id, Using = "VendorRepresentation")]
        public IWebElement txtVendorRepresentation { get; set; }

        [FindsBy(How = How.Id, Using = "CompanyAdress")]
        public IWebElement txtCompanyAdress { get; set; }

        [FindsBy(How = How.Id, Using = "PaymentEmail")]
        public IWebElement txtPaymentEmail { get; set; }

        [FindsBy(How = How.Id, Using = "CompanyEmail")]
        public IWebElement txtCompanyEmail { get; set; }

        [FindsBy(How = How.Id, Using = "CompanyPhone")]
        public IWebElement txtCompanyPhone { get; set; }

        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement txtUsername { get; set; }

        [FindsBy(How = How.Id, Using = "check-availability-button")]
        public IWebElement btncheckAvail { get; set; }

        [FindsBy(How = How.Name, Using = "SelectedVendorCategoryIds")]
        public IList<IWebElement> ChkBoxSelectedVendorCategoryIds { get; set; }

        [FindsBy(How = How.Id, Using = "register-button")]
        public IWebElement btnRegister { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='input']")]
        public IList<IWebElement> ListofUploadBtn { get; set; }

        [FindsBy(How = How.Id, Using = "username-availabilty")]
        public IWebElement txtUserNameAvail { get; set; }

        /// <summary>
        /// To register a new vendor
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <param name="VendorRepresentation"></param>
        /// <param name="CompanyAddr"></param>
        /// <param name="PaymentEmail"></param>
        /// <param name="CompanyEmail"></param>
        /// <param name="CompanyPhoneNo"></param>
        /// <param name="Username"></param>
        /// <param name="CategoryName"></param>
        public void ResigerNewVendor(string CompanyName, string VendorRepresentation, string CompanyAddr, string PaymentEmail, string CompanyEmail,
                                     string CompanyPhoneNo, string Username, string CategoryName)
        {
            try
            {
                txtCompanyName.SendKeys(CompanyName);
                txtVendorRepresentation.SendKeys(VendorRepresentation);
                txtCompanyAdress.SendKeys(CompanyAddr);
                txtPaymentEmail.SendKeys(PaymentEmail);
                txtCompanyEmail.SendKeys(CompanyEmail);
                txtCompanyPhone.SendKeys(CompanyPhoneNo);
                txtUsername.SendKeys(Username);

                btncheckAvail.Click();
                string txtstatus = txtUserNameAvail.Text;

                bool statusind = false;

                if (txtstatus == "Username available")
                {
                    statusind = true;
                }
                else
                {
                    int i = 0;

                    while (txtstatus == "Username available")
                    {
                        Username = Username + i.ToString();
                        txtUsername.SendKeys(Username);
                        btncheckAvail.Click();
                        txtstatus = txtUserNameAvail.Text;
                        i = i++;
                    }
                    statusind = true;
                }

                if (statusind == true)
                {

                    Selcategory(CategoryName);

                    UploadAllFile();

                    btnRegister.Clicks();
                }
            }
            catch (Exception e)
            {
                log.Fatal("FAIL : Encounter error at set default Address. Err Msg : ", e);
            }
        }

        /// <summary>
        /// Select the a sub category for the vendor with the available option in the screen
        /// by providing the category name.
        /// </summary>
        /// <param name="CatName"></param>
        public void Selcategory(string CatName)
        {
            IList<IWebElement> ListofCategory = ChkBoxSelectedVendorCategoryIds;

            string txtListofCategory = "";

            foreach (IWebElement element in ListofCategory)
            {
                txtListofCategory = element.Text;

                if (txtListofCategory == null)
                    continue;

                if (txtListofCategory.Contains(CatName))
                {
                    element.Click();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void UploadAllFile()
        {
            IList<IWebElement> ListofUploadCat = ListofUploadBtn;

            string txtUploadBtnName = "";

            foreach (IWebElement element in ListofUploadCat)
            {
                txtUploadBtnName = element.Text;

                //name = "qqfile"

                //if (txtListofCategory == null)
                //    continue;

                //if (txtListofCategory.Contains(CatName))
                //{
                //    element.Click();
                //}
            }
        }
    }
}
