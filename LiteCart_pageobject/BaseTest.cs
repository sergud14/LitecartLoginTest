using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace LiteCart_pageobject
{
    public class BaseTest
    {
        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver= new ChromeDriver();
            ChromeOptions options = new ChromeOptions();
            
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}