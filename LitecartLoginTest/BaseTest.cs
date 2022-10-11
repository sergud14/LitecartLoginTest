namespace LitecartLoginTest
{
    public class BaseTest
    {
        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            //driver=new FirefoxDriver();

            //InternetExplorerOptions options = new InternetExplorerOptions();
            //options.IgnoreZoomLevel = true;
            //options.RequireWindowFocus = true;
            //options.IntroduceInstabilityByIgnoringProtectedModeSettings=true;
            //driver = new InternetExplorerDriver(options);

            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver = null;
        }
    }
}
