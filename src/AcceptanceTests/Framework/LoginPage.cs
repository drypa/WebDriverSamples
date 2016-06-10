using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AcceptanceTests.Framework
{
    public sealed class LoginPage: BasePage
    {
        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement userNameTextField;

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement passwordTextField;

        [FindsBy(How = How.CssSelector, Using = "[type='submit']")]
        public IWebElement loginButton;

        private readonly string pageTitle = "Log in - WebDriverSamples";

        public bool isDisplayed()
        {
            return Driver.Title == pageTitle;
        }

        public LoginPage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }
        public LoginPage TypeLogin(string login)
        {
            userNameTextField.SendKeys(login);
            return this;
        }

        public LoginPage TypePassword(string password)
        {
            passwordTextField.SendKeys(password);
            return this;
        }

        public LoginPage PressLoginButton()
        {
            loginButton.Click();
            //PageFactory.InitElements(Driver,)

            return this;
        }
    }
}