// <copyright file="ZipCodesPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CheckFirst10TownsLocations.Pages
{
    using OpenQA.Selenium;

    internal class ZipCodesPage : BasePage
    {
        private readonly By latitude = By.XPath("(//tr[13]/td[2])[1]");
        private readonly By longitude = By.XPath("(//tr[14]/td[2])[1]");
        private readonly By cityName = By.XPath("//tbody/tr[2]/td[2]/a");
        private readonly By state = By.XPath("//table/tbody/tr[3]/td[2]/a");
        private readonly By zipCode = By.XPath("(//table/tbody/tr[1]/td[2])[2]");

        public ZipCodesPage(IWebDriver driver)
            : base(driver)
        {
        }

        public string GetLantitude()
        {
            Utils.Wait.WaitForElementToBeClickable(this.latitude);
            string latitude = this.driver.FindElement(this.latitude).Text;
            return latitude;
        }

        public string GetLongitude()
        {
            Utils.Wait.WaitForElementToBeClickable(this.longitude);
            string longitude = this.driver.FindElement(this.longitude).Text;
            return longitude;
        }

        public string GetCityName()
        {
            Utils.Wait.WaitForElementToBeClickable(this.cityName);
            string cityName = this.driver.FindElement(this.cityName).Text;
            return cityName;
        }

        public string GetState()
        {
            Utils.Wait.WaitForElementToBeClickable(this.state);
            string state = this.driver.FindElement(this.state).Text;
            return state;
        }

        public string GetZipCode()
        {
            Utils.Wait.WaitForElementToBeClickable(this.zipCode);
            string zipCode = this.driver.FindElement(this.zipCode).Text;
            return zipCode;
        }
    }
}
