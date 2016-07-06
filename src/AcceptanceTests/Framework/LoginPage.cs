using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AcceptanceTests.Framework
{
    public sealed class LoginPage: BasePage
    {
        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement UserNameTextField { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordTextField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[type='submit']")]
        public IWebElement LoginButton { get; set; }


        [FindsBy(How = How.CssSelector, Using = ".validation-summary-errors")]
        public IWebElement ValidationErrors { get; set; }

        public LoginPage(IWebDriver webDriver)
            :base(webDriver)
        {
            PageTitle = "Log in - WebDriverSamples";
        }
        public LoginPage TypeLogin(string login)
        {
            UserNameTextField.SendKeys(login);
            return this;
        }

        public LoginPage TypePassword(string password)
        {
            PasswordTextField.SendKeys(password);
            return this;
        }

        public HomePage PressLoginButton()
        {
            LoginButton.Click();
            var homePage = new HomePage(Driver);
            PageFactory.InitElements(Driver, homePage);

            return homePage;
        }
    }
}