﻿namespace LitecartLoginTest
{
    public class MainPage:BasePage
    {
        private readonly By headerCategories = By.XPath("//h3[text()='Categories']");
        private readonly By hrefRubberDucks = By.XPath("(//a[text()='Rubber Ducks'])[2]");
        private readonly By liProductItem = By.XPath("//li[contains(@class,'product')]");
        //private readonly By sticker = By.XPath(".//a[@title='Red Duck'][@class='link']");
        private readonly By sticker = By.XPath(".//div[contains(@class,'sticker')]");
        private readonly By stickerGreenDuck = By.XPath("//div[@id='box-most-popular']//img[@alt='Green Duck']");
        private readonly By stickerRedDuck = By.XPath("//div[@id='box-most-popular']//img[@alt='Red Duck']");
        private readonly By stickerPurpleDuck = By.XPath("//div[@id='box-most-popular']//img[@alt='Purple Duck']");


        public MainPage(IWebDriver driver) : base(driver)
        {
            driver.Navigate().GoToUrl(@"http://localhost/litecart/en/");
        }

        public bool IsLoaded()
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return (webDriverWait.Until(ExpectedConditions.ElementIsVisible(headerCategories))!=null);
        }

        public bool CheckAttributes()
        {
            bool result = false;
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            try
            {
                //получение параметров для карточки товара на главной странице
                string nameMainPage = driver.FindElement(By.XPath("//div[@id='box-campaigns']//li[1]/a[@class='link']")).GetAttribute("title");
                string regularpriceMainPage = driver.FindElement(By.XPath("//div[@id='box-campaigns']//li[1]//s[@class='regular-price']")).GetAttribute("textContent");
                string campaignpriceMainPage = driver.FindElement(By.XPath("//div[@id='box-campaigns']//li[1]//strong[@class='campaign-price']")).GetAttribute("textContent");
                string regularpriceTextDecorationMainPage = driver.FindElement(By.XPath("//div[@id='box-campaigns']//li[1]//s[@class='regular-price']")).GetCssValue("text-decoration-line");
                string campaignpriceFontWeightMainPage = driver.FindElement(By.XPath("//div[@id='box-campaigns']//li[1]//strong[@class='campaign-price']")).GetCssValue("font-weight");
                string regularpriceFontSizeMainPage = driver.FindElement(By.XPath("//div[@id='box-campaigns']//li[1]//s[@class='regular-price']")).GetCssValue("font-size");
                string campaignpriceFontSizeMainPage = driver.FindElement(By.XPath("//div[@id='box-campaigns']//li[1]//strong[@class='campaign-price']")).GetCssValue("font-size");
                string regularpriceColorMainPage = driver.FindElement(By.XPath("//div[@id='box-campaigns']//li[1]//s[@class='regular-price']")).GetCssValue("color");
                string campaignpriceColorMainPage = driver.FindElement(By.XPath("//div[@id='box-campaigns']//li[1]//strong[@class='campaign-price']")).GetCssValue("color");
                //переход на страницу товара
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='box-campaigns']//li[1]/a[@class='link']"))).Click();
                webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1")));
                //получение параметров для карточки товара на странице товара
                string nameGoodsPage = driver.FindElement(By.XPath("//h1")).GetAttribute("textContent");
                string regularpriceGoodsPage = driver.FindElement(By.XPath("//s[@class='regular-price']")).GetAttribute("textContent");
                string campaignpriceGoodsPage = driver.FindElement(By.XPath("//strong[@class='campaign-price']")).GetAttribute("textContent");
                string regularpriceTextDecorationGoodsPage = driver.FindElement(By.XPath("//s[@class='regular-price']")).GetCssValue("text-decoration-line");
                string campaignpriceFontWeightGoodsPage = driver.FindElement(By.XPath("//strong[@class='campaign-price']")).GetCssValue("font-weight");
                string regularpriceFontSizeGoodsPage = driver.FindElement(By.XPath("//s[@class='regular-price']")).GetCssValue("font-size");
                string campaignpriceFontSizeGoodsPage = driver.FindElement(By.XPath("//strong[@class='campaign-price']")).GetCssValue("font-size");
                string regularpriceColorGoodsPage = driver.FindElement(By.XPath("//s[@class='regular-price']")).GetCssValue("color");
                string campaignpriceColorGoodsPage = driver.FindElement(By.XPath("//strong[@class='campaign-price']")).GetCssValue("color");
                //проверка совпадаения названия и цен товара на главной странице и странице товара
                bool checkNames = CheckEquality(nameMainPage, nameGoodsPage);
                bool checkRegularprice = CheckEquality(regularpriceMainPage, regularpriceGoodsPage);
                bool checkCampaignprice = CheckEquality(campaignpriceMainPage, campaignpriceGoodsPage);
                //проверка необходимых параметров форматирования цен на главной странице
                bool checkRegularpriceTextDecorationMainPage = CheckEquality("line-through", regularpriceTextDecorationMainPage);
                bool checkRegularpriceColorMainPage = CheckEquality(FindColor(regularpriceColorMainPage), "Grey");
                bool checkCampaignpriceFontWeightMainPage = IsFontBold(campaignpriceFontWeightMainPage);
                bool checkCampaignpriceColorMainPage = CheckEquality(FindColor(campaignpriceColorMainPage), "Red");
                bool checkPricesForntSizesMainPage = CompareFontSize(regularpriceFontSizeMainPage, campaignpriceFontSizeMainPage);
                //проверка необходимых параметров форматирования цен на странице товара
                bool checkRegularpriceTextDecorationGoodsPage = CheckEquality("line-through", regularpriceTextDecorationGoodsPage);
                bool checkRegularpriceColorGoodsPage = CheckEquality(FindColor(regularpriceColorGoodsPage), "Grey");
                bool checkCampaignpriceFontWeightGoodsPage = IsFontBold(campaignpriceFontWeightGoodsPage);
                bool checkCampaignpriceColorGoodsPage = CheckEquality(FindColor(campaignpriceColorGoodsPage), "Red");
                bool checkPricesForntSizesGoodsPage = CompareFontSize(regularpriceFontSizeGoodsPage, campaignpriceFontSizeGoodsPage);

                //результирующая проверка
                if (checkNames 
                    && checkRegularprice 
                    && checkCampaignprice
                    && checkCampaignprice
                    && checkRegularpriceTextDecorationMainPage
                    && checkRegularpriceColorMainPage
                    && checkCampaignpriceFontWeightMainPage
                    && checkCampaignpriceColorMainPage
                    && checkPricesForntSizesMainPage
                    && checkRegularpriceTextDecorationGoodsPage
                    && checkRegularpriceColorGoodsPage
                    && checkCampaignpriceFontWeightGoodsPage
                    && checkCampaignpriceColorGoodsPage
                    && checkPricesForntSizesGoodsPage)
                {
                    result = true;
                }
           
                //ниже - вспомогательные методы
                bool CheckEquality(string expected,string fact)
                {
                    if (expected == fact)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                bool ComparePrices(string regularprice, string campaignprice)
                {
                    double rP = Convert.ToDouble(regularprice.Trim(new char[] { '$' }));
                    double cP = Convert.ToDouble(campaignprice.Trim(new char[] { '$' }));

                    if (cP < rP)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                bool CompareFontSize(string regularpriceFontSize, string campaignpriceFontSize)
                {

                    string ss = regularpriceFontSize.Trim(new char[] { 'p', 'x' }).Replace(".", ",");
                    string ss2 = campaignpriceFontSize.Trim(new char[] { 'p', 'x' }).Replace(".", ",");
                    double rP = Convert.ToDouble(ss);
                    double cP = Convert.ToDouble(ss2);

                    if (cP > rP)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


                bool IsFontBold(string fontSize)
                {

                    if (Convert.ToInt32(fontSize)>=700)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


                string FindColor(string rgbColor)
                {
                    string color="";
                    String[] numbers;

                    if (rgbColor.Substring(0,4)== "rgba")
                    {
                       numbers = rgbColor.Replace("rgba(", "").Replace(")", "").Split(",");
                    }
                    else
                    {
                        numbers = rgbColor.Replace("rgb(", "").Replace(")", "").Split(",");
                    }

                    //String[] numbers = rgbColor.Replace("rgba(", "").Replace(")", "").Split(",");
                    int r =int.Parse(numbers[0].Trim());
                    int g = int.Parse(numbers[1].Trim());
                    int b = int.Parse(numbers[2].Trim());

                    if (r == g&& g==b)
                    {
                        color = "Grey";
                    }
                    else 
                    {
                        if(g == 0 &&  b==0)
                        {
                            color = "Red";
                        }
                    }

                    return color;
                }
            }
            catch 
            {
                result = false;
            }

            return result;
        }


        public bool CheckStickers()
        {
            try
            {
                List<IWebElement> list = driver.FindElements(liProductItem).ToList(); 
                int i = 0;
                foreach (IWebElement element in list)
                {
                    if (element.FindElements(sticker).Count!=1)
                    {
                        i++;
                    }
                }

                if (i==0)
                {
                    return true;    
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public void GoToMainPage()
        {
            driver.Navigate().GoToUrl(@"http://localhost/litecart/en/");
        }

        public void GoToCart()
        {
            driver.Navigate().GoToUrl(@"http://localhost/litecart/en/checkout");
        }


        public void GoToCreateAccountPage()
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("New customers click here"))).Click();
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()='Create Account']")));
        }

        public void Logout()
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//a[text()='Logout'])[1]"))).Click();
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Name("login")));
        }

        public void LogIn(Customers customer)
        {
            GoToMainPage();
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(customer.Email);
            driver.FindElement(By.Name("password")).Click();
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(customer.Password);
            driver.FindElement(By.Name("login")).Click();
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//a[text()='Logout'])[1]")));
        }


        public void SelectCountry()
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(@class,'select2')][@dir='ltr']"))).Click();
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[@role='treeitem'][text()='United States']"))).Click();
        }

        public void SelectZone()
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//select[@name='zone_code']"))).Click();
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//option[text()='Florida']"))).Click();
        }


        public void AddNewCustomer(Customers customer)
        {
            GoToCreateAccountPage();
            driver.FindElement(By.Name("tax_id")).Click();
            driver.FindElement(By.Name("tax_id")).Clear();
            driver.FindElement(By.Name("tax_id")).SendKeys(customer.TaxId);
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(customer.Company);
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(customer.FirstName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(customer.LastName);
            driver.FindElement(By.Name("address1")).Click();
            driver.FindElement(By.Name("address1")).Clear();
            driver.FindElement(By.Name("address1")).SendKeys(customer.Address1);
            driver.FindElement(By.Name("address2")).Click();
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(customer.Address2);
            driver.FindElement(By.Name("postcode")).Click();
            driver.FindElement(By.Name("postcode")).Clear();
            driver.FindElement(By.Name("postcode")).SendKeys(customer.Postcode);
            driver.FindElement(By.Name("city")).Click();
            driver.FindElement(By.Name("city")).Clear();
            driver.FindElement(By.Name("city")).SendKeys(customer.City);
            SelectCountry();
            SelectZone();
            //SelectElement country = new SelectElement(driver.FindElement(By.XPath("//select[@name='country_code']")));
            //country.SelectByText(customer.Country);
            //SelectElement zone = new SelectElement(driver.FindElement(By.XPath("//select[@name='zone_code']")));
            //zone.SelectByText(customer.Zone);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(customer.Email);
            driver.FindElement(By.Name("phone")).Click();
            driver.FindElement(By.Name("phone")).Clear();
            driver.FindElement(By.Name("phone")).SendKeys(customer.Phone);
            driver.FindElement(By.Name("password")).Click();
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(customer.Password);
            driver.FindElement(By.Name("confirmed_password")).Click();
            driver.FindElement(By.Name("confirmed_password")).Clear();
            driver.FindElement(By.Name("confirmed_password")).SendKeys(customer.Password);
            driver.FindElement(By.Name("create_account")).Click();
        }
        //public bool AddProductToCart(Products product)
        //{
        //    bool result = false;
        //    GoToMainPage();
        //    var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        //    webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='box-most-popular']//img[@alt='"+product.Name+"']"))).Click();
        //    webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()='"+product.Name+"']")));
        //    string ItemsCount1 = webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='quantity']"))).Text;
        //    webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@value='Add To Cart']"))).Click();
        //    string ItemsCount2 = webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='quantity']"))).Text;
        //    GoToMainPage();

        //    if (Int32.Parse(ItemsCount1) < Int32.Parse(ItemsCount2))
        //    {
        //        result = true;
        //    }
        //    else 
        //    {
        //        result = false;
        //    }
        //    return result;
        //}

        public bool AddProductToCart(int countOfProducts)
        {
            int j = 0;
            bool result = false;

            try

            {
                for (int i = 1; i <= countOfProducts; i++)
                {
                    GoToMainPage();
                    var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                    webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@id='box-most-popular']//div[@class='image-wrapper'])[1]"))).Click();
                    webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1")));
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
                        j++;
                    }
                }
            }
            catch 
            {
                result = false;
            }

            if (j > 0)
            {
                result = false;
            }
            return result;
        }



        public bool DeleteProductsFromCart()
        {
            int j = 0;
            bool result = false;

            try
            {
                    GoToCart();
                    var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                    int count = driver.FindElements(By.XPath("//td[@class='item']")).Count;
                    if (count > 0)
                    {
                        for (int k=0; k < count; k++)
                        {
                            string productName = driver.FindElement(By.XPath("(//td[@class='item'])[1]")).Text;
                            IWebElement el = driver.FindElement(By.XPath("//td[@class='item'][text()='"+productName+"']"));
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

            return result;
        }


        //public bool DeleteProductsFromCart(int countOfProducts)
        //{
        //    int j = 0;
        //    bool result = false;

        //    try
        //    {
        //        for (int i = 1; i <= countOfProducts; i++)
        //        {
        //            GoToCart();
        //            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

        //            if (driver.FindElements(By.XPath("//td[@class='item']")).Count > 0)
        //            {
        //                int count1 = driver.FindElements(By.XPath("//td[@class='item']")).Count;
        //                webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@name='remove_cart_item']"))).Click();
        //                int count2 = driver.FindElements(By.XPath("//td[@class='item']")).Count;

        //                if (count2 > count1)
        //                {
        //                    j++;
        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        result = false;
        //    }

        //    if (j > 0)
        //    {
        //        result = false;
        //    }
        //    return result;
        //}



        //public bool DeleteProductFromCart(Products product)
        //{
        //    bool result = false;
        //    GoToCart();
        //    var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        //    //IWebElement productRow= driver.FindElement(By.XPath("//td[@class='item'][text()='"+product.Name+"']"));
        //    webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//strong[text()='"+product.Name+"']//ancestor::p//following-sibling::p[3]//button"))).Click();
        //    if (IsElementNotPresent(By.XPath("//td[@class='item'][text()='" + product.Name + "']")))
        //    {
        //        result = true;
        //    }

        //    return result;
        //}
        private bool IsElementNotPresent(By locator)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(2);
                return driver.FindElements(locator).Count() == 0;    
            }
            finally
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
        }
    }
}
