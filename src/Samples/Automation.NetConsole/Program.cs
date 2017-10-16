using AutomationSharp.Core;
using AutomationSharp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AutomationSharp.NetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            var service = container.GetService<GoogleSearchService>();
            service.Search("BilalArxd");
        }
    }
}
