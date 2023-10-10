using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsOnW3S.PageObjects
{
    public class CookiesPopupPage : BasePage
    {
        public CookiesPopupPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement CookieAcceptButton => _driver.FindElement(By.XPath("//*[@id=\"accept-choices\"]"));

        public void CookieAccept()
        {
            CookieAcceptButton.Click();
        }
    }
}
