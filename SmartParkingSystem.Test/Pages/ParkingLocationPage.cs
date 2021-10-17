using OpenQA.Selenium;
using SmartParkingSystem.Test.Helpers;
using System.Collections.Generic;

namespace SmartParkingSystem.Test.Pages
{
    public class ParkingLocationPage : BasePage
    {
        public ParkingLocationPage(WebDriverHelper driverHelper, string baseUrl) : base(driverHelper, baseUrl) { }

        public IWebElement TitleOnHomescreen
        {
            get
            {
                var element = DriverHelper.WebDriver.FindElement(By.XPath("//h1[contains(., 'Smart Parking System')]"));
                DriverHelper.WebDriverWait.Until(_ => element.Displayed);
                return element;
            }
        }
        public IList<IWebElement> MapMarkers => DriverHelper.WebDriver.FindElements(By.XPath("//img[@class='leaflet-marker-icon leaflet-zoom-animated leaflet-interactive']"));
        public IWebElement MapPopup => DriverHelper.WebDriver.FindElement(By.XPath("//div[@class='leaflet-popup-content-wrapper']"));
        public IWebElement AvailableSpaces => DriverHelper.WebDriver.FindElement(By.XPath("//div[@class='mjestaDiv float-left']"));
        public IWebElement AvailableSpacesForPeopleWithDisability => DriverHelper.WebDriver.FindElement(By.XPath("//div[@class='mjestaDiv float-right']"));
        public IWebElement PopupButton => DriverHelper.WebDriver.FindElement(By.XPath("//div[@class='popupDiv']//button[contains(., 'Odaberi')]"));
    }
}
