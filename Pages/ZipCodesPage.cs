// <copyright file="ZipCodesPage.cs" company="TestingCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CheckFirst10TownsLocations.Pages
{
    using System;
    using CheckFirst10TownsLocations.Utils;
    using OpenQA.Selenium;

    internal class ZipCodesPage : BasePage
    {
        private readonly Wait wait;

        private readonly By latitude = By.XPath("//td[preceding-sibling::td[contains(.,'Latitude')]]");
        private readonly By longitude = By.XPath("//td[preceding-sibling::td[contains(.,'Longitude')]]");
        private readonly string cityName = "(//a[contains(.,'IVA')])[{0}]";
        private readonly By state = By.XPath("(//td[preceding-sibling::td[contains(.,'State')]])[2]");
        private readonly By zipCode = By.XPath("(//td[preceding-sibling::td[contains(.,'Zip Code')]])[last()]");
        private readonly By lonelyZipCode = By.XPath("(//td//a[starts-with(@title, 'ZIP Code')])[last()]");
        private readonly By confirm = By.XPath("//span[text() = 'Приемам']");
        private readonly By getCityName = By.XPath("(//td[preceding-sibling::td[contains(.,'City')]])[2]");
        private readonly string searchedURL = "https://www.zip-codes.com/search.asp?fld-zip=&fld-city=iva&fld-state=&fld-county=&fld-areacode=&selectTab=3&Submit=Find+ZIP+Codes";

        public ZipCodesPage(IWebDriver driver)
            : base(driver)
        {
            this.wait = new Wait(driver);
        }

        public string GetLantitude()
        {
            this.wait.WaitForElementToBeClickable(this.latitude);
            string latitude = this.driver.FindElement(this.latitude).Text;
            return latitude;
        }

        public string GetLongitude()
        {
            this.wait.WaitForElementToBeClickable(this.longitude);
            string longitude = this.driver.FindElement(this.longitude).Text;
            return longitude;
        }

        public string GetCityWithXPath(string number)
        {
            return string.Format(this.cityName, number);
        }

        public void ClickCityName(string number)
        {
            this.wait.WaitForElementToBeClickable(By.XPath(this.GetCityWithXPath(number).ToString()));
            this.driver.FindElement(By.XPath(this.GetCityWithXPath(number).ToString())).Click();
        }

        public string GetState()
        {
            this.wait.WaitForElementToBeClickable(this.state);
            string state = this.driver.FindElement(this.state).Text;
            return state;
        }

        public string GetZipCode()
        {
            this.wait.WaitForElementToBeClickable(this.zipCode);
            string zipCode = this.driver.FindElement(this.zipCode).Text;
            return zipCode;
        }

        public string GetCityName()
        {
            this.wait.WaitForElementToBeClickable(this.getCityName);
            return this.driver.FindElement(this.getCityName).Text;
        }

        public void ClickFirstRecord()
        {
            this.wait.WaitForElementToBeClickable(this.lonelyZipCode);
            this.driver.FindElement(this.lonelyZipCode).Click();
        }

        public void TakeScreenshots()
        {
            for (int i = 1; i < 11; i++)
            {
                this.ClickCityName(i.ToString());
                this.ClickFirstRecord();
                this.GetLantitude();
                this.GetLongitude();
                string state = this.GetState();
                string zipCode = this.GetZipCode();
                string city = this.GetCityName();
                string url = "https://www.google.com/maps/search/?api=1&query=" + this.GetLantitude() + "," + this.GetLongitude();
                this.driver.Navigate().GoToUrl(url);
                try
                {
                    this.driver.FindElement((By)this.confirm).Click();
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("Confirm button is already clicked");
                }

                Screenshot ss = ((ITakesScreenshot)this.driver).GetScreenshot();
                string screenshotName = city + "-" + state + "-" + zipCode + ".jpg";
                ss.SaveAsFile(screenshotName, ScreenshotImageFormat.Png);
                this.driver.Navigate().GoToUrl(this.searchedURL);
            }
        }
    }
}
