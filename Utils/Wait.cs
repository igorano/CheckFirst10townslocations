using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

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

        public IWebElement WaitForElementToBeClickable(By locator)
        {
            var condition = SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator);

            return WaitForExpectedCondition(condition);
        }


        private IWebElement WaitForExpectedCondition(Func<IWebDriver, IWebElement> condition)
        {
            int attempts = 0;
            while (true)
            {
                try
                {
                    return DefaultWait.Until(condition);
                }
                catch (Exception)
                {
                    if (attempts == 3)
                    {
                        throw;
                    }

                    attempts++;
                }
            }
        }
    }
}
