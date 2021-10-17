using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartParkingSystem.Test.Helpers;
using SmartParkingSystem.Test.Pages;
using System.Threading.Tasks;

namespace SmartParkingSystem.Test
{
    [TestClass]
    public class BaseTest
    {
        public TestContext TestContext { get; set; }
        protected WebDriverHelper DriverHelper;
        protected static TestContext ClassContext;
        protected static string BaseUrl;
        private ParkingLocationPage HomePage;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext classContext)
        {
            ClassContext = classContext;
            BaseUrl = ClassContext.Properties["BaseUrl"].ToString();    
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
        }

        [TestInitialize]
        public void BaseTestInitializ()
        {
            DriverHelper = new WebDriverHelper(ClassContext.Properties["Browser"].ToString());
            HomePage = new ParkingLocationPage(DriverHelper, BaseUrl);
            HomePage.NavigateToPage();
            Task.Delay(3000).Wait();
        }

        [TestCleanup]
        public void BaseTestCleanup()
        {
            DriverHelper.WebDriver.Quit();
        }
    }   
}
