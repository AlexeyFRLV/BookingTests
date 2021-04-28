using OpenQA.Selenium;

namespace BookingTests.PageObjects
{
    class CurrencyPageObject
    {
        private IWebDriver _webDriver;
        private readonly By _currencyChangeButton = By.XPath("/html/body/div[15]/div/div/div/div/div/div/div/div/div/div[2]/div/div[2]/div/div/div[5]/ul/li[1]/a/div/div");

        public CurrencyPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MainMenuPageObject CurrencySelect()
        {
            WaitUntil.WaitElement(_webDriver, _currencyChangeButton);
            _webDriver.FindElement(_currencyChangeButton).Click();

            return new MainMenuPageObject(_webDriver);
        }
    }
}
