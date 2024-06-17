using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

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

        [SetUp]
        public void SetUp()
        {
            myDriver.FindElement(By.Id("react-burger-menu-btn")).Click();
            myDriver.FindElement(By.Id("inventory_sidebar_link")).Click();
        }

        [TearDown]
        public void TearDown()
        {
            myDriver.FindElement(By.Id("react-burger-menu-btn")).Click();
            myDriver.FindElement(By.Id("reset_sidebar_link")).Click();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            myDriver.Quit();
            myDriver.Dispose();
        }
    }
}