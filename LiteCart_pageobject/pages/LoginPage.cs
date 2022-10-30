using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace LiteCart_pageobject
{
    public class LoginPage:BasePage
    {
        private readonly By inputUsername = By.XPath("//input[@name='username']");
        private readonly By inputPassword = By.XPath("//input[@name='password']");
        private readonly By checkboxRememberMe = By.XPath("//input[@name='remember_me']");
        private readonly By buttonLogin = By.XPath("//button[@name='login']");
        private readonly By imgLitecart = By.XPath("//*[@alt='My Store']");

        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver):base(driver)
        { 
         this.driver = driver;
            driver.Navigate().GoToUrl(@"http://localhost/litecart/admin/login.php");
        }

        public MainPage EnterWithoutLogin()
        {
            ClickButton(imgLitecart);
            return new MainPage(driver);
        }

        public void InsertUsername(string username)
        {
            InsertTextInField(inputUsername, username);
        }

        public void InsertPassword(string password)
        {
            InsertTextInField(inputPassword, password);
        }
        public void SelectCheckboxRememberMe()
        {
            SelectCheckBox(checkboxRememberMe);
        }

    }
}
