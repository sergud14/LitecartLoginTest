using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LiteCart_pageobject
{
    public class CartPage : BasePage
    {
        private IWebDriver driver;
        public CartPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public CartPage DeleteProductsFromCart()
        {
            int j = 0;
            bool result = false;

            try
            {
                var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                int count = driver.FindElements(By.XPath("//td[@class='item']")).Count;
                if (count > 0)
                {
                    for (int k = 0; k < count; k++)
                    {
                        string productName = driver.FindElement(By.XPath("(//td[@class='item'])[1]")).Text;
                        IWebElement el = driver.FindElement(By.XPath("//td[@class='item'][text()='" + productName + "']"));
                        webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//strong[text()='" + productName + "']//ancestor::p//following-sibling::p//button[@value='Remove']"))).Click();
                        webDriverWait.Until(ExpectedConditions.StalenessOf(el));

                        if (IsElementNotPresent(By.XPath("//td[@class='item'][text()='" + productName + "']")) == false)
                        {
                            j++;
                        }
                    }

                    if (j == 0)
                    {
                        result = true;
                    }
                }
            }
            catch
            {
                result = false;
            }

            if (result == false)
            {
                return null;
            }
            else
            {
                return this;
            }

            bool IsElementNotPresent(By locator)
            {
                try
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                    return driver.FindElements(locator).Count() == 0;
                }
                finally
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                }
            }

        }
    }
}
