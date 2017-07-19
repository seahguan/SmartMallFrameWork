using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace SmartMallFramework
{
    class ShoppingCartPageObjects
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ShoppingCartPageObjects()
        {
            PageFactory.InitElements(Browser.driver, this);
        }

        // Continue button
        [FindsBy(How = How.Id, Using = "checkout")]
        public IWebElement btnCheckOut { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cart-item-row")]
        public IList<IWebElement> ArrMainItemList { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".k-icon.k-i-arrow-n")]
        public IWebElement IncreateQty { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".k-icon.k-i-arrow-s")]
        public IWebElement DecreaseQty { get; set; }

        /// <summary>
        /// Click on the cehck out button on the Shopping cart page
        /// </summary>
        public void ClickContinuebtn()
        {
            btnCheckOut.Clicks();
        }

        /// <summary>
        /// Edit the change the quantity of the item in Shopping cart by provide the item in the shopping cart and the quantity to be change.
        /// </summary>
        /// <param txtProductName=Item Name></param>
        /// <param NewQty=New Quantity No></param>
        public void EditShoppingItemQty(string txtProductName, string NewQty)
        {
            try
            {
                IList<IWebElement> ListofShoppingCartItem = ArrMainItemList;

                string txtListofProductName = "";
                int i = 0;

                foreach (IWebElement element in ListofShoppingCartItem)
                {

                    IList<IWebElement> ListofProductTitle = element.FindElements(By.CssSelector(".product"));
                    IWebElement SelShippingaddrBtn = element.FindElement(By.XPath("//*[@class='k-formatted-value qty-input k-input']"));
                    txtListofProductName = ListofProductTitle[i].Text;

                    if (txtListofProductName == null)
                        continue;

                    if (txtListofProductName.Contains(txtProductName))
                    {
                        SelShippingaddrBtn.SendKeys(NewQty);
                    }

                    i = i++;
                }
            }
            catch (Exception e)
            {
                log.Fatal("FAIL : Encounter error at Shopping Cart - Edit Qty Value. Err Msg : ", e);
            }
        }

        /// <summary>
        /// Increase the product quantity by click on the increase button
        /// </summary>
        /// <param txtProductName=Item Name></param>
        public void IncreaseProductQty(string txtProductName)
        {
            try
            {
                IList<IWebElement> ListofShoppingCartItem = ArrMainItemList;

                string txtListofProductName = "";
                int i = 0;

                foreach (IWebElement element in ListofShoppingCartItem)
                {
                    IList<IWebElement> ListofProductTitle = element.FindElements(By.CssSelector(".product"));
                    IWebElement IncreaseQtyBy1 = element.FindElement(By.XPath("//*[@class='k-icon k-i-arrow-n']"));
                    txtListofProductName = ListofProductTitle[i].Text;

                    if (txtListofProductName == null)
                        continue;

                    if (txtListofProductName.Contains(txtProductName))
                    {
                        IncreaseQtyBy1.Click();
                    }

                    i = i++;
                }
            }
            catch (Exception e)
            {
                log.Fatal("FAIL : Encounter error at Shopping Cart - Increase Qty. Err Msg : ", e);
            }
        }

        /// <summary>
        /// Decrease the product quantity by click on the Decrease button
        /// </summary>
        /// <param txtProductName=Item Name></param>
        public void DecreaseProductQty(string txtProductName)
        {
            try
            {
                IList<IWebElement> ListofShoppingCartItem = ArrMainItemList;

                string txtListofProductName = "";
                int i = 0;

                foreach (IWebElement element in ListofShoppingCartItem)
                {
                    IList<IWebElement> ListofProductTitle = element.FindElements(By.CssSelector(".product"));
                    IWebElement DecreaseQtyBy1 = element.FindElement(By.XPath("//*[@class='k-icon k-i-arrow-s']"));
                    txtListofProductName = ListofProductTitle[i].Text;

                    if (txtListofProductName == null)
                        continue;

                    if (txtListofProductName.Contains(txtProductName))
                    {
                        DecreaseQtyBy1.Click();
                    }

                    i = i++;
                }
            }
            catch (Exception e)
            {
                log.Fatal("FAIL : Encounter error at Shopping Cart - Decrease Qty. Err Msg : ", e);
            }
        }

        /// <summary>
        /// To remove the item from the shopping cart.
        /// </summary>
        /// <param txtProductName=item name to be remove from the cart.></param>
        public void RemoveItem(string txtProductName)
        {
            try
            {
                IList<IWebElement> ListofShoppingCartItem = ArrMainItemList;

                string txtListofProductName = "";
                int i = 0;

                foreach (IWebElement element in ListofShoppingCartItem)
                {
                    IList<IWebElement> ListofProductTitle = element.FindElements(By.CssSelector(".product"));
                    IWebElement RemoveLink = element.FindElement(By.Name("updatecart"));
                    txtListofProductName = ListofProductTitle[i].Text;

                    if (txtListofProductName == null)
                        continue;

                    if (txtListofProductName.Contains(txtProductName))
                    {
                        RemoveLink.Click();
                    }

                    i = i++;
                }
            }
            catch (Exception e)
            {
                log.Fatal("FAIL : Encounter error at Remove item from shopping cart. Err Msg : ", e);
            }
        }
    }
}
