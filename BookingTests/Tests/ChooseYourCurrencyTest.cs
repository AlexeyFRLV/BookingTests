using BookingTests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace BookingTests
{
    public class ChooseYourCurrencyTest
    {
        private IWebDriver _webDriver;
        private readonly string currencyTarget = "EUR";

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();

            _webDriver.Navigate().GoToUrl("https://booking.com");
            WaitUntil.ShouldLocate(_webDriver, "https://www.booking.com/");
        }

        [Test]
        public void Currency_Change_Test()
        {
            var mainMenu = new MainMenuPageObject(_webDriver);
            mainMenu.CurrencyChange().CurrencySelect();

            string actualCurrency = mainMenu.GetActualCurrency();
            Assert.AreEqual(currencyTarget, actualCurrency, "The currency did't change.");
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Close();
        }
    }
}