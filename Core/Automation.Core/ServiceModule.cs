using AutomationSharp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AutomationSharp.Core
{
    public static class ServiceModule
    {
        public static void AddServiceModule(this IServiceCollection services)
        {
            services.AddSingleton<GoogleSearchService>();
        }
    }
}
