namespace LitecartLoginTest
{
    public class RubberDucksPage : BasePage
    {
        private readonly By header = By.XPath("//h1[text()='Rubber Ducks']");
        private readonly By hrefSubcategory = By.XPath("(//a[text()='Subcategory'])[2]");

        public RubberDucksPage(IWebDriver driver) : base(driver)
        {
            driver.Navigate().GoToUrl(@"http://localhost/litecart/en/rubber-ducks-c-1/");
        }

        public bool IsLoaded()
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return (webDriverWait.Until(ExpectedConditions.ElementIsVisible(header)) != null);
        }

        public SubcategoryPage OpenSubcategoryPage()
        {
            ClickButton(hrefSubcategory);
            var subcategoryPage = new SubcategoryPage(driver);
            if (subcategoryPage.IsLoaded())
            {
                return subcategoryPage;
            }
            else
            {
                return null;
            }
        }
    }
}
