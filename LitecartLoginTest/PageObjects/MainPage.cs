namespace LitecartLoginTest
{
    public class MainPage:BasePage
    {
        private readonly By headerCategories = By.XPath("//h3[text()='Categories']");
        private readonly By hrefRubberDucks = By.XPath("(//a[text()='Rubber Ducks'])[2]");
        private readonly By liProductItem = By.XPath("//li[contains(@class,'product')]");
        //private readonly By sticker = By.XPath(".//a[@title='Red Duck'][@class='link']");
        private readonly By sticker = By.XPath(".//div[contains(@class,'sticker')]");

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
    }
}
