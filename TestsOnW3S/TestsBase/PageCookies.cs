using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsOnW3S.PageObjects;

namespace TestsOnW3S.TestsBase
{
    public static class PageCookies
    {
        public static ReadOnlyCollection<Cookie> ReadPageCookies(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Navigate().GoToUrl("https://www.w3schools.com/");
            CookiesPopupPage cookiePage = new(driver);
            cookiePage.CookieAccept();
            ReadOnlyCollection<Cookie> cookies = driver.Manage().Cookies.AllCookies;
            Thread.Sleep(1000);
            driver.Quit();
            return cookies;
        }

        public static void LoadSavedCookies(IWebDriver driver, ReadOnlyCollection<Cookie> cookies)
        {

            foreach (Cookie cookie in cookies!)
            {
                driver.Manage().Cookies.AddCookie(new Cookie(cookie.Name, cookie.Value));
            }
            Thread.Sleep(1000);
        }
    }
}
