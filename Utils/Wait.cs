// <copyright file="Wait.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CheckFirst10TownsLocations.Utils
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    internal class Wait
    {
        private readonly IWebDriver driver;

        private readonly int waitDelay = 15;
        private readonly int pollingInterval = 433;

        public Wait(IWebDriver webDriver)
        {
            this.driver = webDriver;
        }

        public WebDriverWait DefaultWait =>
            new WebDriverWait(this.driver, TimeSpan.FromSeconds(this.waitDelay))
            {
                PollingInterval = TimeSpan.FromMilliseconds(this.pollingInterval),
                Timeout = TimeSpan.FromSeconds(15),
            };

        public static void WaitForElementToBeClickable(By locator)
        {
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator);
        }

        public static void WaitForElementToBeVisible(By locator) => SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator);

        public static void WaitForExistingElement(By locator)
        {
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator);
        }
    }
}
