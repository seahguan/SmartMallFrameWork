using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SmartMallFramework
{
    /// <summary>
    /// define the get method which can used it globally 
    /// </summary>
    public static class GetMethods
    {

        public static string GetText(this IWebElement element)
        {
            return element.GetAttribute("Value");
        }
        
        public static string GetTextFromDDL(this IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }
    }
}
