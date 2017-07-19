using OpenQA.Selenium;

namespace SmartMallFramework
{
    enum PropertyType
    {
        Id,
        Name,
        Linktext,
        CssName,
        ClassName
    }

    enum AttributeType
    {
        href,
        label
    }


    public class Browser
    {
        public static IWebDriver driver { get; set; }
    }

    class Base
    {
        public IWebDriver Drivers { get; set; }
    }
}
