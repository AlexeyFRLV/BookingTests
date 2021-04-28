using OpenQA.Selenium;

namespace BookingTests.PageObjects
{
    class FlightsPageObject
    {
        private IWebDriver _webDriver;
        private readonly By _flightsSelected = By.XPath("/html/body/div[1]/div[1]/div[3]/div[2]/div/a[2]");

        public FlightsPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetFlightsPage()
        {
            WaitUntil.WaitElement(_webDriver, _flightsSelected);

            return _webDriver.FindElement(_flightsSelected).GetAttribute("class");
        }
    }
}
