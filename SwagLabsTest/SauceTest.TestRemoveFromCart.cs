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
        public void TestRemoveFromCart()
        {
            var addToCartButton = myDriver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            Assert.That(addToCartButton.Displayed, Is.True);
            Assert.That(addToCartButton.Enabled, Is.True);
            Assert.That(addToCartButton.Text, Is.EqualTo("Add to cart"));
            addToCartButton.Click();
            Thread.Sleep(3000);
            addToCartButton = myDriver.FindElement(By.Id("remove-sauce-labs-backpack"));
            var cartCount = myDriver.FindElement(By.ClassName("shopping_cart_badge"));
            Assert.That(cartCount.Text, Is.EqualTo("1"));
            Assert.That(addToCartButton.Text, Is.EqualTo("Remove"));

            addToCartButton.Click();
            Thread.Sleep(3000);
            addToCartButton = myDriver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            Assert.Throws<NoSuchElementException>(() => myDriver.FindElement(By.ClassName("shopping_cart_badge")));
            Assert.That(addToCartButton.Text, Is.EqualTo("Add to cart"));
            myDriver.FindElement(By.Id("shopping_cart_container")).Click();
            Thread.Sleep(3000);

            var cartItems = myDriver.FindElement(By.Id("cart_contents_container")).FindElements(By.ClassName("cart_item"));

            Assert.That(cartItems.Count, Is.EqualTo(0));
        }
    }
}
