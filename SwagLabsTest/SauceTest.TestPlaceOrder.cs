using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsTest
{
    public partial class SauceTests
    {
        [Test]
        public void TestPlaceOrder()
        {
            var addToCartButton = myDriver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            Assert.That(addToCartButton.Displayed, Is.True, "Add to cart button is not displayed");
            Assert.That(addToCartButton.Enabled, Is.True, "Add to cart button is not enabled");
            Assert.That(addToCartButton.Text, Is.EqualTo("Add to cart"), "Add to cart button text is not correct");
            addToCartButton.Click();
            Thread.Sleep(3000);
            addToCartButton = myDriver.FindElement(By.Id("remove-sauce-labs-backpack"));
            var cartCount = myDriver.FindElement(By.ClassName("shopping_cart_badge"));
            Assert.That(cartCount.Text, Is.EqualTo("1"), "Cart count is not correct");
            Assert.That(addToCartButton.Text, Is.EqualTo("Remove"), "Remove button text is not correct");
            myDriver.FindElement(By.Id("shopping_cart_container")).Click();
            Thread.Sleep(3000);
            myDriver.FindElement(By.Id("checkout")).Click();
            Thread.Sleep(3000);
            myDriver.FindElement(By.Id("first-name")).SendKeys("Daniel");
            myDriver.FindElement(By.Id("last-name")).SendKeys("Kasa");
            myDriver.FindElement(By.Id("postal-code")).SendKeys("2112");
            myDriver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(3000);
            myDriver.FindElement(By.Id("finish")).Click();
            Thread.Sleep(3000);
            Assert.That(myDriver.FindElement(By.ClassName("complete-header")).Text, Is.EqualTo("Thank you for your order!"), "Order confirmation text is not correct");


        }
    }
}
