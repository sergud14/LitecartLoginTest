using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LiteCart_pageobject
{ 
    public class ProductPage:BasePage
    {
        private IWebDriver driver;
        public ProductPage(IWebDriver driver):base(driver)
        {
            this.driver = driver;
        }

        public ProductPage AddProductToCart()
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement el = driver.FindElement(By.XPath("//span[@class='quantity']"));

            if (driver.FindElements(By.XPath("//select[@name='options[Size]']")).Count > 0)
            {
                SelectElement select = new SelectElement(driver.FindElement(By.XPath("//select[@name='options[Size]']")));
                select.SelectByIndex(1);
            }

            string ItemsCount1 = webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='quantity']"))).Text;
            webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@value='Add To Cart']"))).Click();
            if (webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='quantity'][text()='" + (Int32.Parse(ItemsCount1) + 1) + "']"))) == null)
            {
                return null;
            }
            else
            {
                return this;
            }
        }

        public MainPage GoToMainPage()
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@alt='My Store']"))).Click();
            return new MainPage(driver);
        }
    }
}
