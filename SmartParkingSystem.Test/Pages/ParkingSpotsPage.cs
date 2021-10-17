using OpenQA.Selenium;
using SmartParkingSystem.Test.Helpers;
using System.Collections.Generic;

namespace SmartParkingSystem.Test.Pages
{
    public class ParkingSpotsPage : BasePage
    {
        public ParkingSpotsPage(WebDriverHelper driver, string baseUrl) : base(driver, baseUrl)
        {
        }

        public IWebElement AvailableSpaces => DriverHelper.WebDriver.FindElement(By.Id("idSlobodni"));
        public IWebElement AvailableSpacesForPeopleWithDisability => DriverHelper.WebDriver.FindElement(By.Id("idSlobodniOSI"));
        public IWebElement ParkingPlaceImg => DriverHelper.WebDriver.FindElement(By.XPath("//div[@class='c-of-img center-img']//img"));
        public IList<IWebElement> GreenSpots => DriverHelper.WebDriver.FindElements(By.XPath("//img[@src='/images/green.png']"));
        public IList<IWebElement> OSISpots => DriverHelper.WebDriver.FindElements(By.XPath("//img[@src='/images/disabled.png']"));
    }
}
