using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartParkingSystem.Test.Helpers;
using SmartParkingSystem.Test.Pages;
using System.Threading;

namespace SmartParkingSystem.Test.Tests
{
    [TestClass]
    public class ParkingLocation : BaseTest
    {
        private ParkingLocationPage _homescreenPage;

        [TestInitialize]
        public void TestInitialize()
        {
            _homescreenPage = new ParkingLocationPage(DriverHelper, BaseUrl);
        }

        [TestMethod]
        public void HomeScreenDisplayed()
        {
            Assert.IsTrue(_homescreenPage.TitleOnHomescreen.Displayed, 
                "Title on homescreen is not displayed, something went wrong!");
        }

        [TestMethod]
        public void MapMarkersShowPopupWithUsefullInformation()
        {
            var numberOfMapMarkers = _homescreenPage.MapMarkers.Count;
            Assert.IsTrue(numberOfMapMarkers > 0, "The map has no markers!");
            var randomMarkersIndex = Random.GetInteger(numberOfMapMarkers - 1);
            _homescreenPage.MapMarkers[randomMarkersIndex].Click();
            Thread.Sleep(3000);
            Assert.IsTrue(_homescreenPage.MapPopup.Displayed &&
                _homescreenPage.AvailableSpaces.Displayed &&
                _homescreenPage.AvailableSpacesForPeopleWithDisability.Displayed,
                "Popup with information about availability of parking spaces is not displayed!");
        }
    }
}
