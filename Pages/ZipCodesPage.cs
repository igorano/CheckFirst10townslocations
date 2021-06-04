using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckFirst10TownsLocations.Pages
{
    class ZipCodesPage : BasePage
    {
        protected readonly By Latitude = By.XPath("(//tr[13]/td[2])[1]");
        protected readonly By Longitude = By.XPath("(//tr[14]/td[2])[1]");
        protected readonly By CityName = By.XPath("//tbody/tr[2]/td[2]/a");
        protected readonly By State = By.XPath("//table/tbody/tr[3]/td[2]/a");
        protected readonly By ZipCode = By.XPath("(//table/tbody/tr[1]/td[2])[2]");



        public ZipCodesPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetLantitude() 
        {
            Wait.WaitForElementToBeClickable(Latitude);
            string latitude = driver.FindElement(Latitude).Text;
            return latitude;
        }

        public string GetLongitude()
        {
            Wait.WaitForElementToBeClickable(Longitude);
            string longitude = driver.FindElement(Longitude).Text;
            return longitude;
        }

        public string GetCityName()
        {
            Wait.WaitForElementToBeClickable(CityName);
            string cityName = driver.FindElement(CityName).Text;
            return cityName;
        }
        public string GetState()
        {
            Wait.WaitForElementToBeClickable(State);
            string state = driver.FindElement(State).Text;
            return state;
        }
        public string GetZipCode()
        {
            Wait.WaitForElementToBeClickable(ZipCode);
            string zipCode = driver.FindElement(ZipCode).Text;
            return zipCode;
        }

    }
}
