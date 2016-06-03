﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps
{
    [Binding]
    public sealed class StepDefinitions
    {
        private readonly string loginPage = "Account/Login";
        private readonly string siteUrl = "http://localhost:16729/";
        private readonly IWebDriver webDriver = new ChromeDriver(@"D:\WebDrivers\");

        [BeforeScenario("ApplicationIsOpened")]
        public void ApplicationIsOpened()
        {
            webDriver.Navigate().GoToUrl(siteUrl);
        }

        [AfterScenario]
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
            webDriver.Navigate().GoToUrl(siteUrl + loginPage);
            IWebElement loginInput = webDriver.FindElement(By.Id("Email"));
            IWebElement passwordInput = webDriver.FindElement(By.Id("Password"));

            loginInput.SendKeys(login);
            passwordInput.SendKeys(password);

            IWebElement loginButton = webDriver.FindElement(By.CssSelector("[type='submit']"));
            loginButton.Click();
        }
    }
}
