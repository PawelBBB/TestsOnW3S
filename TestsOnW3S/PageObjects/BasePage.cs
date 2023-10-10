using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsOnW3S.PageObjects
{
    public class BasePage
    {
        protected IWebDriver _driver;

        public virtual string Url { get; set; } = "";

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoToPage()
        {
            _driver.Navigate().GoToUrl(Url);
        }
    }
}
