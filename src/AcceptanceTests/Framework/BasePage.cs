using OpenQA.Selenium;

namespace AcceptanceTests.Framework
{
    public abstract class BasePage
    {
        protected  IWebDriver Driver { get; set; }
        public string PageTitle { get; protected set; }

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public bool isDisplayed()
        {
            return Driver.Title == PageTitle;
        }
    }
}