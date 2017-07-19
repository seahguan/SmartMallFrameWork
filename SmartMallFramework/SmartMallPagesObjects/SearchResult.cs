using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SmartMallFramework
{
    class SearchResult
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SearchResult()
        {
            PageFactory.InitElements(Browser.driver, this);
        }
        
        [FindsBy(How = How.TagName, Using = "a[href*='viewmode=grid']")]
        public IWebElement linkGridView { get; set; }

        [FindsBy(How = How.TagName, Using = "a[href*='viewmode=list']")]
        public IWebElement linkListView { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='product-item']")]
        public IList<IWebElement> ListResultElements { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.search-text.valid")]
        public IWebElement txtsearchfields { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[@class='inputs reversed']")]
        public IWebElement DisAdvSearchfeield { get; set; }

        [FindsBy(How = How.Id, Using = "products-orderby")]
        public IList<IWebElement> SortingOrderList { get; set; }

        [FindsBy(How = How.Id, Using = "product-title")]
        public IList<IWebElement> SelProduct { get; set; }
        
        [FindsBy(How = How.Id, Using = "cid")]
        public IList<IWebElement> ddlProductcat { get; set; }

        [FindsBy(How = How.Id, Using = "isc")]
        public IWebElement SearchCatCheckBox { get; set; }
        
        [FindsBy(How = How.Id, Using = "sid")]
        public IWebElement SearchDescCheckBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.button-1.search-button")]
        public IWebElement btnSearch { get; set; }

        [FindsBy(How = How.Id, Using = "goToTop")]
        public IWebElement btngoToTop { get; set; }

        /// <summary>
        /// select the selected searh out product 
        /// </summary>
        /// <param txtsearchproduct= Product name to the selected in the search result page.></param>
        public void SelSearchResult(ref string txtsearchproduct)
        {
            try
            {
                IList<IWebElement> allSearchResultItems = ListResultElements;

                string txtSearchResultItems = "";
                                
                foreach (IWebElement element in allSearchResultItems)
                {
                    txtSearchResultItems = element.Text;
                    IWebElement SelectedItem = element;

                    if (txtSearchResultItems == null)
                        continue;

                    if (txtSearchResultItems.Contains(txtsearchproduct))
                    {
                        SelectedItem.Click();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                log.Warn("Error :", e);

            }
        }

        /// <summary>
        /// click on the advance search fucntion disable / enable.
        /// </summary>
        public void clickDisAdvSearchfeield()
        {
            DisAdvSearchfeield.Click();
        }


        /// <summary>
        /// Change the sorting order in the searh result product page
        /// </summary>
        /// <param txtSortingOrders=Sorting type></param>
        public void ChgSortingOrder(ref string txtSortingOrders)
        {
            try
            {
                IList<IWebElement> AllSorting = SortingOrderList;

                string txtSortingItems = "";
                
                foreach (IWebElement element in SortingOrderList)
                {
                    txtSortingItems = element.GetAttribute("href");
                    IWebElement sortingele = element;

                    if (txtSortingItems.Contains(txtSortingOrders))
                    {
                        sortingele.Click();
                    }
                }
            }
            catch (Exception e)
            {
                log.Warn("Error :", e);

            }
        }

        /// <summary>
        /// clieck onthe search sub category
        /// </summary>
        public void clickSearchSubCategory()
        {
            SearchCatCheckBox.Submit();
        }

        /// <summary>
        /// click on the search category to change the to decending order 
        /// </summary>
        public void clickSearchDescCategory()
        {
            SearchDescCheckBox.Submit();
        }

        /// <summary>
        /// click on the go to top page in the search result page
        /// </summary>
        public void clickGoToTop()
        {
            btngoToTop.Click();
        }

    }
}
