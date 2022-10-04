namespace LitecartLoginTest
{
    public class SubcategoryPage : BasePage
    {
        private readonly By header = By.XPath("//h1[text()='Subcategory']");

        public SubcategoryPage(IWebDriver driver) : base(driver)
        {

        }

        public bool IsLoaded()
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return (webDriverWait.Until(ExpectedConditions.ElementIsVisible(header)) != null);
        }
    }
}
