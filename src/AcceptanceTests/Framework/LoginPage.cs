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

        public LoginPage(IWebDriver webDriver)
            :base(webDriver)
        {
            PageTitle = "Log in - WebDriverSamples";
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

        public HomePage PressLoginButton()
        {
            loginButton.Click();
            var homePage = new HomePage(Driver);
            PageFactory.InitElements(Driver, homePage);

            return homePage;
        }
    }
}