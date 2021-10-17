using OpenQA.Selenium;
using SmartParkingSystem.Test.Helpers;

namespace SmartParkingSystem.Test.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(WebDriverHelper driver, string baseUrl) : base(driver, baseUrl)
        {
        }

        public IWebElement SignIn => DriverHelper.WebDriver.FindElement(By.XPath("//a[contains(., 'Sign in')]"));
        public IWebElement Username => DriverHelper.WebDriver.FindElement(By.Id("Username"));
        public IWebElement Password => DriverHelper.WebDriver.FindElement(By.Id("Password"));
        public IWebElement LoginButton => DriverHelper.WebDriver.FindElement(By.XPath("//input[@value='Logiraj se']"));
    }
}
