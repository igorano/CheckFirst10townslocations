// <copyright file="SearchPage.cs" company="TestingCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CheckFirst10TownsLocations.Pages
{
    using System.Threading;
    using CheckFirst10TownsLocations.Utils;
    using OpenQA.Selenium;

    public class SearchPage : BasePage
    {
        private readonly By advancedSearch = By.XPath("//h3[@id= 'ui-id-7']");
        private readonly By town = By.XPath("(//input[@name = 'fld-city' ])[last()]");
        private readonly By submit = By.XPath("(//input[@type= 'submit' and @value='Find ZIP Codes'])[last()]");

        public SearchPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void ClickAdvancedSearch()
        {
            this.driver.FindElement(this.advancedSearch).Click();
        }

        public string PopulateTown(string name)
        {
            Thread.Sleep(200);
            this.driver.FindElement(this.town).SendKeys(name);
            return name;
        }

        public void ClickSubmit()
        {
            Wait.WaitForElementToBeClickable(this.submit);
            this.driver.FindElement((By)this.submit).Click();
        }
    }
}