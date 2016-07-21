using System;
using AcceptanceTests.Framework;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace AcceptanceTests.Features.Tests
{
    [TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class GoogleTests<TWebDriver>
        where TWebDriver : IWebDriver, new()
    {
        [SetUp]
        public void CreateDriver()
        {
            driver = new TWebDriver();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        private IWebDriver driver;

        [Test]
        public void TestSearchQuery()
        {
            Assert.IsNotNull(driver);
            driver.Navigate().GoToUrl("http://www.google.com/");
            driver.WaitDocumentLoaded();

            driver.FindElement(By.CssSelector("#sfdiv input:first-of-type")).SendKeys("новости");
            driver.FindElement(By.ClassName("lsb")).Click();
        }
    }
}
