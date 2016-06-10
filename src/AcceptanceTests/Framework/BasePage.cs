using OpenQA.Selenium;

namespace AcceptanceTests.Framework
{
    public abstract class BasePage
    {
        protected virtual IWebDriver Driver { get; set; }
    }
}