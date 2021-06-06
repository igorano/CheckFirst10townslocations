// <copyright file="BasePage.cs" company="TestingCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CheckFirst10TownsLocations.Pages
{
    using OpenQA.Selenium;

    public class BasePage
    {
        public readonly IWebDriver driver;

        private readonly string google = "https://www.zip-codes.com/";

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToPage()
        {
            this.driver.Navigate().GoToUrl(this.google);
        }
    }
}