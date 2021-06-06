// <copyright file="FirstPage.cs" company="TestingCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CheckFirst10TownsLocations.Pages
{
    using OpenQA.Selenium;

    class FirstPage : BasePage
    {
        private readonly By search = By.XPath("//a[@title = 'FREE ZIP Code Search']");

        public FirstPage(IWebDriver driver)
    : base(driver)
        {
        }

        public void ClickSearch()
        {
            this.driver.FindElement((By)this.search).Click();
        }
    }
}
