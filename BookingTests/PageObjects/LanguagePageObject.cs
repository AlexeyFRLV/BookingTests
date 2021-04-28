using OpenQA.Selenium;
using System.Threading;

namespace BookingTests.PageObjects
{
    class LanguagePageObject
    {
        private IWebDriver _webDriver;
        private readonly By _languageChangeButton = By.XPath("/html/body/div[15]/div/div/div/div/div/div/div/div/div/div[2]/div/div[2]/div/div/div[1]/ul/li[2]/a/div");


        public LanguagePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MainMenuPageObject LanguageSelect()
        {
            WaitUntil.WaitElement(_webDriver, _languageChangeButton);
            _webDriver.FindElement(_languageChangeButton).Click();

            return new MainMenuPageObject(_webDriver);
        }
    }
}
