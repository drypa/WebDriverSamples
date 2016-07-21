using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AcceptanceTests.Framework
{
    public static class FeatureBase
    {
        public static void WaitDocumentLoaded(this IWebDriver webDriver)
        {
            ((IWait<IWebDriver>)new WebDriverWait(webDriver, TimeSpan.FromSeconds(30))).Until(JsIsDocumentLoaded);
        }

        private static bool JsIsDocumentLoaded(IWebDriver driver)
        {
            try
            {
                return ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState;").Equals("complete");
            }
            catch (InvalidOperationException)
            { }
            return false;
        }
    }
}