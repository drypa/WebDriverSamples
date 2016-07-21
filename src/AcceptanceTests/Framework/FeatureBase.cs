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

        public static IWebElement WaitElementIsPresent(this IWebDriver driver, By selector, int secondsToWait=10)
        {
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(secondsToWait));
            return wait.Until(ExpectedConditions.ElementIsVisible(selector));
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