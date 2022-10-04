namespace LitecartLoginTest
{
    public class MainPage:BasePage
    {
        private readonly By headerCategories = By.XPath("//h3[text()='Categories']");
        private readonly By hrefRubberDucks = By.XPath("(//a[text()='Rubber Ducks'])[2]");
        private readonly By stickers = By.XPath("//li//div[contains(@class,'sticker')]");

        public MainPage(IWebDriver driver) : base(driver)
        {
            driver.Navigate().GoToUrl(@"http://localhost/litecart/en/");
        }

        public bool IsLoaded()
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return (webDriverWait.Until(ExpectedConditions.ElementIsVisible(headerCategories))!=null);
        }

        public RubberDucksPage OpenRubberDucksPage()
        {
            ClickButton(hrefRubberDucks);
            var rubberDucksPage = new RubberDucksPage(driver);
            if (rubberDucksPage.IsLoaded())
            {
                return rubberDucksPage;
            }
            else
            {
                return null;
            }
        }

        public bool CheckStickers(int count)
        {
            try
            {
                if (driver.FindElements(stickers).Count() == count)
                {
                    return true;    
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
