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
        [Order(1)]
        public void TestLogin()
        {
            Assert.That(myDriver.FindElement(By.Id("user-name")).Displayed, Is.True);
            myDriver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            Assert.That(myDriver.FindElement(By.Id("password")).Displayed, Is.True);
            myDriver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            Assert.That(myDriver.FindElement(By.Id("login-button")).Displayed, Is.True);
            myDriver.FindElement(By.Id("login-button")).Click();

            Thread.Sleep(5000);

            Assert.Throws<NoSuchElementException>(() => myDriver.FindElement(By.Id("user-name")));
            Assert.Throws<NoSuchElementException>(() => myDriver.FindElement(By.Id("password")));
            Assert.Throws<NoSuchElementException>(() => myDriver.FindElement(By.Id("login-button")));
            Assert.That(myDriver.FindElement(By.Id("inventory_container")).Displayed, Is.True);
            Assert.That(myDriver.FindElement(By.ClassName("inventory_item")).Displayed, Is.True);
        }
    }
}
