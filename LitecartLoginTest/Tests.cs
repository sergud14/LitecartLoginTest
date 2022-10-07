namespace LitecartLoginTest
{
    public class Tests:BaseTest
    {
        [Test, Order(1)]
        public void CheckStickers()
        {
            var loginPage = new LoginPage(driver);
            var mainPage=loginPage.EnterWithoutLogin();
            Assert.IsTrue(mainPage.CheckStickers());
        }

        [Test, Order(2)]
        public void CheckAdminPage()
        {
            var loginPage = new LoginPage(driver);
            var adminPage = loginPage.OpenAdminPage("admin", "admin");
            Assert.IsTrue(adminPage.CheckTabs());
        }
    }
}