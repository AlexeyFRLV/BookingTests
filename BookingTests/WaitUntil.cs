using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace BookingTests
{
    public static class WaitUntil
    {
        public static void ShouldLocate(IWebDriver webDriver, string location)
        {
            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.UrlContains(location));
            }
            catch (WebDriverTimeoutException ex)
            {

                throw new NotFoundException($"Cannot find out that app in specific location: {location}", ex);
            }
        }

        public static void WaitElement(IWebDriver webDriver, By locator, int seconds = 10)
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(locator));
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
