using CheckFirst10TownsLocations.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace CheckFirst10TownsLocations
{
    public class SeleniumTest
    {
        public IWebDriver driver;
        Base base_page;
        Search search_page;
        TableWithTowns table;
        ZipCodes codes; 

        [SetUp]
        public void Init()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            driver = new ChromeDriver();
        }

        [Test]
        public void GetFirst10Results()
        {
            base_page = new Base(driver);
            search_page = new Search(driver);
            table = new TableWithTowns(driver);
            codes = new ZipCodes(driver);
            base_page.GoToPage();
            base_page.ClickSearch();
            search_page.ClickAdvancedSearch();
            search_page.PopulateTown("iva");
            search_page.ClickSubmit();

            for (int i=0; i < 10; i++)
            {
                table.ClickFirstTown();
                codes.GetLantitude();
                codes.GetCityName();
                codes.GetState();
                codes.GetZipCode();
                codes.GetLongitude();
                string url = "https://www.google.com/maps/search/?api=1&query=" + codes.GetLantitude() + "," + codes.GetLongitude();
                driver.Navigate().GoToUrl(url);
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                string screenshotName = "<" + codes.GetCityName() + ">-<" + codes.GetState() + ">-<" + codes.GetZipCode() + ">.jpg";
                ss.SaveAsFile(screenshotName, ScreenshotImageFormat.Jpeg);
                driver.Navigate().Back();
            }
            
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}