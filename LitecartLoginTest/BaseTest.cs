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
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            //options.AddArgument("w3c:false");
            options.AddArgument("--start-maximized");
            //options.AddArgument("--enable-logging");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver = null;
        }
    }
}
