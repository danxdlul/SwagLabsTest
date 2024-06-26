﻿using OpenQA.Selenium;
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
        public void TestSortProducts()
        {
            var sortContainer = myDriver.FindElement(By.ClassName("product_sort_container"));
            sortContainer.Click();
            sortContainer.FindElement(By.XPath("//option[@value='az']")).Click();
            Thread.Sleep(3000);
            Assert.That(GetInventoryItems().Select(x => x.FindElement(By.XPath("//div[2]/div[1]/a/div")).Text), Is.Ordered.Ascending, "Products are not sorted in ascending order by name");

            sortContainer.Click();
            sortContainer.FindElement(By.XPath("//option[@value='za']")).Click();
            Thread.Sleep(3000);
            Assert.That(GetInventoryItems().Select(x => x.FindElement(By.XPath("//div[2]/div[1]/a/div")).Text), Is.Ordered.Descending, "Products are not sorted in descending order by name");

            sortContainer = myDriver.FindElement(By.ClassName("product_sort_container"));
            sortContainer.Click();
            sortContainer.FindElement(By.XPath("//option[@value='lohi']")).Click();
            Thread.Sleep(3000);
            Assert.That(GetInventoryItems().Select(x => x.FindElement(By.XPath("//div[2]/div[2]/div")).Text), Is.Ordered.Ascending, "Products are not sorted in ascending order by price");

            sortContainer = myDriver.FindElement(By.ClassName("product_sort_container"));
            sortContainer.Click();
            sortContainer.FindElement(By.XPath("//option[@value='hilo']")).Click();
            Thread.Sleep(3000);
            Assert.That(GetInventoryItems().Select(x => x.FindElement(By.XPath("//div[2]/div[2]/div")).Text), Is.Ordered.Descending, "Products are not sorted in descending order by price");
        }
    }
}
