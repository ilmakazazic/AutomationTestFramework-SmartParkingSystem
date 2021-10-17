using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;

namespace SmartParkingSystem.Test.Helpers
{
    public enum WebDriverType
    {
        Chrome,
        Mozilla,
        Safari,
        Edge,
        Ie
    }

    public class WebDriverHelper
    {
        private readonly double _implicitWaitTimeout;
        private readonly double _pageLoadTimeout;
        public IWebDriver WebDriver;
        public WebDriverWait WebDriverWait;
        public WebDriverType DriverType;

        /// <summary>
        /// Helper class to create WebDriver instance with its essentials
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="implicitWaitTimeout">in seconds</param>
        /// <param name="pageLoadTimeout">in seconds</param>
        public WebDriverHelper(string browser = "Chrome", double implicitWaitTimeout = 30, double pageLoadTimeout = 30)
        {
            _implicitWaitTimeout = implicitWaitTimeout;
            _pageLoadTimeout = pageLoadTimeout;
            Enum.TryParse(browser, true, out DriverType);
            SetWebDriver();
            SetWebDriverWait(implicitWaitTimeout);
        }

        private void SetWebDriver()
        {
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("headless");
            chromeOptions.AddArgument("no-sandbox");
            WebDriver = DriverType switch
            {
                WebDriverType.Edge => new EdgeDriver(new EdgeOptions()),
                _ => new ChromeDriver(@"C:\WebDriver\bin")
            };
            WebDriver.Manage().Window.Maximize();

            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_implicitWaitTimeout);
            WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(_pageLoadTimeout);
            WebDriver.Manage().Window.Maximize();
        }

        private void SetWebDriverWait(double timeout)
        {
            WebDriverWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeout));
        }
    }
}
