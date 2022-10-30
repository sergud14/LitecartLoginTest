using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LiteCart_pageobject
{ 
   public class MainPage:BasePage
   {
        private IWebDriver driver;
        public MainPage(IWebDriver driver):base(driver)
        { 
         this.driver = driver;  
        }

        public ProductPage GoToProductPage(int productNumber)
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@class='image-wrapper'])["+ productNumber + "]"))).Click();
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1")));
            return new ProductPage(driver);
        }

        public CartPage GoToCartPage()
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@href='http://localhost/litecart/en/checkout'][@class='image']//img"))).Click();
            return new CartPage(driver);
        }

    }
}
