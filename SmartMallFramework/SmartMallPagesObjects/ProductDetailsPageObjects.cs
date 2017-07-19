using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace SmartMallFramework
{
    class ProductDetailsPageObjects
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ProductDetailsPageObjects()
        {
            PageFactory.InitElements(Browser.driver, this);
        }

        // here this method is to get the search like method
        [FindsBy(How = How.CssSelector, Using = "*[id^='add-to-cart-button-']")]
        public IWebElement btnAddCart { get; set; }

        [FindsBy(How = How.CssSelector, Using = "*[id^='addtocart_'][id$='_EnteredQuantity']")]
        public IWebElement txtQtyBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[starts-with(@id, 'add-to-wishlist-button')]")]
        public IWebElement btnWishListA { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[starts-with(@class, 'button-1 productAddedToCartWindowCheckout')]")]
        public IWebElement btnWishListB { get; set; }        

        [FindsBy(How = How.XPath, Using = "*[id^='product_attribute_input_'][name^='product_attribute_'][id^='product_attribute_']")]
        public IWebElement ddlBundle { get; set; }

        [FindsBy(How = How.XPath, Using = ("//ul[@class='option-list']/li"))]
        public IList<IWebElement> ShiptoRadioBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.continueShoppingLink")]
        public IWebElement cssbtnContinueShopping { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='continueShoppingLink']")]
        public IWebElement XPbtnContinueShopping { get; set; }
                
        [FindsBy(How = How.PartialLinkText, Using = "继续购物")]
        public IWebElement PLCNbtnContinueShopping2 { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Continue Shopping")]
        public IWebElement PLENbtnContinueShopping2 { get; set; }

        [FindsBy(How = How.TagName, Using = "继续购物")]
        public IWebElement TAGCNbtnContinueShopping3 { get; set; }

        [FindsBy(How = How.TagName, Using = "Continue Shopping")]
        public IWebElement TAGENbtnContinueShopping3 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='productAddedToCartWindowSummary'] [@class='button-1 productAddedToCartWindowCheckout']")]
        public IWebElement btnGoToCart1 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.button-1.productAddedToCartWindowCheckout")]
        public IWebElement btnGoToCart { get; set; }

        /// <summary>
        /// to declare all the function that going to be used in the product details pages
        /// </summary>
        public void ClickAddToCart()
        {
            btnAddCart.Click();
        }

        /// <summary>
        /// click go to cart option
        /// </summary>
        public void ClickGoTOCart()
        {
            btnGoToCart.Click();
        }

        /// <summary>
        /// click go to cart option
        /// </summary>
        public void ClickGoTOCartA()
        {
            btnGoToCart1.Click();
        }

        /// <summary>
        /// click on the wish List option
        /// </summary>
        public void ClickWishList()
        {
            btnWishListA.Click();
        }

        /// <summary>
        /// click on the wishlist button at the pop up screen
        /// </summary>
        public void ClickWishListB()
        {
            btnWishListB.Click();
        }

        /// <summary>
        /// change the quantity no in the qunatitiy fields
        /// </summary>
        /// <param NoofItem= Number of quantity change to ></param>
        public void EnterQtyBox(string NoofItem)
        {
            txtQtyBox.SendKeys(NoofItem);
        }

        /// <summary>
        /// Click on the continue shopping option using XPATH method
        /// </summary>
        public void ClickCtnShopping()
        {
            XPbtnContinueShopping.Click();
        }

        /// <summary>
        /// Click on the continue shopping option using CSS method
        /// </summary>
        public void CSSClickCtnShopping()
        {
            cssbtnContinueShopping.Click();
        }

        /// <summary>
        /// select the Ship to country option
        /// </summary>
        /// <param txtShiptoCountryName= Shipping country name to be select.></param>
        public void SelectShipTo(string txtShiptoCountryName)
        {
            try
            {
                IList<IWebElement> ListofShiptoCountry = ShiptoRadioBtn;
                
                string txtListofCountry = "";
                
                foreach (IWebElement element in ListofShiptoCountry)
                {

                    txtListofCountry = element.Text;

                    if (txtListofCountry == null || txtListofCountry == "")
                        continue;

                    if (txtListofCountry.Equals(txtShiptoCountryName))
                    {
                        element.Click();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                log.Fatal("FAIL : Encounter error at set default Address. Err Msg : ", e);
            }
        }

        /// <summary>
        /// select the bundle discount option
        /// </summary>
        /// <param txtBundleOption=Bundle option name to be selected></param>
        public void SelBundleDis(string txtBundleOption)
        {
            try
            {
                SelectElement SelBundleItem = new SelectElement(ddlBundle);
                SelBundleItem.SelectByText(txtBundleOption);
            }
            catch (Exception e)
            {
                log.Fatal("FAIL : Encounter error at set Select Bundle Discount Drop Down List. Err Msg : ", e);
            }
        }


    }

}
