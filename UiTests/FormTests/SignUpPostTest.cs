using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsOnW3S.PageObjects;
using TestsOnW3S.Reporting;
using TestsOnW3S;

namespace UiTests.FormTests
{
    public class SignUpPostTest : TestBase
    {
        private readonly string _invalidEmail = "asdasd";
        private readonly string _invalidPassword = "asd";

        private SignUpPostPage _signUpPostPage;
        [SetUp]
        public void SetUp()
        {
            _signUpPostPage = new SignUpPostPage(_driver);
            _signUpPostPage.GoToPage();
        }

        [Test]
        public void SignUpPost_InvalidEmailValidPassword_ShouldReject()
        {
            string invalidEmail = _invalidEmail;
            string validPassword = AppConfig.Credential.Password;

            ExtentReporting.LogInfo($"Starting test - Sign up by invalid email: {invalidEmail} and valid password: {validPassword}");

            _signUpPostPage.Register(invalidEmail, validPassword);

            Assert.That(_signUpPostPage.EmailInvalidInfo, Is.Not.Null);
        }

        [Test]
        public void SignUpPost_ValidEmailInvalidPassword_ShouldReject()
        {
            string validEmail = AppConfig.Credential.Email;
            string invalidPassword = _invalidPassword;

            ExtentReporting.LogInfo($"Starting test - Sign up by valid email: {validEmail} and invalid password: {invalidPassword}");

            _signUpPostPage.Register(validEmail, invalidPassword);

            Assert.That(_signUpPostPage.PasswordInvalidInfo, Is.Not.Null);
        }

        [Test]
        public void SignUpPost_InvalidEmailAndInvalidPassword_ShouldReject()
        {
            string invalidEmail = _invalidEmail;
            string invalicPassword = _invalidPassword;

            ExtentReporting.LogInfo($"Starting test - Sign up by invalid email: {_invalidEmail} and invalid password: {_invalidPassword}");

            _signUpPostPage.Register(invalidEmail, invalicPassword);

            Assert.Multiple(() =>
            {
                Assert.That(_signUpPostPage.EmailInvalidInfo, Is.Not.Null);
                Assert.That(_signUpPostPage.PasswordInvalidInfo, Is.Not.Null);
            });
        }

        [Test]
        public void SignUpPost_ValidUserAndPassword_ShoildPass()
        {
            string validEmail = AppConfig.Credential.Email;
            string validPassword = AppConfig.Credential.Password;

            ExtentReporting.LogInfo($"Starting test - Sign up by valid email: {validEmail} and password: {validPassword}");
            
            _signUpPostPage.Register(validEmail, validPassword);

            Assert.That(_signUpPostPage.SecondPageTitle, Is.Not.Null);
        }
    }
}
