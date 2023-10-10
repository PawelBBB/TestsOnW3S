using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsOnW3S.PageObjects
{
    public class NavBarPage : BasePage
    {
        public override string Url { get; set; } = "https://www.w3schools.com/";

        public NavBarPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement HomeIconLink => _driver.FindElement(By.Id("w3-logo"));
        public IWebElement ExercisesLink => _driver.FindElement(By.Id("navbtn_exercises"));
        public IWebElement SignUpLink => _driver.FindElement(By.LinkText("Sign Up"));

        public HomePage GotoHomePage()
        {
            HomeIconLink.Click();
            return new HomePage(_driver);
        }

        public ExercisesPage GotoExercisesPage()
        {
            ExercisesLink.Click();
            return new ExercisesPage(_driver);
        }

        public SignUpPage GoToSignUpPage()
        {
            SignUpLink.Click();
            return new SignUpPage(_driver);
        }
    }
}
