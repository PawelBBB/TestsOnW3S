using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsOnW3S.Common
{
    public static class ScreenshootMaker
    {
        public static string GetScreenshoot(IWebDriver driver)
        {
            var file = ((ITakesScreenshot)driver).GetScreenshot();
            var image = file.AsBase64EncodedString;

            return image;
        }
    }
}
