using System;
using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SeleniumQuiz
{
    [TestClass]
    public class QuizElementIdentification
    {
        public IWebDriver Driver { get; private set; }
        [TestInitialize]
        public void SetupBeforeEveryTestMethod()
        {
            Driver = new WebDriverFactory().Create(BrowserType.Chrome);
        }

        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                Driver.Navigate().GoToUrl(@"https://www.ultimateqa.com/simple-html-elements-for-automation/");        
                Assert.AreEqual(Driver.FindElement(By.Id("simpleElementsLink")).Text, "Click this link", "id");
                Assert.AreEqual(Driver.FindElement(By.LinkText("Click this link")).Text, "Click this link", "linktxt");
                Assert.AreEqual(Driver.FindElement(By.Name("clickableLink")).Text, "Click this link", "nme");
                Assert.AreEqual(Driver.FindElement(By.PartialLinkText("Click this lin")).Text, "Click this link", "partial");
                Assert.AreEqual(Driver.FindElement(By.CssSelector(@"#simpleElementsLink")).Text, "Click this link", "css");
                Assert.AreEqual(Driver.FindElement(By.XPath("//a[@id='simpleElementsLink']")).Text, "Click this link", "xpath");                
            }

            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {              
                Console.WriteLine(e.Message);
                Assert.Fail();
            }
            finally
            {
                Driver.Quit();
            }
        }
    }

}
