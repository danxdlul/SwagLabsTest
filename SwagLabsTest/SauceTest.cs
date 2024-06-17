using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Collections.ObjectModel;

namespace SwagLabsTest
{
    [TestFixture]
    public partial class SauceTests
    {
        private IWebDriver myDriver;
        private const string PASSWORD = "secret_sauce";
        private const string USERNAME = "standard_user";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            myDriver = new EdgeDriver();

            myDriver.Navigate().GoToUrl("https://www.saucedemo.com/");

            Assert.That(myDriver.Title, Is.EqualTo("Swag Labs"));
        }

        [TearDown]
        public void TearDown()
        {
            myDriver.FindElement(By.Id("react-burger-menu-btn")).Click();
            Thread.Sleep(5000);
            myDriver.FindElement(By.Id("reset_sidebar_link")).Click();
            myDriver.FindElement(By.Id("inventory_sidebar_link")).Click();
            Thread.Sleep(2000);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            myDriver.Quit();
            myDriver.Dispose();
        }
        private ReadOnlyCollection<IWebElement> GetInventoryItems()
        {
            return myDriver.FindElement(By.Id("inventory_container"))
                             .FindElements(By.ClassName("inventory_item"));
        }
    }
}