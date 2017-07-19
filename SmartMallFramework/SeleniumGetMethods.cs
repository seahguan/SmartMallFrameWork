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
    public static class SeleniumGetMethods
    {
        //public static string GetText(string element, PropertyType elementtype)

        //public static string GetText(IWebElement element)
        public static string GetText(this IWebElement element)
        {
            return element.GetAttribute("value");
            
            //if (elementtype == PropertyType.Id)
            //    return PropertiesCollections.driver.FindElement(By.Id(element)).GetAttribute("value");
            //if (elementtype == PropertyType.Name)
            //    return PropertiesCollections.driver.FindElement(By.Name(element)).GetAttribute("value");
            //else return String.Empty;
        }

        //public static string GetTextFromDDL(IWebElement  element, PropertyType elementtype)
        //public static string GetTextFromDDL(IWebElement element)
        public static string GetTextFromDDL(this IWebElement element)
        {

            return new SelectElement(element ).AllSelectedOptions.SingleOrDefault().Text;

            //if (elementtype == PropertyType.Id)
            //    return new SelectElement(PropertiesCollections.driver.FindElement(By.Id(element))).AllSelectedOptions.SingleOrDefault().Text;
            //if (elementtype == PropertyType.Name)
            //    return new SelectElement(PropertiesCollections.driver.FindElement(By.Name(element))).AllSelectedOptions.SingleOrDefault().Text;
            //else return String.Empty;
        }
    }
}
