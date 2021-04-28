using BookingTests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BookingTests
{
    class AccountAccessTest
    {
        private IWebDriver _webDriver;
        User user = new User();

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();

            _webDriver.Navigate().GoToUrl("https://booking.com");
            WaitUntil.ShouldLocate(_webDriver, "https://www.booking.com/");
        }

        [Test]
        public void Log_In_Test()
        {
            var mainMenu = new MainMenuPageObject(_webDriver);
            mainMenu.SignIn().Login(user.Login, user.Password);
            
            string actualUserName = mainMenu.GetUserName();
            Assert.AreEqual(user.Name, actualUserName, "Login is wrong or enter wasn't completed.");
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Close();
        }
    }
}
