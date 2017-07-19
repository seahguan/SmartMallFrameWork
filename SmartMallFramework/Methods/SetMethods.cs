using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;



namespace SmartMallFramework
{
    /// <summary>
    /// define the send in function and the click action 
    /// </summary>
    public static class SetMethods
    {
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);            
        }

        public static void Clicks(this IWebElement element)
        {
            element.Click();            
        }

        public static void SelectDRopDown(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);            
        }
    }
}
