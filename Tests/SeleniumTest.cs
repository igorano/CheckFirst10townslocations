namespace CheckFirst10TownsLocations
{
    using CheckFirst10TownsLocations.Pages;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using WebDriverManager;
    using WebDriverManager.DriverConfigs.Impl;
    using WebDriverManager.Helpers;

    public class SeleniumTest
    {
        public IWebDriver Driver;
        BasePage basePage;
        SearchPage search_page;
        TableWithTownsPage table;
        ZipCodesPage codes; 

        [SetUp]
        public void Init()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            Driver = new ChromeDriver();
        }

        [Test]
        public void GetFirst10Results()
        {
            basePage = new BasePage(Driver);
            search_page = new SearchPage(Driver);
            table = new TableWithTownsPage(Driver);
            codes = new ZipCodesPage(Driver);
            base_page.GoToPage();
            base_page.ClickSearch();
            search_page.ClickAdvancedSearch();
            search_page.PopulateTown("iva");
            search_page.ClickSubmit();
            table.ClickFirstTown();

            for (int i=0; i < 10; i++)
            {
                codes.GetLantitude();
                codes.GetCityName();
                codes.GetState();
                codes.GetZipCode();
                codes.GetLongitude();
                string url = "https://www.google.com/maps/search/?api=1&query=" + codes.GetLantitude() + "," + codes.GetLongitude();
                Driver.Navigate().GoToUrl(url);
                Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
                string screenshotName = "<" + codes.GetCityName() + ">-<" + codes.GetState() + ">-<" + codes.GetZipCode() + ">.jpg";
                ss.SaveAsFile(screenshotName, ScreenshotImageFormat.Jpeg);
                Driver.Navigate().Back();
            }
        }

        [TearDown]
        public void Cleanup()
        {
            Driver.Quit();
        }
    }
}