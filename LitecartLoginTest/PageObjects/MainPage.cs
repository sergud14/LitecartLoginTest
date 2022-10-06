namespace LitecartLoginTest
{
    public class MainPage:BasePage
    {
        private readonly By headerCategories = By.XPath("//h3[text()='Categories']");
        private readonly By hrefRubberDucks = By.XPath("(//a[text()='Rubber Ducks'])[2]");
        private readonly By liProductItem = By.XPath("//li[contains(@class,'product')]");
        //private readonly By sticker = By.XPath(".//a[@title='Red Duck'][@class='link']");
        private readonly By sticker = By.XPath(".//div[contains(@class,'sticker')]");

        public MainPage(IWebDriver driver) : base(driver)
        {
            driver.Navigate().GoToUrl(@"http://localhost/litecart/en/");
        }

        public bool IsLoaded()
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return (webDriverWait.Until(ExpectedConditions.ElementIsVisible(headerCategories))!=null);
        }


        public bool CheckStickers()
        {
            try
            {
                List<IWebElement> list = driver.FindElements(liProductItem).ToList(); 
                int i = 0;
                foreach (IWebElement element in list)
                {
                    if (element.FindElements(sticker).Count!=1)
                    {
                        i++;
                    }
                }

                if (i==0)
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
