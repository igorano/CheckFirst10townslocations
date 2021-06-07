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

        public void WaitForElementToBeClickable(By locator)
        {
            this.DefaultWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        public void WaitForElementToBeVisible(By locator)
        {
            this.DefaultWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitForExistingElement(By locator)
        {
            this.DefaultWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }
    }
}
