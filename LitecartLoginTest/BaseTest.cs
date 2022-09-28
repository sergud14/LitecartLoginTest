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
        }

        [OneTimeTearDown]
        public void Test1()
        {
            driver.Quit();
            driver = null;
        }
    }
}
