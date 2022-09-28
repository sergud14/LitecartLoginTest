namespace LitecartLoginTest
{
    public class Tests:BaseTest
    {
        [Test]
        public void LoginTest()
        { 
          var loginPage=new LoginPage(driver);
          loginPage.InsertUsername("testuser");
          loginPage.InsertPassword("p@ssword");
          loginPage.SelectCheckboxRememberMe();
          loginPage.Login();
        }
    }
}