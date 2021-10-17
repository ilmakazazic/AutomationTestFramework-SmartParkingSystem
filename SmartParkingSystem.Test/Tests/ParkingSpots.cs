using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartParkingSystem.Test.Helpers;
using SmartParkingSystem.Test.Pages;
using System.Threading;

namespace SmartParkingSystem.Test.Tests
{
    [TestClass]
    public class ParkingSpots : BaseTest
    {
        private ParkingLocationPage _homescreenPage;
        private ParkingSpotsPage _parkingSpotsPage;

        [TestInitialize]
        public void TestInitialize()
        {
            _homescreenPage = new ParkingLocationPage(DriverHelper, BaseUrl);
            _parkingSpotsPage = new ParkingSpotsPage(DriverHelper, BaseUrl);
        }

        [TestMethod]
        public void AvailableParkingSpotsDisplayed()
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
            _homescreenPage.PopupButton.Click();
            Assert.IsTrue(_parkingSpotsPage.AvailableSpaces.Displayed &&
                _parkingSpotsPage.AvailableSpacesForPeopleWithDisability.Displayed &&
                _parkingSpotsPage.ParkingPlaceImg.Displayed, "Parking location is not displayed corretly!");
        }

        [TestMethod]
        public void AvailableParkingSpotsEquality()
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
            _homescreenPage.PopupButton.Click();
            var availableParkingSpotsNumber = _parkingSpotsPage.AvailableSpaces.Text.Substring(0, 1); 
            var availableParkingSpotsOSINumber = _parkingSpotsPage.AvailableSpacesForPeopleWithDisability.Text.Substring(0, 1);
            var availableParkingSpotsNumberOnLocation = _parkingSpotsPage.GreenSpots.Count;
            var availableParkingSpotsNumberOSIOnLocation = _parkingSpotsPage.OSISpots.Count;
            Assert.AreEqual(int.Parse(availableParkingSpotsNumber), availableParkingSpotsNumberOnLocation,
                "The numbers of available parking spots are not the same!");
            Assert.AreEqual(int.Parse(availableParkingSpotsOSINumber), availableParkingSpotsNumberOSIOnLocation,
                "The numbers of available parking spots are not the same!");
        }
    }
}
