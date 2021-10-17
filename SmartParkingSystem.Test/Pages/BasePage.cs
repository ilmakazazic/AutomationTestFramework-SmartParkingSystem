using SmartParkingSystem.Test.Helpers;

namespace SmartParkingSystem.Test.Pages
{
    public abstract class BasePage
    {
        protected readonly WebDriverHelper DriverHelper;
        protected readonly string BaseUrl;

        protected BasePage(WebDriverHelper driver, string baseUrl)
        {
            DriverHelper = driver;
            BaseUrl = baseUrl;
        }

        public void NavigateToPage(string location = "")
        {
            DriverHelper.WebDriver.Navigate().GoToUrl(BaseUrl + location);
        }

        public void RefreshPage()
        {
            DriverHelper.WebDriver.Navigate().Refresh();
        }
    }
}
