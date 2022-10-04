namespace LitecartLoginTest
{
    public class LoginPage:BasePage
    {
        private readonly By inputUsername = By.XPath("//input[@name='username']");
        private readonly By inputPassword = By.XPath("//input[@name='password']");
        private readonly By checkboxRememberMe = By.XPath("//input[@name='remember_me']");
        private readonly By buttonLogin = By.XPath("//button[@name='login']");
        private readonly By imgLitecart = By.XPath("//*[@alt='My Store']");

        public LoginPage(IWebDriver driver):base(driver)
        {
            driver.Navigate().GoToUrl(@"http://localhost/litecart/admin/");
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

        public void Login()
        {
            ClickButton(buttonLogin);
        }

        public MainPage EnterWithoutLogin()
        {
            ClickButton(imgLitecart);
            var mainPage = new MainPage(driver);
            if (mainPage.IsLoaded())
            {
              return mainPage;
            }
            else
            {
              return null;
            }
        }
    }
}
