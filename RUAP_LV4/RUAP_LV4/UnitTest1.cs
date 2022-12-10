using NUnit.Framework;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace RUAP_LV4
{
    [TestFixture]
    public class Test123
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void The123Test()
        {
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/");
            driver.FindElement(By.XPath("//input[@value='Add to cart']")).Click();
            driver.FindElement(By.Id("giftcard_2_RecipientName")).Click();
            driver.FindElement(By.Id("giftcard_2_RecipientName")).Clear();
            driver.FindElement(By.Id("giftcard_2_RecipientName")).SendKeys("test123");
            driver.FindElement(By.Id("giftcard_2_RecipientEmail")).Click();
            driver.FindElement(By.Id("giftcard_2_RecipientEmail")).Clear();
            driver.FindElement(By.Id("giftcard_2_RecipientEmail")).SendKeys("test123@gmail.com");
            driver.FindElement(By.Id("giftcard_2_SenderEmail")).Click();
            driver.FindElement(By.Id("giftcard_2_SenderName")).Click();
            driver.FindElement(By.Id("giftcard_2_SenderName")).Clear();
            driver.FindElement(By.Id("giftcard_2_SenderName")).SendKeys("test123");
            driver.FindElement(By.Id("giftcard_2_SenderEmail")).Click();
            driver.FindElement(By.Id("giftcard_2_SenderEmail")).Clear();
            driver.FindElement(By.Id("giftcard_2_SenderEmail")).SendKeys("johndoe42@gmail.com");
            driver.FindElement(By.XPath("//form[@id='product-details-form']/div/div/div[2]/div[4]/div[5]")).Click();
            driver.FindElement(By.Id("add-to-cart-button-2")).Click();
            driver.FindElement(By.XPath("//li[@id='topcartlink']/a")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}