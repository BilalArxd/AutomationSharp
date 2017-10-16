using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSharp.Core
{
    public interface ISeleniumService
    {
        void Click(By by);
        void EnterText(By by, string content);
        void Exit();
        IWebElement FindElement(By by);
        IList<IWebElement> FindElements(By by);
        string GetHtml(By by);
        void Hover(By by);
        void LoadUrl(string Url);
    }
}
