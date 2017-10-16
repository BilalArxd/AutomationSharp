using Automation.Core.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Core
{
    public class Startup
    {
        public static void Start()
        {
            DependencyContainer.Initialize();
        }
    }

}
