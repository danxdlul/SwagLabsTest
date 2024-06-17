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
            Assert.That(addToCartButton.Displayed, Is.True);
            Assert.That(addToCartButton.Enabled, Is.True);
            Assert.That(addToCartButton.Text, Is.EqualTo("Add to cart"));
            addToCartButton.Click();
            var cartCount = myDriver.FindElement(By.ClassName("shopping_cart_badge"));
            Assert.That(cartCount.Text, Is.EqualTo("1"));
            Assert.That(addToCartButton.Text, Is.EqualTo("Remove"));
            myDriver.FindElement(By.Id("shopping_cart_container")).Click();
            myDriver.FindElement(By.Id("checkout")).Click();
            myDriver.FindElement(By.Id("first-name")).SendKeys("Daniel");
            myDriver.FindElement(By.Id("last-name")).SendKeys("Kasa");
            myDriver.FindElement(By.Id("postal-code")).SendKeys("2112");
            myDriver.FindElement(By.Id("continue")).Click();
            myDriver.FindElement(By.Id("finish")).Click();
            Assert.That(myDriver.FindElement(By.ClassName("complete-header")).Text, Is.EqualTo("Thank you for your order!"));


        }
    }
}
