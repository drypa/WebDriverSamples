using System;
using AcceptanceTests.Framework;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps
{
    [Binding]
    public sealed class PageObjectStepDefinitions
    {
        private StartPage startPage;
        private IWebDriver webDriver;
        private string baseUrl = "http://localhost:16729/";

        private LoginPage loginPage;
        private HomePage homePage;

        [BeforeScenario("Remote")]
        public void Before()
        {
            webDriver = new RemoteWebDriver(new Uri(@"http://10.0.2.200:4444/wd/hub"), DesiredCapabilities.Firefox());
        }

        [AfterScenario("Remote")]
        public void After()
        {
            webDriver.Quit();
        }


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
            loginPage.UserNameTextField.SendKeys(login);
        }

        [When(@"I enter password ""(.*)""")]
        public void WhenIEnterPassword(string password)
        {
            loginPage.PasswordTextField.SendKeys(password);
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

        [Given(@"I am on login page")]
        public void GivenIAmOnLoginPage()
        {
            webDriver.Navigate().GoToUrl("http://localhost:16729/Account/Login");

            loginPage = new LoginPage(webDriver);
            PageFactory.InitElements(webDriver, loginPage);
        }

        [Then(@"I see login error ""(.*)""")]
        public void ThenISeeLoginError(string errorText)
        {
            Assert.IsTrue(loginPage.ValidationErrors.Displayed);
            Assert.IsTrue(loginPage.ValidationErrors.Text.Contains(errorText));
        }
    }
}