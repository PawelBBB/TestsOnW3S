using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsOnW3S.PageObjects;
using TestsOnW3S.Reporting;

namespace UiTests.NavigationTests
{
    public class NavBarPageNavigationTests : TestBase
    {
        private NavBarPage _navBarPage;

        [SetUp]
        public void SetUp()
        {
            _navBarPage = new NavBarPage(_driver);
            _navBarPage.GoToPage();
        }

        [Test]
        public void NavigateToHomePageTest()
        {
            ExtentReporting.LogInfo("Navigation to Home page");
            
            HomePage homePage = _navBarPage.GotoHomePage();
            Assert.That(homePage.TitleElement, Is.Not.Null);
        }

        [Test]
        public void NavigateToExercisesPageTest()
        {
            ExtentReporting.LogInfo("Navigation to Exercises page");

            ExercisesPage exercisesPage = _navBarPage.GotoExercisesPage();
            Assert.That(exercisesPage.TitleElement, Is.Not.Null);
        }

        [Test]
        public void NavigateToSignUpPageTest()
        {
            ExtentReporting.LogInfo("Navigation to Sign up page");

            SignUpPage signUpPage = _navBarPage.GoToSignUpPage();
            Assert.That(signUpPage.TitleElement, Is.Not.Null);
        }
    }
}
