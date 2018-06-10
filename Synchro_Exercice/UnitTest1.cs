using System;
using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
namespace Synchro_Exercice
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver Driver;
        [TestMethod]
        public void TestMethod1()
        {                 
            Driver = new WebDriverFactory().Create(BrowserType.Chrome);            
            Driver.Navigate().GoToUrl($"https://www.ultimateqa.com/");
            Driver.Manage().Window.Maximize();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible
                (By.XPath(@"//div[@class='et_parallax_bg et_pb_parallax_css et_pb_inner_shadow']")));
            Driver.FindElement(By.Id(@"menu-item-587")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(@"//img[@src='https://www.ultimateqa.com/wp-content/uploads/2016/11/UQA-Transparent.png']")));
            Driver.FindElement(By.XPath(@"//a[@href='../complicated-page']")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(@"//img[@src='https://www.ultimateqa.com/wp-content/uploads/2016/11/UQA-Transparent.png' and @alt='Ultimate QA']")));
            IWebElement ele = Driver.FindElement(By.XPath(@"//img[@id='logo']"));
            Assert.AreEqual(true, ele.Displayed);
        }
        [TestCleanup]
        public void Teardown()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
