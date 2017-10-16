using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;

namespace AutomationSharp.Core
{
    public class Container : IServiceProvider
    {
        private IServiceProvider Provider { get; set; }
        private IConfigurationRoot Configuration { get; set; }

        public Container()
        {
            var directory = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
              .SetBasePath(directory)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            IServiceCollection services = new ServiceCollection();
            RegisterServices(services, configuration);
            services.AddServiceModule();
            IServiceProvider provider = services.BuildServiceProvider();
            Configuration = configuration;
            Provider = provider;            
        }
       
        private void RegisterServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<AutomationSettings>(configuration.GetSection("AutomationSettings"));
            string path = System.AppContext.BaseDirectory + "";
            string driver = configuration["AutomationSettings:Driver"];
            switch (driver)
            {
                case "Chrome":
                    var cService = ChromeDriverService.CreateDefaultService(path);
                    //TODO: Configure more options here
                    services.AddSingleton<RemoteWebDriver>(new ChromeDriver(cService));
                    break;

                case "Firefox":
                    //TODO: NotWorkingRightNow/SomeBug
                    //var fService = FirefoxDriverService.CreateDefaultService(path);
                    //var fOptions = new FirefoxOptions();
                    //fOptions.BrowserExecutableLocation = path;
                    ////TODO: Configure more options here
                    //services.AddSingleton<RemoteWebDriver>(new FirefoxDriver(fService, fOptions, new TimeSpan(0, 1, 0)));
                    break;
                case "IE":
                    //TODO: Add Binaries for these browsers then uncomment this
                    //    var ieService = InternetExplorerDriverService.CreateDefaultService(path);
                    //    //TODO: Configure more options here
                    //    services.AddSingleton<RemoteWebDriver>(new InternetExplorerDriver(ieService));
                    break;
                case "Safari":
                    //TODO: Add Binaries for these browsers then uncomment this
                    //    var sService = SafariDriverService.CreateDefaultService(path);
                    //    //TODO: Configure more options here
                    //    services.AddSingleton<RemoteWebDriver>(new SafariDriver(sService));
                    break;
                case "Opera":
                    //TODO: Add Binaries for these browsers then uncomment this
                    //    services.AddSingleton<RemoteWebDriver>(new OperaDriver(path));
                    break;
                case "PhantomJS":
                    //TODO: NotWorkingRightNow/SomeBug
                    //var options = new PhantomJSOptions();
                    //options.SetLoggingPreference(LogType.Browser, LogLevel.Off);
                    //options.SetLoggingPreference(LogType.Client, LogLevel.Off);
                    //options.SetLoggingPreference(LogType.Driver, LogLevel.Off);
                    //options.SetLoggingPreference(LogType.Profiler, LogLevel.Off);
                    //options.SetLoggingPreference(LogType.Server, LogLevel.Off);
                    ////TODO: Configure more options here
                    //services.AddSingleton<RemoteWebDriver>(new PhantomJSDriver(path, options));
                    break;
                default:
                    break;
            }
            services.AddSingleton<ISeleniumService, SeleniumService>();
        }

        public object GetService(Type serviceType)
        {
            return Provider.GetService(serviceType);
        }
    }
}
