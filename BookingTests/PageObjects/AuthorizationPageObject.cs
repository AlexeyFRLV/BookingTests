using OpenQA.Selenium;

namespace BookingTests.PageObjects
{
    class AuthorizationPageObject
    {
        private IWebDriver _webDriver;
        private readonly By _loginInputField = By.Id("username");
        private readonly By _continueButton = By.XPath("//*[@id=\"root\"]/div/div[2]/div[1]/div/div/div/div/div/div/form/div[3]/button/span");
        private readonly By _passwordInputField = By.Id("password");
        private readonly By _enterButton = By.XPath("//*[@id=\"root\"]/div/div[2]/div[1]/div/div/div/div/div/div/form/button/span");



        public AuthorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MainMenuPageObject Login(string login, string password)
        {
            WaitUntil.WaitElement(_webDriver, _loginInputField);
            _webDriver.FindElement(_loginInputField).SendKeys(login);
            _webDriver.FindElement(_continueButton).Click();

            WaitUntil.WaitElement(_webDriver, _passwordInputField);
            _webDriver.FindElement(_passwordInputField).SendKeys(password);
            _webDriver.FindElement(_enterButton).Click();

            return new MainMenuPageObject(_webDriver);
        }

    }
}
