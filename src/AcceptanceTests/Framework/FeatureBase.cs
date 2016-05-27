using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AcceptanceTests.Framework
{
    public abstract class FeatureBase
    {
        protected void WaitDocumentLoaded(IWebDriver IeDriver)
        {
            ((IWait<IWebDriver>)new WebDriverWait(IeDriver, TimeSpan.FromSeconds(30))).Until(JsIsDocumentLoaded);
        }

        private bool JsIsDocumentLoaded(IWebDriver driver)
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