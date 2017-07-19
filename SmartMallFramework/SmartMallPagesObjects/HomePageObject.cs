using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace SmartMallFramework
{
    class HomePageObject
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public HomePageObject()
        {
            // to initialize all the object in this Page
            PageFactory.InitElements(Browser.driver, this);
        }

        // Highlights item
        [FindsBy(How = How.XPath, Using = "//*[@id='HighLights']//*[@class='row']")]
        public IList<IWebElement> ListLinkHighlightitems { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='product-item']")]
        public IList<IWebElement> ListfeaturesProductItem { get; set; }


        /// <summary>
        /// to select the highlight section item in the Smart Mall Home Page 
        /// </summary>
        /// <param txtHighLightItem=Item name to be select.></param>
        public void selhighlightsproduct(ref string txtHighLightItem)
        {
            try
            {
                IList<IWebElement> allHighlighitems = ListLinkHighlightitems;

                String[] txtHighlightitems = new String[allHighlighitems.Count];
                int i = 0;
                int j = 0;
                foreach (IWebElement element in ListLinkHighlightitems)
                {
                    txtHighlightitems[i++] = element.GetAttribute("href");
                    IWebElement highlightele = element;
                    j = i - 1;
                    if (txtHighlightitems[j].Contains(txtHighLightItem))
                    {
                        highlightele.Click();
                    }
                }
            }
            catch (Exception e)
            {
                log.Warn("Error :", e);

            }
        }

        /// <summary>
        /// Action to be click on the product name in the Smart Mall main page.
        /// </summary>
        /// <param txtproductname=Product name to be click on the main page.></param>
        public void ClickFeaturesProduct(ref string txtproductname)
        {
            try
            {
                IList<IWebElement> allFeaturesProduct = ListfeaturesProductItem;

                string txtFeaturesitems = "";
                
                foreach (IWebElement element in allFeaturesProduct)
                {
                    txtFeaturesitems = element.Text;
                    IWebElement featuresproductEle = element;
                    
                    if (txtFeaturesitems == null || txtFeaturesitems == "")
                        continue;


                    if (txtFeaturesitems.Contains(txtproductname))
                    {
                        featuresproductEle.Click();
                        break;
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
