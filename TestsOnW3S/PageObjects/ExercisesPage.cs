using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsOnW3S.PageObjects
{
    public class ExercisesPage : BasePage
    {
        public ExercisesPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement TitleElement => _driver.FindElement(By.XPath("//h2[text()='Exercises and Quizzes']"));
        public IWebElement HtmlExercisesLink => _driver.FindElement(By.XPath("//*[@id=\"nav_exercises\"]/div/div/div[2]/a[2]"));


        public HtmlExercisesIndexPage GoToHtmlExercises()
        {
            HtmlExercisesLink.Click();
            return new HtmlExercisesIndexPage(_driver);
        }
    }
}
