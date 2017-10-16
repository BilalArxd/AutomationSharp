using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;

namespace Automation.Core
{

    public class SeleniumService : ISeleniumService
    {
        private readonly RemoteWebDriver driver;
        private readonly IJavaScriptExecutor js;
        public SeleniumService(RemoteWebDriver driver)
        {
            this.driver = driver;
            js = driver as IJavaScriptExecutor;

        }
        public void LoadUrl(string Url)
        {
            driver.Navigate().GoToUrl(Url);
        }
        public void EnterText(By by, string content)
        {
            var element = FindElement(by);
            element.SendKeys(content);
        }
        public IWebElement FindElement(By by)
        {
            IWebElement element;
            element = driver.FindElement(by);
            return element;
        }
        public IList<IWebElement> FindElements(By by)
        {
            IList<IWebElement> elements;
            elements = driver.FindElements(by);
            return elements;
        }
        public void Click(By by)
        {
            FindElement(by).Click();
        }
        public void Hover(By by)
        {
            var green = FindElement(by);
            Actions action = new Actions(driver);
            action.MoveToElement(green);
        }
        public string GetHtml(By by)
        {

            var element = FindElement(by);
            if (js != null)
            {
                string innerHtml = (string)js.ExecuteScript("return arguments[0].innerHTML", element);
                return innerHtml;
            }
            else
            {
                return "NotFound";
            }
        }
        public void Exit()
        {
            driver.Close();
        }
    }
}
