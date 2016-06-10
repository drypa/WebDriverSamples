using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AcceptanceTests.Framework
{
    public sealed class StartPage: BasePage
    {
        [FindsBy(How = How.LinkText, Using = "Log in")]
        public IWebElement loginLink;

        [FindsBy(How = How.LinkText, Using = "Home")]
        public IWebElement homeLink;

        [FindsBy(How = How.LinkText, Using = "About")]
        public IWebElement aboutLink;

        [FindsBy(How = How.LinkText, Using = "Contact")]
        public IWebElement contactLink;

        public StartPage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        public StartPage GoToHome()
        {
            return this;
        }

        public StartPage GoToAbout()
        {
            return this;
        }

        public StartPage GoToContact()
        {
            return this;
        }
        public StartPage GoToRegister()
        {
            return this;
        }

        public LoginPage GoToLogIn()
        {
            loginLink.Click();
            var loginPage = new LoginPage(Driver);
            PageFactory.InitElements(Driver, loginPage);
            return loginPage;
        }
    }
}