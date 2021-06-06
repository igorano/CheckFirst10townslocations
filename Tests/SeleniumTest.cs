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
        private IWebDriver driver;
        private BasePage basePage;
        private SearchPage searchPage;
        private TableWithTownsPage table;
        private ZipCodesPage codes;

        [SetUp]
        public void Init()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            this.driver = new ChromeDriver();
        }

        [Test]
        public void GetFirst10Results()
        {
            this.basePage = new BasePage(this.driver);
            this.searchPage = new SearchPage(this.driver);
            this.table = new TableWithTownsPage(this.driver);
            this.codes = new ZipCodesPage(this.driver);
            this.basePage.GoToPage();
            this.basePage.ClickSearch();
            this.searchPage.ClickAdvancedSearch();
            this.searchPage.PopulateTown("iva");
            this.searchPage.ClickSubmit();
            this.table.ClickFirstTown();

            for (int i = 0; i < 10; i++)
            {
                this.codes.GetLantitude();
                this.codes.GetCityName();
                this.codes.GetState();
                this.codes.GetZipCode();
                this.codes.GetLongitude();
                string url = "https://www.google.com/maps/search/?api=1&query=" + this.codes.GetLantitude() + "," + this.codes.GetLongitude();
                this.driver.Navigate().GoToUrl(url);
                Screenshot ss = ((ITakesScreenshot)this.driver).GetScreenshot();
                string screenshotName = "<" + this.codes.GetCityName() + ">-<" + this.codes.GetState() + ">-<" + this.codes.GetZipCode() + ">.jpg";
                ss.SaveAsFile(screenshotName, ScreenshotImageFormat.Jpeg);
                this.driver.Navigate().Back();
            }
        }

        [TearDown]
        public void Cleanup()
        {
            this.driver.Quit();
        }
    }
}