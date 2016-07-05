using OpenQA.Selenium;

namespace AcceptanceTests.Framework
{
    public sealed class HomePage : BasePage
    {
        public HomePage(IWebDriver webDriver)
            : base(webDriver)
        {
            PageTitle = "Home Page - WebDriverSamples";
        }
    }
}