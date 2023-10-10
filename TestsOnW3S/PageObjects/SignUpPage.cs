using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsOnW3S.PageObjects
{
    public class SignUpPage : BasePage
    {
        public override string Url { get; set; } = "https://www.w3schools.com/signup/index.php";

        public SignUpPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement TitleElement => _driver.FindElement(By.LinkText("Sign Up For Free"));
    }
}
