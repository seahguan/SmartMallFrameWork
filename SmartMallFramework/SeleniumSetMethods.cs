using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumFirst
{
    public static class SeleniumSetMethods
    {
        // Enter Text
        //public static void EnterText(string element, string value, PropertyType elementtype)
        //public static void EnterText(IWebElement element, string value )
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value); 

            //if (elementtype == PropertyType.Id)
            //    PropertiesCollections.driver.FindElement(By.Id(element)).SendKeys(value);
            //if (elementtype == PropertyType.Name)
            //    PropertiesCollections.driver.FindElement(By.Name(element)).SendKeys(value);
        }

        //CLick into a button , checkbox, option& etc...
        //public static void Click(string element, PropertyType elementtype)
        //public static void Click(IWebElement element)
        public static void Clicks(this IWebElement element)
        {

            element.Click();

            //if (elementtype == PropertyType.Id)
            //    PropertiesCollections.driver.FindElement(By.Id(element)).Click();
            //if (elementtype == PropertyType.Name)
            //    PropertiesCollections.driver.FindElement(By.Name(element)).Click();
        }

        //Selection Dropdown control
        //public static void SelectDRopDown(string element, string value, PropertyType elementtype)
        //public static void SelectDRopDown(IWebElement element, string value)
        public static void SelectDRopDown(this IWebElement element, string value)
        {

            new SelectElement(element).SelectByText(value);
            
            //if (elementtype == PropertyType.Id)
            //    new SelectElement(PropertiesCollections.driver.FindElement(By.Id(element))).SelectByText(value);
            //if (elementtype == PropertyType.Name)
            //    new SelectElement(PropertiesCollections.driver.FindElement(By.Name(element))).SelectByText(value);  
            
        }
    }
}
