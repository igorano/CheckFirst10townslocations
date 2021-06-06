// <copyright file="SeleniumTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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
        private ZipCodesPage codes;

        [SetUp]
        public void Init()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
        }

        [Test]
        public void GetFirst10Results()
        {
            this.basePage = new BasePage(this.driver);
            this.searchPage = new SearchPage(this.driver);
            this.codes = new ZipCodesPage(this.driver);
            this.basePage.GoToPage();
            this.basePage.ClickSearch();
            this.searchPage.ClickAdvancedSearch();
            this.searchPage.PopulateTown("iva");
            this.searchPage.ClickSubmit();
            this.codes.TakeScreenshots();
        }

        [TearDown]
        public void Cleanup()
        {
            this.driver.Quit();
        }
    }
}