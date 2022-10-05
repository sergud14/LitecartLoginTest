namespace LitecartLoginTest
{
    public class Tests:BaseTest
    {
        [Test, Order(1)]
        public void EnterWithoutLogin()
        { 
           var loginPage=new LoginPage(driver);
           Assert.NotNull(loginPage.EnterWithoutLogin());
        }

        [Test, Order(2)]
        public void CheckStickers()
        {
            var mainPage = new MainPage(driver);
            Assert.IsTrue(mainPage.CheckStickers());
        }

        [Test, Order(3)]
        public void CheckRubberDucksPage()
        {
            var mainPage=new MainPage(driver);
            Assert.NotNull(mainPage.OpenRubberDucksPage());
        }

        [Test, Order(4)]
        public void CheckSubcategoryPage()
        {
            var rubberDucksPage = new RubberDucksPage(driver);
            Assert.NotNull(rubberDucksPage.OpenSubcategoryPage());
        }
    }
}