using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SmartMallFramework
{
    class NewRegistrationObjects
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public NewRegistrationObjects()
        {
            // to initialize all the object in this login page
            PageFactory.InitElements(PropertiesCollections.driver, this);
        }


        [FindsBy(How = How.Id, Using = "FirstName")]
        public IWebElement txtFirstName { get; set; }

        [FindsBy(How = How.Id, Using = "LastName")]
        public IWebElement txtLastName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.inputs > #Email")]
        public IWebElement txtEmail { get; set; }

        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement txtUsername { get; set; }

        [FindsBy(How = How.Id, Using = "check-availability-button")]
        public IWebElement btncheckAvailability { get; set; }

        [FindsBy(How = How.Id, Using = "CountryId")]
        public IWebElement ddlCountryId { get; set; }

        [FindsBy(How = How.Id, Using = "Phone")]
        public IWebElement txtPhone { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        public IWebElement txtConfirmPassword { get; set; }

        [FindsBy(How = How.Name, Using = "register-button")]
        public IWebElement btnregister { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#username-availabilty")]
        public IWebElement txtusernameAvailabilty { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.master-wrapper-content > div.master-column-wrapper > div > div > div.page-body > div.buttons > input")]
        public IWebElement btnContinue { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page.mobile-sticky-logo > div.master-wrapper-content > div.master-column-wrapper > div > form:nth-child(2) > div > div.page-body > div.message-error > div")]
        public IWebElement txtValdationSummary { get; set; }




        public void FillUser(string firstname, string lastname, string email, string username, string country, string phoneno, string password, string confirmpassword)
        {
            txtFirstName.EnterText(firstname);
            txtLastName.EnterText(lastname);
            txtEmail.EnterText(email);
            txtUsername.EnterText(username);
            ddlCountryId.SelectDRopDown(country);
            txtPhone.EnterText(phoneno);
            txtPassword.EnterText(password);
            txtConfirmPassword.EnterText(confirmpassword);
            log.Info("successful fill up all the info in the fields and proceed to verify the username");
        }

        public void checkAvailability()
        {
            btncheckAvailability.Submit();

            string chkresult = txtusernameAvailabilty.GetText();
            try
            {
                if (chkresult == "Username available")
                {
                    btnregister.Submit();
                    log.Info("SUCCESSFULL : Verify the username successfull : Username is Available. ");
                }
                else if (chkresult == "Cannot start with 2 characters and 2 numbers")
                {
                    log.Info("SUCCESSFULL : New Register User Name - System able to detect the User name cannot start with 2 character and follow 2 numbers. ");

                    //to create a for loop to change the username by adding counter number infront of the username as to allow to continue for testing.

                    for (int counter = 0; counter < 999; counter++)
                    {
                        string txtCounter = counter.ToString().Trim();
                        string tmpUserName = txtCounter + txtUsername.Text;
                        txtUsername.EnterText(tmpUserName);
                        btncheckAvailability.Submit();
                        chkresult = txtusernameAvailabilty.GetText();

                        if (chkresult == "Username available")
                        {
                            clickContinuebtn();
                            break;
                        }
                    }
                }
                else if (chkresult == "Username not available")
                {
                    log.Info("SUCCESSFULL : New Register User Name - System able to detect the User name is been used.");

                    for (int counter = 0; counter < 999; counter++)
                    {
                        string txtCounter = counter.ToString().Trim();
                        string tmpUserName = txtCounter + txtUsername.Text;
                        txtUsername.EnterText(tmpUserName);
                        btncheckAvailability.Submit();
                        chkresult = txtusernameAvailabilty.GetText();

                        if (chkresult == "Username available")
                        {
                            clickContinuebtn();
                            break;
                        }

                    }
                }
            }
            catch (Exception e)
            {
                log.Fatal("FAIL : encounter error at verify the user name with error message ", e);
            }

        }

        public void SubmitRegister()
        {
            btnregister.Submit();
            string valmessage = txtValdationSummary.Text;
            if (valmessage == "The specified email already exists")
            {
                log.Error("Register Fail. Email Address Entered already Exits");
                ExtentManager.test.Log(AventStack.ExtentReports.Status.Info, "Registration Fail due to the Email register is already exits in database.");                
            }
            else
                log.Info("SUCCESSFULL : Verify the username successfull : Username is Available. ");
        }

        public void clickContinuebtn()
        {
            btnContinue.Submit();
            log.Info("SUCCESSFULL : Verify the username successfull : Username is Available. ");
        }
    }
}
