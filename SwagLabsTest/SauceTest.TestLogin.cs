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

            Assert.That(myDriver.FindElement(By.Id("user-name")).Displayed, Is.False);
            Assert.That(myDriver.FindElement(By.Id("password")).Displayed, Is.False);
            Assert.That(myDriver.FindElement(By.Id("login-button")).Displayed, Is.False);
            Assert.That(myDriver.FindElement(By.Id("inventory_container")).Displayed, Is.True);
        }
    }
}
