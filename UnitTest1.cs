using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace GosuslugiTest
{
    public class Tests
    {
        private const string Url = "https://www.gosuslugi.ru/";
        private readonly By _signInButton = By.XPath("//button[text() = 'Войти']");
        private readonly By _loginTroubleButton = By.XPath("//button[contains(text(), 'Не удаётся войти?')]");
        private readonly By _passwordRecoveryButton = By.XPath("//button[contains(text(), 'восстановления пароля')]");
        private const int TimeoutInSeconds = 10;

        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Url);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            ClickAndWait(_signInButton);
            ClickAndWait(_loginTroubleButton);
            ClickAndWait(_passwordRecoveryButton);
        }

        private void ClickAndWait(By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeoutInSeconds));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}