using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsOnW3S.Browsers
{
    public class DriverFactory
    {
        private readonly DriverType type = TestSettings.TestBrowser;

        public IWebDriver CreateDriver()
        {
            return type switch
            {
                DriverType.Chrome => new ChromeDriver(),
                DriverType.Edge => new EdgeDriver(),
                DriverType.Firefox => new FirefoxDriver(),
                _ => new ChromeDriver()

            }; ;
        }
    }
}
