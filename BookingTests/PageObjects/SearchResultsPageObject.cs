using OpenQA.Selenium;
using System.Collections.Generic;

namespace BookingTests.PageObjects
{
    class SearchResultsPageObject
    {
        private IWebDriver _webDriver;
        private readonly By _placeHolder = By.XPath("//*[@id=\"ss\"]");
        private readonly By _checkInDate = By.XPath("//*[@id=\"frm\"]/div[3]/div/div[1]/div[1]/div/div/div/div[2]");
        private readonly By _evictionDate = By.XPath("//*[@id=\"frm\"]/div[3]/div/div[1]/div[2]/div/div/div/div[2]");
        private readonly By _adult = By.XPath("/html/body/div[3]/div/div[3]/div[1]/div[2]/div[1]/div[1]/form/div[4]/div/div/div/div[1]/div/select/option[2]");
        private readonly By _child = By.XPath("/html/body/div[3]/div/div[3]/div[1]/div[2]/div[1]/div[1]/form/div[4]/div/div/div/div[2]/div[1]/select/option[2]");
        private readonly By _room = By.XPath("/html/body/div[3]/div/div[3]/div[1]/div[2]/div[1]/div[1]/form/div[4]/div/div/div/div[3]/div/select/option[1]");

        public SearchResultsPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            List<string> actualParam = new List<string>();
        }

        public List<string> GetActualParam()
        {
            WaitUntil.WaitElement(_webDriver, _placeHolder);
            
            List<string> actualParam = new List<string>();

            actualParam.Add(_webDriver.FindElement(_placeHolder).GetAttribute("value"));
            actualParam.Add(_webDriver.FindElement(_checkInDate).Text);
            actualParam.Add(_webDriver.FindElement(_evictionDate).Text);
            actualParam.Add(_webDriver.FindElement(_adult).GetAttribute("value"));
            actualParam.Add(_webDriver.FindElement(_child).GetAttribute("value"));
            actualParam.Add(_webDriver.FindElement(_room).GetAttribute("value"));

            return actualParam;
        }
    }
}
