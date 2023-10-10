using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsOnW3S.PageObjects
{
    public class SignUpPostPage : BasePage
    {
        public override string Url { get; set; } = "https://profile.w3schools.com/sign-up?redirect_url=https%3A%2F%2Fmy-learning.w3schools.com%2F";

        public SignUpPostPage(IWebDriver driver) : base(driver)
        {
        }
        //page confirmations
        public IWebElement FirstPageTitle => _driver.FindElement(By.XPath("//span[text()='Already have an account?']"));
        public IWebElement SecondPageTitle => _driver.FindElement(By.XPath("//h1[text()='What is your name?']"));

        //inputs
        public IWebElement EmailInput => _driver.FindElement(By.Id("modalusername"));
        public IWebElement PasswordInput => _driver.FindElement(By.Id("new-password"));
        public IWebElement SubmitButton => _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[4]/div[1]/div/div[5]/div[1]/button"));

        //validation info
        public IWebElement EmailInvalidInfo => _driver.FindElement(By.XPath("//span[text()='Looks like you forgot something']"));
        public IWebElement PasswordInvalidInfo => _driver.FindElement(By.XPath("//li[text()='One lowercase character']"));

        public IWebElement PasswordValidInfo => _driver.FindElement(By.XPath("//div[text()='Your password is secure and you're all set!']"));

        public SignUpPostPage Register(string email, string password)
        {
            EmailInput.SendKeys(email);
            PasswordInput.SendKeys(password);
            SubmitButton.Click();
            return this;
        }
    }
}
