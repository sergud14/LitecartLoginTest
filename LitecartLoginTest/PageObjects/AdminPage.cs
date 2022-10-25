namespace LitecartLoginTest
{
    public class AdminPage:BasePage
    {
        private readonly By imgMyStore = By.XPath("//img[@alt='My Store']");
        private readonly By tabName = By.XPath("//li");
        private readonly By tabHeader = By.XPath("//h1");
        private readonly By countriesTab = By.XPath("//span[text()='Countries']");
        private readonly By geoZonesTab = By.XPath("//span[text()='Geo Zones']");
        private readonly By catalogTab = By.XPath("//span[text()='Catalog']");

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

        public void CheckProductsInCatalog()
        {
            try
            {
                var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                driver.Navigate().GoToUrl(@"http://localhost/litecart/admin/?app=catalog&doc=catalog&category_id=1");
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()=' Catalog']")));
                int count = driver.FindElements(By.XPath("//tr[@class='row']//td//img/following-sibling::a")).Count();
                if (count > 0)
                {
                    ICollection<IWebElement> ss= driver.FindElements(By.XPath("//tr[@class='row']//td//img/following-sibling::a"));
                    for(int i=0;i<count;i++)
                    {
                        webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//tr[@class='row']//td//img/following-sibling::a)["+(i+1)+"]"))).Click();
                        foreach (LogEntry l in driver.Manage().Logs.GetLog(LogType.Browser))
                            {
                                Console.WriteLine(l);
                            }
                        webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[contains(text(),'Edit')]")));
                        driver.Navigate().GoToUrl(@"http://localhost/litecart/admin/?app=catalog&doc=catalog&category_id=1");
                        webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()=' Catalog']")));
                    }
                }
            }
            catch
            {
               
            }
        }

        public bool CheckNewProduct(Products product)
        {
            bool result = false;
            GoToCatalogTab();
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            if (webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@class='row']//td//a[not(contains(text(),'Root'))][not(contains(@title,'Edit'))][text()='" + product.Name + "']"))) != null)
            {
                result = true;
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

        public void GoToCountryCreationPage()
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='button']"))).Click();
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()=' Add New Country']")));
        }

        public void GoToCatalogTab()
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(catalogTab)).Click();
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()=' Catalog']")));
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


        public void AddNewProduct(Products product)
        {
            GoToCatalogTab();
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[text()=' Add New Product']"))).Click();
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[text()='General']")));
            //Вкладка General
            driver.FindElement(By.XPath("//label[text()=' "+product.Status+"']")).Click();
            driver.FindElement(By.Name("name[en]")).Click();
            driver.FindElement(By.Name("name[en]")).Clear();
            driver.FindElement(By.Name("name[en]")).SendKeys(product.Name);
            driver.FindElement(By.Name("code")).Click();
            driver.FindElement(By.Name("code")).Clear();
            driver.FindElement(By.Name("code")).SendKeys(product.Code);
            driver.FindElement(By.XPath("//input[@type='checkbox'][@data-name='"+product.Categories+"']")).Click();
            driver.FindElement(By.XPath("//td[text()='" + product.Gender + "']//preceding-sibling::td//input")).Click();
            driver.FindElement(By.Name("quantity")).Click();
            driver.FindElement(By.Name("quantity")).Clear();
            driver.FindElement(By.Name("quantity")).SendKeys(product.Quantity);
            SelectElement quantityUnit = new SelectElement(driver.FindElement(By.XPath("//select[@name='quantity_unit_id']")));
            quantityUnit.SelectByText(product.QuantityUnit);
            SelectElement deliveryStatus = new SelectElement(driver.FindElement(By.XPath("//select[@name='delivery_status_id']")));
            deliveryStatus.SelectByText(product.DeliveryStatus);
            SelectElement soldoutStatus = new SelectElement(driver.FindElement(By.XPath("//select[@name='sold_out_status_id']")));
            soldoutStatus.SelectByText(product.SoldOutStatus);
            driver.FindElement(By.XPath("//input[@type='file']")).SendKeys(product.Photo);
            SetDatepicker(driver, "[name=date_valid_from]", product.DateValidFrom);
            SetDatepicker(driver, "[name=date_valid_to]", product.DateValidTo);
            //Вкладка Information
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[text()='Information']"))).Click();
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//strong[text()='Manufacturer']")));
            new SelectElement(driver.FindElement(By.Name("manufacturer_id"))).SelectByText(product.Manufacturer);
            new SelectElement(driver.FindElement(By.Name("supplier_id"))).SelectByText(product.Supplier);
            driver.FindElement(By.Name("keywords")).Click();
            driver.FindElement(By.Name("keywords")).Clear();
            driver.FindElement(By.Name("keywords")).SendKeys(product.Keywords);
            driver.FindElement(By.Name("short_description[en]")).Click();
            driver.FindElement(By.Name("short_description[en]")).Clear();
            driver.FindElement(By.Name("short_description[en]")).SendKeys(product.ShortDescription);
            driver.FindElement(By.Name("description[en]")).Click();
            driver.FindElement(By.Name("description[en]")).Clear();
            driver.FindElement(By.Name("description[en]")).SendKeys(product.Description);
            driver.FindElement(By.Name("head_title[en]")).Click();
            driver.FindElement(By.Name("head_title[en]")).Clear();
            driver.FindElement(By.Name("head_title[en]")).SendKeys(product.HeadTitle);
            driver.FindElement(By.Name("meta_description[en]")).Click();
            driver.FindElement(By.Name("meta_description[en]")).Clear();
            driver.FindElement(By.Name("meta_description[en]")).SendKeys(product.MetaDescription);
            //Вкладка Price
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[text()='Prices']"))).Click();
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h2[text()='Prices']")));
            driver.FindElement(By.Name("purchase_price")).Click();
            driver.FindElement(By.Name("purchase_price")).Clear();
            driver.FindElement(By.Name("purchase_price")).SendKeys(product.PurchasePrice);
            new SelectElement(driver.FindElement(By.Name("purchase_price_currency_code"))).SelectByText(product.PurchasePriceCurrency);
            driver.FindElement(By.Name("prices[USD]")).Click();
            driver.FindElement(By.Name("prices[USD]")).Clear();
            driver.FindElement(By.Name("prices[USD]")).SendKeys(product.PriceUSD);
            driver.FindElement(By.Name("prices[EUR]")).Click();
            driver.FindElement(By.Name("prices[EUR]")).Clear();
            driver.FindElement(By.Name("prices[EUR]")).SendKeys(product.PriceEUR);
            driver.FindElement(By.Name("gross_prices[USD]")).Click();
            driver.FindElement(By.Name("gross_prices[USD]")).Clear();
            driver.FindElement(By.Name("gross_prices[USD]")).SendKeys(product.PriceInclUSD);
            driver.FindElement(By.Name("gross_prices[EUR]")).Click();
            driver.FindElement(By.Name("gross_prices[EUR]")).Clear();
            driver.FindElement(By.Name("gross_prices[EUR]")).SendKeys(product.PriceInclEUR);
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@name='save']"))).Click();
        }

        public void SetDatepicker(IWebDriver driver, string cssSelector, string date)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until<bool>(
                d => driver.FindElement(By.CssSelector(cssSelector)).Displayed);
            driver.FindElement(By.CssSelector(cssSelector)).SendKeys(date);
            driver.FindElement(By.CssSelector("body")).Click();
        }

        //    public void SetDatepicker(IWebDriver driver, string cssSelector, string date)
        //    {
        ////        new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until<bool>(
        ////d => driver.FindElement(By.CssSelector(cssSelector)).Displayed);
        ////        (driver as IJavaScriptExecutor).ExecuteScript(
        ////            String.Format("$('{0}').datepicker('setDate', '{1}')", cssSelector, date));
        //    }



        public bool OpenExternalLinks()
        {
            bool result = false;
            GoToCountriesTab();
            GoToCountryCreationPage();
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            try
            {
                var extLinks = driver.FindElements(By.XPath("//i[@class='fa fa-external-link']"));
                List<By> links = new List<By>();

                for (int i = 0; i < extLinks.Count; i++)
                {
                    links.Add(By.XPath("(//i[@class='fa fa-external-link'])["+(i+1)+"]"));
                }

                int j = 0;
                foreach (By by in links)
                {
                    string mainWindow = driver.CurrentWindowHandle;
                    webDriverWait.Until(ExpectedConditions.ElementIsVisible(by)).Click();
                    webDriverWait.Until(wd => wd.WindowHandles.Count == 2);

                    foreach (string window in driver.WindowHandles)
                    {
                        if (mainWindow != window)
                        {
                            webDriverWait.Until(d => d.SwitchTo().Window(window));
                            j++;
                            break;
                        }
                    }
                    driver.Close();
                    driver.SwitchTo().Window(mainWindow);
                }

                if (j == extLinks.Count)
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


    }
}
