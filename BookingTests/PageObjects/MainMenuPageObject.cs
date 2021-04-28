using OpenQA.Selenium;
using System;
using System.Threading;

namespace BookingTests.PageObjects
{
    class MainMenuPageObject
    {
        private IWebDriver _webDriver;

        //Currecncy selection
        private readonly By _currencyButton = By.XPath("//*[@id=\"b2indexPage\"]/header/nav[1]/div[2]/div[1]/button/span/span[1]");

        //Language selection
        private readonly By _languageButton = By.XPath("//*[@id=\"b2indexPage\"]/header/nav[1]/div[2]/div[2]/button/span/div/img");

        //Checking flights
        private readonly By _flightsButton = By.XPath("//*[@id=\"b2indexPage\"]/header/nav[2]/ul/li[2]/a/span[2]");
        
        //Authorization
        private readonly By _signInButton = By.XPath("//*[@id=\"b2indexPage\"]/header/nav[1]/div[2]/div[6]/a/span");
        private readonly By _userLogin = By.XPath("/html/body/header/nav[1]/div[2]/div[6]/div/a/span/div/div[2]/span[1]");

        //Search by template
            //city
        private readonly By _citySearchField = By.Id("ss");
        private readonly By _citySearchFieldHelper = By.XPath("/html/body/div[2]/div/div/div[2]/form/div[1]/div[1]/div[1]/div[1]/ul[1]/li[1]");
            //date
        private readonly By _checkInDate = By.XPath("//*[@id=\"frm\"]/div[1]/div[2]/div[2]/div/div/div[3]/div[2]/table/tbody/tr[2]/td[1]/span/span");
        private readonly By _evictionDate = By.XPath("//*[@id=\"frm\"]/div[1]/div[2]/div[2]/div/div/div[3]/div[2]/table/tbody/tr[2]/td[3]/span/span");
            //guests
        private readonly By _guestsToggle = By.XPath("/html/body/div[2]/div/div/div[2]/form/div[1]/div[3]/label");
        private readonly By _guestsToggleBar = By.XPath("/html/body/div[2]/div/div/div[2]/form/div[1]/div[3]/div[2]");
        private readonly By _addAdultButton = By.XPath("/html/body/div[2]/div/div/div[2]/form/div[1]/div[3]/div[2]/div/div/div[1]/div/div[2]/button[2]");
        private readonly By _addChildButton = By.XPath("/html/body/div[2]/div/div/div[2]/form/div[1]/div[3]/div[2]/div/div/div[2]/div/div[2]/button[2]");
        private readonly By _addRoomButton = By.XPath("/html/body/div[2]/div/div/div[2]/form/div[1]/div[3]/div[2]/div/div/div[3]/div/div[2]/button[2]");
        private readonly By _searchButton = By.XPath("//*[@id=\"frm\"]/div[1]/div[4]/div[2]/button/span[1]");

        public MainMenuPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        
        public CurrencyPageObject CurrencyChange()
        {
            _webDriver.FindElement(_currencyButton).Click();

            return new CurrencyPageObject(_webDriver);
        }

        public LanguagePageObject LanguageChange()
        {
            _webDriver.FindElement(_languageButton).Click();

            return new LanguagePageObject(_webDriver);
        }

        public string GetActualCurrency()
        {
            WaitUntil.WaitElement(_webDriver, _currencyButton);
            return _webDriver.FindElement(_currencyButton).Text;
        }

        public string GetActualLanguage()
        {
            WaitUntil.WaitElement(_webDriver, _languageButton);
            return _webDriver.FindElement(_languageButton).GetAttribute("src");
        }

        public FlightsPageObject SelectFlightsPage()
        {
            _webDriver.FindElement(_flightsButton).Click();

            return new FlightsPageObject(_webDriver);
        }         

        public AuthorizationPageObject SignIn()
        {
            _webDriver.FindElement(_signInButton).Click();

            return new AuthorizationPageObject(_webDriver);
        }

        public string GetUserName()
        {
            WaitUntil.WaitElement(_webDriver, _userLogin);

            return _webDriver.FindElement(_userLogin).Text;
        }

        public SearchResultsPageObject Seach(string city, int adult, int child, int room)
        {
            _webDriver.FindElement(_citySearchField).SendKeys(city);
            WaitUntil.WaitElement(_webDriver, _citySearchFieldHelper);
            _webDriver.FindElement(_citySearchFieldHelper).Click();


            _webDriver.FindElement(_checkInDate).Click();
            _webDriver.FindElement(_evictionDate).Click();

            _webDriver.FindElement(_guestsToggle).Click();

            WaitUntil.WaitElement(_webDriver, _guestsToggleBar);

            for (int i = 2; i < adult; i++)
            {
                _webDriver.FindElement(_addAdultButton).Click();
            }

            for (int i = 0; i < child; i++)
            {
                _webDriver.FindElement(_addChildButton).Click();
            }

            for (int i = 1; i < room; i++)
            {
                _webDriver.FindElement(_addRoomButton).Click();
            }

            _webDriver.FindElement(_searchButton).Click();

            return new SearchResultsPageObject(_webDriver);
        }
    }
}
