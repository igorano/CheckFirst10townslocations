using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckFirst10TownsLocations.Pages
{
    class TableWithTowns : Base
    {
        private readonly By FirstTown = By.XPath("//tbody/tr[2]/td[1]/a");

        public TableWithTowns(IWebDriver driver) : base(driver)
        {
        }
        public void ClickFirstTown() {
            Wait.WaitForElementToBeClickable(FirstTown);
            driver.FindElement(FirstTown).Click();
        }
    }
}
