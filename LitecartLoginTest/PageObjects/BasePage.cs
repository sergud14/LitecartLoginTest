namespace LitecartLoginTest
{
    public class BasePage
    {
        IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;   
        }

        protected void InsertTextInField(By field, string text)
        {
            var webDriverWait = new WebDriverWait(driver,TimeSpan.FromSeconds(15));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(field)).SendKeys(text);
        }

        protected void ClickButton(By button)
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(button)).Click();
        }

        protected void SelectCheckBox(By checkbox)
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(checkbox)).Click();
        }
    }
}
