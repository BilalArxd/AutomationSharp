using AutomationSharp.Core;
using OpenQA.Selenium;

namespace AutomationSharp.Services
{

    public class GoogleSearchService
    {
        private readonly ISeleniumService seleniumService;
        public GoogleSearchService(ISeleniumService seleniumService)
        {
            this.seleniumService = seleniumService;
        }
        public void Search(string text)
        {
            seleniumService.LoadUrl($"https:www.google.com/search?q={text}");
            seleniumService.Click(By.XPath("//*[@id=\"rso\"]/div[1]/div/div[2]/div/div/h3/a"));
        }
    }
}
