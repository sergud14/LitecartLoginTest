namespace LitecartLoginTest
{
    public class AdminPage:BasePage
    {
        private readonly By imgMyStore = By.XPath("//img[@alt='My Store']");
        private readonly By tabName = By.XPath("//li");
        private readonly By tabHeader = By.XPath("//h1");
        private readonly By countriesTab = By.XPath("//span[text()='Countries']");
        private readonly By geoZonesTab = By.XPath("//span[text()='Geo Zones']");

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
                int count = driver.FindElements(By.XPath("//li[@id='app-']//span[contains(@class,'fa-stack')]")).Count();
                if (count > 0)
                {
                    for (int i = 1; i <= count; i++)
                    {
                        webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//li[@id='app-']//span[contains(@class,'fa-stack')])[" + i + "]"))).Click();
                        webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1")));
                        int count2 = driver.FindElements(By.XPath("//li[contains(@id,'doc')]")).Count();

                        if (count2 > 0)
                        {
                            for (int j = 1; j <= count2; j++)
                            {
                                webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//li[contains(@id,'doc')])[" + j + "]"))).Click();
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
        private bool CheckSort(string tableColumn, string attribute)
        {
            bool result = false;
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            try
            {
                var rows = driver.FindElements(By.XPath(tableColumn));
                string[] array = new string[rows.Count];
                string[] arraySorted = new string[rows.Count];

                for (int i = 0; i < rows.Count; i++)
                {
                    array[i] = driver.FindElement(By.XPath("(" + tableColumn + ")[" + (i + 1) + "]")).GetAttribute(attribute);
                    arraySorted[i] = array[i];
                    string ss = array[i];
                }

                Array.Sort(arraySorted);

                int j = 0;
                for (int k = 0; k < rows.Count; k++)
                {
                    if (array[k] != arraySorted[k])
                    {
                        j++;
                    }
                }

                if (j == 0)
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

        public bool CheckCountriesSort()
        {
            return CheckSort("//*[@class='row']//td[5]", "textContent");
        }

        public bool CheckZonesSort()
        {
            bool result = false;
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            try
            {
                var rows = driver.FindElements(By.XPath("//*[@class='row']//td[6]"));
                string[] countriesArray = new string[rows.Count];
                string[] countriesArraySorted = new string[rows.Count];
                List<By> rowZones = new List<By>();

                for (int i = 0; i < rows.Count; i++)
                {
                    By rowZone = By.XPath("(//*[@class='row']//td[6])[" + (i + 1) + "]");
                    string numberOfZones = driver.FindElement(rowZone).GetAttribute("textContent");
                    
                    if(numberOfZones != "0")
                    {
                      rowZones.Add(By.XPath("(//*[@class='row']//td[5])[" + (i + 1) + "]/a"));
                    }
                }

                int j = 0;
                foreach (By by in rowZones)
                {
                    webDriverWait.Until(ExpectedConditions.ElementIsVisible(by)).Click();
                    webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()=' Edit Country']")));
                    if (CheckSort("//input[contains(@name,'name')][contains(@type,'hidden')]//parent::td", "textContent") ==false)
                    {
                        j++;
                    }
                    webDriverWait.Until(ExpectedConditions.ElementIsVisible(countriesTab)).Click();
                    webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()=' Countries']")));
                }

                if (j == 0)
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

        public bool CheckGeoZonesSort()
        {
            bool result = false;
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            try
            {
                var rows = driver.FindElements(By.XPath("//*[@class='row']//td[3]/a"));
                List<By> rowCountries = new List<By>();

                for (int i = 0; i < rows.Count; i++)
                {
                    rowCountries.Add(By.XPath("(//*[@class='row']//td[3])[" + (i + 1) + "]/a"));
                }

                int j = 0;
                foreach (By by in rowCountries)
                {
                    webDriverWait.Until(ExpectedConditions.ElementIsVisible(by)).Click();
                    webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()=' Edit Geo Zone']")));
                    if (CheckSort("//select[contains(@name,'zone_code')]/option[@selected='selected']", "textContent") == false)
                    {
                        j++;
                    }
                    webDriverWait.Until(ExpectedConditions.ElementIsVisible(geoZonesTab)).Click();
                    webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()=' Geo Zones']")));
                }

                if (j == 0)
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

        public void GoToCountriesTab()
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(countriesTab)).Click();
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()=' Countries']")));
        }

        public void GoToGeoZonesTab()
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(geoZonesTab)).Click();
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()=' Geo Zones']")));
        }

        public bool IsLoaded()
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return (webDriverWait.Until(ExpectedConditions.ElementIsVisible(imgMyStore)) != null);
        }
    }
}
