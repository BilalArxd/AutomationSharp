using Automation.Core;
using Automation.Services.Interfaces;
using OpenQA.Selenium;

namespace Automation.Services.Services
{

    public class GoogleSearchService : IGoogleSearchService
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
