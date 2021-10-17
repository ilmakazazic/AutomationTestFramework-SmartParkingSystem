using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartParkingSystem.Test.Pages;

namespace SmartParkingSystem.Test.Tests
{
    [TestClass]
    public class Login : BaseTest
    {
        private LoginPage _loginPage;
        private AdminPanelPage _adminPanelPage;

        [TestInitialize]
        public void TestInitialize()
        {
            _loginPage = new LoginPage(DriverHelper, BaseUrl);
            _adminPanelPage = new AdminPanelPage(DriverHelper, BaseUrl);
        }

        [TestMethod]
        [DataRow("admin", "test")]
        [DataRow("random", "test")]
        public void SignIn(string username, string password)
        {
            _loginPage.SignIn.Click();
            _loginPage.Username.SendKeys(username);
            _loginPage.Password.SendKeys(password);
            _loginPage.LoginButton.Click();
            Assert.IsTrue(_adminPanelPage.AdminPanelHeader.Displayed, "Failed to login!");
        }

    }
}
