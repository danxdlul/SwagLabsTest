using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SwagLabsTest
{
    public partial class SauceTests
    {
        [Test]
        public void TestAddToCart()
        {
            var addToCartButton = myDriver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            Assert.That(addToCartButton.Displayed, Is.True);
            Assert.That(addToCartButton.Enabled, Is.True);
            Assert.That(addToCartButton.Text, Is.EqualTo("Add to cart"));
            addToCartButton.Click();
            var cartCount = myDriver.FindElement(By.ClassName("shopping_cart_badge"));
            Assert.That(cartCount.Text, Is.EqualTo("1"));
            Assert.That(addToCartButton.Text, Is.EqualTo("Remove"));
            myDriver.FindElement(By.Id("shopping_cart_container")).Click();

            var cartItems = myDriver.FindElement(By.Id("cart_contents_container")).FindElements(By.ClassName("cart_item"));

            Assert.That(cartItems.Count, Is.EqualTo(1));
            Assert.That(cartItems[0].FindElement(By.ClassName("inventory_item_name")).Text, Is.EqualTo("Sauce Labs Backpack"));

        }
    }
}
