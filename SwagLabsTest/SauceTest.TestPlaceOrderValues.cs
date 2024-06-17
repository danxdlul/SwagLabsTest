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
        public void TestPlaceOrderValues()
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
            myDriver.FindElement(By.Id("shopping_cart_container")).Click();
            Thread.Sleep(3000);
            myDriver.FindElement(By.Id("checkout")).Click();
            Thread.Sleep(3000);
            var continueButton = myDriver.FindElement(By.Id("continue"));
            continueButton.Click();
            Thread.Sleep(3000);
            var checkoutInfoContainer = myDriver.FindElement(By.Id("checkout_info_container"));
            Assert.That(checkoutInfoContainer.FindElement(By.XPath("//div/form/div[1]/div[4]/h3")).Text, Is.EqualTo("Error: First Name is required"));
            myDriver.FindElement(By.Id("first-name")).SendKeys("Daniel");
            continueButton.Click();
            Thread.Sleep(3000);
            Assert.That(checkoutInfoContainer.FindElement(By.XPath("//div/form/div[1]/div[4]/h3")).Text, Is.EqualTo("Error: Last Name is required"));
            myDriver.FindElement(By.Id("last-name")).SendKeys("Kasa");
            continueButton.Click();
            Thread.Sleep(3000);
            Assert.That(checkoutInfoContainer.FindElement(By.XPath("//div/form/div[1]/div[4]/h3")).Text, Is.EqualTo("Error: Postal Code is required"));
            myDriver.FindElement(By.Id("postal-code")).SendKeys("2112");
            continueButton.Click();
            Thread.Sleep(3000);
            myDriver.FindElement(By.Id("finish")).Click();
            Thread.Sleep(3000);
            Assert.That(myDriver.FindElement(By.ClassName("complete-header")).Text, Is.EqualTo("Thank you for your order!"));
        }
    }
}
