using CheckFirst10TownsLocations.Utils;
using OpenQA.Selenium;

namespace CheckFirst10TownsLocations.Pages
{
    public class Base
    {
        readonly string google = "https://www.zip-codes.com/";
        protected static By Search = By.XPath("//a[@title = 'FREE ZIP Code Search']");

        public IWebDriver driver;
        private Wait wait;

        internal Wait Wait { get => wait; set => wait = value; }

        public Base(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new Wait(driver);
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(google);
        }

        public void ClickSearch()
        {
            driver.FindElement((By)Search).Click();
        }
    }
}

