using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CheckFirst10TownsLocations.Utils
{
    class Wait
    {
        private readonly IWebDriver driver;

        // Wait 
        public const int WAIT_DELAY = 15;
        public const int POLLING_INTERVAL = 433;
        public Wait(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public WebDriverWait DefaultWait =>
            new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_DELAY))
            {
                PollingInterval = TimeSpan.FromMilliseconds(POLLING_INTERVAL),
                Timeout = TimeSpan.FromSeconds(15)
            };

        public void WaitForElementToBeClickable(By locator)
        {
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator);
        }

        public void WaitForElementToBeVisible(By locator)
        {
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator);
        }

        public void WaitForExistingElement(By locator)
        {
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator);
        }

    }
}
