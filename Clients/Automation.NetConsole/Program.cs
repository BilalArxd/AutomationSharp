using Automation.Core;
using Automation.Core.IOC;
using Automation.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Automation.NetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup.Start();
            var service = DependencyContainer.Provider.GetService<IGoogleSearchService>();
            service.Search("BilalArxd");
        }
    }
}
