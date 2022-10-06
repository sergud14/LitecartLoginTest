namespace LitecartLoginTest
{
    public class Tests:BaseTest
    {
        [Test, Order(1)]
        public void EnterWithoutLogin()
        {
            var loginPage = new LoginPage(driver);
            Assert.NotNull(loginPage.EnterWithoutLogin());
        }

        [Test, Order(2)]
        public void CheckStickers()
        {
            var mainPage = new MainPage(driver);
            Assert.IsTrue(mainPage.CheckStickers());
        }

        [Test, Order(3)]
        public void GoToAdminPage()
        {
            var loginPage = new LoginPage(driver);
            Assert.NotNull(loginPage.OpenAdminPage("admin","admin"));
        }

        [Test, Order(4)]
        public void CheckAdminPageTabs()
        {
            var adminPage = new AdminPage(driver);
            List<string> listTabNames=new List<string>() { "Appearence","Template","Logotype", "Catalog", "Product Groups" ,"Option Groups", "Manufacturers", "Suppliers", "Delivery Statuses", "Sold Out Statuses", "Quantity Units", "CSV Import/Export", "Countries", "Currencies", "Customers", "CSV Import/Export", "Newsletter", "Geo Zones", "Languages", "Storage Encoding", "Modules", "Background Jobs", "Customer", "Shipping", "Payment", "Order Total", "Order Success", "Order Action", "Orders", "Order Statuses", "Pages","Reports","Monthly Sales", "Most Sold Products", "Most Shopping Customers", "Settings", "Store Info", "Defaults", "General", "Listings", "Images", "Checkout", "Advanced", "Security", "Slides","Tax", "Tax Classes", "Tax Rates", "Translations", "Search Translations", "Scan Files", "CSV Import/Export", "Users", "vQmods" };
            List<string> listTabHeaders = new List<string>() { "Template", "Template", "Logotype", "Catalog", "Product Groups", "Option Groups", "Manufacturers", "Suppliers", "Delivery Statuses", "Sold Out Statuses", "Quantity Units", "CSV Import/Export", "Countries", "Currencies", "Customers", "CSV Import/Export", "Newsletter", "Geo Zones", "Languages", "Storage Encoding", "Job Modules", "Job Modules", "Customer Modules", "Shipping Modules", "Payment Modules", "Order Total Modules", "Order Success Modules", "Order Action Modules", "Orders", "Order Statuses", "Pages", "Monthly Sales", "Monthly Sales", "Most Sold Products", "Most Shopping Customers", "Settings", "Settings", "Settings", "Settings", "Settings", "Settings", "Settings", "Settings", "Settings", "Slides", "Tax Classes", "Tax Classes", "Tax Rates", "Search Translations", "Search Translations", "Scan Files For Translations", "CSV Import/Export", "Users", "vQmods" };
            Assert.IsTrue(adminPage.CheckTabs(listTabNames,listTabHeaders));
        }

    }
}