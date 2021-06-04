using CheckFirst10TownsLocations.Utils;
using OpenQA.Selenium;

namespace CheckFirst10TownsLocations.Pages
{
    public class Search : Base
    {
        protected readonly By Advanced_Search = By.XPath("//h3[@id= 'ui-id-7']");
        protected readonly By Town = By.XPath("(//input[@name = 'fld-city' ])[last()]");
        protected readonly By Submit = By.XPath("(//input[@type= 'submit' and @value='Find ZIP Codes'])[last()]");

        public Search(IWebDriver driver) : base(driver)
        {
        }

        public void ClickAdvancedSearch()
        {
            driver.FindElement(Advanced_Search).Click();
        }

        public string PopulateTown(string name)
        {
            Wait.WaitForElementToBeClickable((By)Town);
            driver.FindElement(Town).SendKeys(name);
            return name;
        }

        public void ClickSubmit()
        {
            Wait.WaitForElementToBeClickable(Submit);
            driver.FindElement((By)Submit).Click();
        }
    }
}

