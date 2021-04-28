using BookingTests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace BookingTests
{ 
    class ChooseYourLanguageTest
    {
        private IWebDriver _webDriver;
        private readonly string languageTarget = "https://cf.bstatic.com/static/img/flags/new/48-squared/us/fa2b2a0e643c840152ba856a8bb081c7ded40efa.png";

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();

            _webDriver.Navigate().GoToUrl("https://booking.com");
            WaitUntil.ShouldLocate(_webDriver, "https://www.booking.com/");
        }

        [Test]
        public void Language_Change_Test()
        {
            var mainMenu = new MainMenuPageObject(_webDriver);
            mainMenu.LanguageChange().LanguageSelect();

            string actualLanguage = mainMenu.GetActualLanguage();
            Assert.AreEqual(languageTarget, actualLanguage, "The language didn't change.");
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Close();
        }
    }
}
