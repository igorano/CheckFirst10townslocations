// <copyright file="BasePage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CheckFirst10TownsLocations.Pages
{
    using CheckFirst10TownsLocations.Utils;
    using OpenQA.Selenium;

    public class BasePage
    {
        private readonly string google = "https://www.zip-codes.com/";
        private readonly By search = By.XPath("//a[@title = 'FREE ZIP Code Search']");

        public readonly IWebDriver driver;
        private readonly Wait wait;

        public BasePage(IWebDriver driver)
#pragma warning restore SA1614 // Element parameter documentation should have text
        {
            this.driver = driver;
            this.wait = new Wait(driver);
        }

        public void GoToPage()
        {
            this.driver.Navigate().GoToUrl(this.google);
        }

        public void ClickSearch()
        {
            this.driver.FindElement((By)this.search).Click();
        }
    }
}