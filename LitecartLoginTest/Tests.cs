namespace LitecartLoginTest
{
    public class Tests:BaseTest
    {
        [Test, Order(1)]
        public void CheckStickers()
        {
            var loginPage = new LoginPage(driver);
            var mainPage = loginPage.EnterWithoutLogin();
            Assert.IsTrue(mainPage.CheckStickers());
        }

        [Test, Order(2)]
        public void CheckAdminPage()
        {
            var loginPage = new LoginPage(driver);
            var adminPage = loginPage.OpenAdminPage("admin", "admin");
            Assert.IsTrue(adminPage.CheckTabs());
        }

        [Test, Order(3)]
        public void CheckCountries()
        {
            var loginPage = new LoginPage(driver);
            var adminPage = loginPage.OpenAdminPage("admin", "admin");
            adminPage.GoToCountriesTab();
            Assert.IsTrue(adminPage.CheckCountriesSort());
        }

        [Test, Order(4)]
        public void CheckCountryZones()
        {
            var loginPage = new LoginPage(driver);
            var adminPage = loginPage.OpenAdminPage("admin", "admin");
            adminPage.GoToCountriesTab();
            Assert.IsTrue(adminPage.CheckZonesSort());
        }

        [Test, Order(5)]
        public void CheckGeoZones()
        {
            var loginPage = new LoginPage(driver);
            var adminPage = loginPage.OpenAdminPage("admin", "admin");
            adminPage.GoToGeoZonesTab();
            Assert.IsTrue(adminPage.CheckGeoZonesSort());
        }
    }
}