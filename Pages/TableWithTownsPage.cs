// <copyright file="TableWithTownsPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CheckFirst10TownsLocations.Pages
{
    using OpenQA.Selenium;

    internal class TableWithTownsPage : BasePage
    {
        private readonly By firstTown = By.XPath("//tbody/tr[2]/td[1]/a");

        public TableWithTownsPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void ClickFirstTown()
        {
            Utils.Wait.WaitForElementToBeClickable(this.firstTown);
            this.driver.FindElement(this.firstTown).Click();
        }
    }
}
