using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps
{
    [Binding]
    public sealed class StepDefinitions
    {
        private IWebDriver webDriver = new ChromeDriver(@"D:\WebDrivers\");
        private string siteUrl = "http://localhost:16729/";
        private string loginPage = "Account/Login";

        [Given(@"Application is opened")]
        public void GivenApplicationIsOpened()
        {
            webDriver.Navigate().GoToUrl(siteUrl);
        }


        [When(@"I enter by user name ""(.*)"" and password ""(.*)""")]
        public void WhenIEnterUserNameAndPassword(string login, string password)
        {
            webDriver.Navigate().GoToUrl(siteUrl + loginPage);
            var loginInput = webDriver.FindElement(By.Id("Email"));
            var passwordInput = webDriver.FindElement(By.Id("Password"));

            loginInput.SendKeys(login);
            passwordInput.SendKeys(password);

            var loginButton = webDriver.FindElement(By.CssSelector("[type='submit']"));
            loginButton.Click();
        }

        [Then(@"I see ""(.*)""")]
        public void ThenISee(string text)
        {
            var textElement = webDriver.FindElement(By.XPath($"//*[contains(text(),'{text}')]"));
            Assert.IsTrue(textElement.Displayed);
        }


    }
}
