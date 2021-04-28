using BookingTests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace BookingTests
{
    class FlightsTest
    {
        private IWebDriver _webDriver;
        private readonly string flightsButtonSelected = "selected";

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();

            _webDriver.Navigate().GoToUrl("https://booking.com");
            WaitUntil.ShouldLocate(_webDriver, "https://www.booking.com/");
        }

        [Test]
        public void Flights_Page_Selected()
        {
            var mainMenu = new MainMenuPageObject(_webDriver);

            string actualPage = mainMenu.SelectFlightsPage().GetFlightsPage();
            Assert.AreEqual(flightsButtonSelected, actualPage, "The page doesn't match.");
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Close();
        }
    }
}
