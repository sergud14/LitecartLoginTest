using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace LiteCart_pageobject
{
    public class AssertHelper
    {
        private IWebDriver driver;

        public AssertHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool CheckCountOfProductsInCart(int count)
        {
            driver.Navigate().GoToUrl(@"http://localhost/litecart/en/");
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            int countFact=Convert.ToInt32(webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='quantity']"))).GetAttribute("textContent").Trim());
            return (countFact == count);
        }
    }

}
