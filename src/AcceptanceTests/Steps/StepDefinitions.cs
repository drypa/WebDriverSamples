using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace AcceptanceTests.Steps
{
    [Binding]
    public sealed class StepDefinitions
    {
        private readonly string loginPage = "Account/Login";
        private readonly string siteUrl = "http://localhost:16729/";
        private IWebDriver webDriver;

        [BeforeScenario("ApplicationIsOpened")]
        public void ApplicationIsOpened()
        {
            webDriver = new RemoteWebDriver(new Uri(@"http://10.0.2.200:4444/wd/hub"), DesiredCapabilities.Chrome());
            webDriver.Navigate().GoToUrl(siteUrl);
        }

        [AfterScenario("ApplicationIsOpened")]
        public void TearDown()
        {
            webDriver.Quit();
        }

        [Then(@"I see ""(.*)""")]
        public void ThenISee(string text)
        {
            IWebElement textElement = webDriver.FindElement(By.XPath($"//*[contains(text(),'{text}')]"));
            Assert.IsTrue(textElement.Displayed);
        }

        [When(@"I enter by user name ""(.*)"" and password ""(.*)""")]
        public void WhenIEnterUserNameAndPassword(string login, string password)
        {
            WhenIPressButton("Log in");
            IWebElement loginInput = webDriver.FindElement(By.Id("Email"));
            IWebElement passwordInput = webDriver.FindElement(By.Id("Password"));

            loginInput.SendKeys(login);
            passwordInput.SendKeys(password);

            IWebElement loginButton = webDriver.FindElement(By.CssSelector("[type='submit']"));
            loginButton.Click();
        }

        [When(@"I press button ""(.*)""")]
        [When(@"I press link ""(.*)""")]
        public void WhenIPressButton(string buttonName)
        {
            IWebElement button = webDriver.FindElement(By.PartialLinkText(buttonName));
            button.Click();
        }
    }
}
