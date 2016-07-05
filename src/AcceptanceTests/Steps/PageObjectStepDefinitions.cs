using AcceptanceTests.Framework;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps
{
    [Binding]
    public sealed class PageObjectStepDefinitions
    {
        private StartPage startPage;
        private readonly IWebDriver webDriver = new ChromeDriver(@"D:\WebDrivers\");
        private string baseUrl = "http://localhost:16729/";

        public LoginPage loginPage;
        public HomePage homePage;

        [Given(@"I am on start page")]
        public void GivenIAmOnStartPage()
        {
            webDriver.Navigate().GoToUrl(baseUrl);

            startPage = new StartPage(webDriver);
            PageFactory.InitElements(webDriver, startPage);
        }

        [When(@"I go to login page")]
        public void WhenIGoToLoginPage()
        {
            loginPage = startPage.GoToLogIn();
        }

        [Then(@"I should be on login page")]
        public void ThenIShouldBeOnLoginPage()
        {
            Assert.IsTrue(loginPage?.isDisplayed());
        }

        [When(@"I enter login ""(.*)""")]
        public void WhenIEnterLogin(string login)
        {
            loginPage.userNameTextField.SendKeys(login);
        }

        [When(@"I enter password ""(.*)""")]
        public void WhenIEnterPassword(string password)
        {
            loginPage.passwordTextField.SendKeys(password);
        }

        [When(@"I press login button")]
        public void WhenIPressLoginButton()
        {
            homePage = loginPage.PressLoginButton();
        }

        [Then(@"I should be on home page")]
        public void ThenIShouldBeOnHomePage()
        {
            Assert.IsTrue(homePage?.isDisplayed());
        }

        [AfterScenario]
        public void TearDown()
        {
            webDriver.Quit();
        }

    }
}