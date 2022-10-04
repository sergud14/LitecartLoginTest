namespace LitecartLoginTest
{
    public class BaseTest
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [OneTimeTearDown]
        public void Test1()
        {
            driver.Quit();
            driver = null;
        }
    }
}
