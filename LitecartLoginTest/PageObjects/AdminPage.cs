namespace LitecartLoginTest
{
    public class AdminPage:BasePage
    {
        private readonly By imgMyStore = By.XPath("//img[@alt='My Store']");
        private readonly By tabName = By.XPath("//li");
        private readonly By tabHeader = By.XPath("//h1");

        public AdminPage(IWebDriver driver) : base(driver)
        {

        }

        public bool CheckTabs(List<string> tabName, List<string> tabHeader)
        {
            bool result = false;
            try
            {
                int j = 0;
                var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                for (int i = 0; i < tabName.Count; i++)
                {
                    By byTabName = By.XPath("//span[@class='name'][text()='" + tabName[i] + "']");
                    By byTabHeader = By.XPath("//h1[contains(text(),'" + tabHeader[i] + "')]");
                    webDriverWait.Until(ExpectedConditions.ElementIsVisible(byTabName)).Click();

                    if (webDriverWait.Until(ExpectedConditions.ElementIsVisible(byTabHeader)) == null)
                    {
                        j++;
                    }
                }

                if (j>0)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public bool CheckTabs()
        {
            bool result = false;
            try
            {
                var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                int count = driver.FindElements(By.XPath("//span[contains(@class,'fa-stack')]")).Count();
                if (count > 0)
                {
                    for (int i = 1; i <= count; i++)
                    {
                        webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//span[contains(@class,'fa-stack')])[" + i + "]"))).Click();
                        webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1")));
                        int count2 = driver.FindElements(By.XPath("//li//li")).Count();

                        if (count2 > 0)
                        {
                            for (int j = 1; j <= count2; j++)
                            {
                                webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li//li[" + j + "]"))).Click();
                                webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1")));
                            }
                        }
                    }
                    result = true;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public bool IsLoaded()
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return (webDriverWait.Until(ExpectedConditions.ElementIsVisible(imgMyStore)) != null);
        }
    }
}
