namespace LitecartLoginTest
{
    public class AdminPage:BasePage
    {
        private readonly By imgMyStore = By.XPath("//img[@alt='My Store']");


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

        public bool IsLoaded()
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return (webDriverWait.Until(ExpectedConditions.ElementIsVisible(imgMyStore)) != null);
        }
    }
}
