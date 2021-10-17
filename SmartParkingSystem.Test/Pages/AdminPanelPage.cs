using OpenQA.Selenium;
using SmartParkingSystem.Test.Helpers;


namespace SmartParkingSystem.Test.Pages
{
    public class AdminPanelPage : BasePage
    {
        public AdminPanelPage(WebDriverHelper driver, string baseUrl) : base(driver, baseUrl)
        {
        }

        public IWebElement AdminPanelHeader => DriverHelper.WebDriver.FindElement(By.XPath("//h1[contains(.,'admin panel')]"));
    }
}
