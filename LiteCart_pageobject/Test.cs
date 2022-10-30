using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCart_pageobject
{
    public class Test:BaseTest
    {
        [Test]
        public void AddAndDeleteProductsFromCart()
        {
            int countOfProducts = 3;
            LoginPage loginPage = new LoginPage(driver);
            //AssertHelper - это класс-хелпер для проверок
            AssertHelper assertHelper = new AssertHelper(driver);
            var mainPage=loginPage.EnterWithoutLogin();
            //добавляем нужное количество продуктов в корзину
            for (int i = 0; i < countOfProducts; i++)
            {
               mainPage.GoToProductPage(1)
                       .AddProductToCart()
                       .GoToMainPage();
            }
            //проверка наличия в корзине нужного количества продуктов
            bool assert1= assertHelper.CheckCountOfProductsInCart(countOfProducts);
            //удаление продуктов из корзины
            mainPage.GoToCartPage()
                    .DeleteProductsFromCart();
            //проверка отсутствия в корзине продуктов после удаления
            bool assert2 = assertHelper.CheckCountOfProductsInCart(0);
            //итоговый ассерт
            Assert.IsTrue(assert1 && assert2);
        }
    }
}
