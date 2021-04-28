using BookingTests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace BookingTests
{ 
    class SearchTest
    {
        private IWebDriver _webDriver;
        SearchTemplate template = new SearchTemplate();
        List<string> actualParam;

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();

            _webDriver.Navigate().GoToUrl("https://booking.com");
            WaitUntil.ShouldLocate(_webDriver, "https://www.booking.com/");
        }

        [Test]
        public void Search_By()
        {
            var mainMenu = new MainMenuPageObject(_webDriver);

            actualParam = mainMenu.Seach(template.City, template.Adult, template.Child, template.Room).GetActualParam();
            Assert.AreEqual(template.GetTemplateParam(), actualParam, "The resulting template does not match the specified one");
        }
    }
}
