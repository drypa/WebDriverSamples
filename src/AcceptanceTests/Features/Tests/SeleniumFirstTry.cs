using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;

namespace AcceptanceTests.Features.Tests
{
    [TestFixture]
    public class SeleniumFirstTry
    {
        private readonly string siteUrl = "http://localhost:16729/";
        private IWebDriver webDriver;

        [SetUp]
        public void SetUp()
        {
            webDriver = new FirefoxDriver();
            //webDriver = new ChromeDriver();
            //webDriver = new InternetExplorerDriver();
        }

        [Test]
        public void FirstTest()
        {
            webDriver.Navigate().GoToUrl(siteUrl);
            var carousel = webDriver.FindElement(By.Id("myCarousel"));
            Assert.IsTrue(carousel.Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            //webDriver.Quit();
        }
    }
}
