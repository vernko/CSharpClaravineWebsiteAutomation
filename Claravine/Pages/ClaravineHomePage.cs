using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Claravine.Pages
{
    public class ClaravineHomePage
    {
        readonly IWebDriver _driver;
        readonly WebDriverWait _wait;
        public readonly ClaravineHomePageMap Map;

        public ClaravineHomePage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            Map = new ClaravineHomePageMap(driver);
        }

        public void Login(string accturl, string lemail, string password)
        {
            Map.NavbarLoginButton.Click();

            WaitForSignInPageLoad();
            Map.AccountUrlField.SendKeys(accturl);//should there be an error message if don't have an account url?
            Map.ContinueButton.Click();

            WaitForLoginPageLoad();
            Map.LoginEmailField.SendKeys(lemail);
            Map.PasswordField.SendKeys(password);
            Map.LoginButton.Click();

            WaitForValidationErrorLoad();
        }

        public void RequestDemoFromNavbar(string fname, string lname, string demail, string company, string phone)
        {
            Map.RequestDemoNavbarButton.Click();

            WaitForScheduleModalLoad();
            Map.FirstNameField.SendKeys(fname);
            Map.LastNameField.SendKeys(lname);
            Map.DemoEmailField.SendKeys(demail);
            Map.OrganizationField.SendKeys(company);
            Map.PhoneField.SendKeys(phone);
            Map.SubmitButton.Click();
        }

        public void WaitForLearnMorePageLoad()
        {
            _wait.Until((drvr) => Map.CaseStudyButton.Displayed);
        }

        public void WaitForLoginPageLoad()
        {
            _wait.Until((drvr) => Map.LoginEmailField.Displayed);
        }

        public void WaitForPageLoad()
        {
            _wait.Until((drvr) => Map.LearnMoreContainer.Displayed);
        }

        public void WaitForScheduleModalLoad()
        {
            _wait.Until((drvr) => Map.ScheduleDemoModal.Displayed);
        }

        public void WaitForSignInPageLoad()
        {
            _wait.Until((drvr) => Map.AccountUrlField.Displayed);
        }

        public void WaitForValidationErrorLoad()
        {
            _wait.Until((drvr) => Map.LoginErrorMessage.Displayed);
        }
    }

    public class ClaravineHomePageMap
    {
        readonly IWebDriver _driver;

        public ClaravineHomePageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement LearnMoreContainer => _driver.FindElement(By.CssSelector("[class='button-container']"));

        //Request Demo from Navbar
        public IWebElement RequestDemoNavbarButton => _driver.FindElement(By.Id("menu-item-58"));
        public IWebElement ScheduleDemoModal => _driver.FindElement(By.Id("demo"));
        public IWebElement FirstNameField => _driver.FindElement(By.Name("firstname"));
        public IWebElement LastNameField => _driver.FindElement(By.Name("lastname"));
        public IWebElement DemoEmailField => _driver.FindElement(By.Name("email"));
        public IWebElement OrganizationField => _driver.FindElement(By.Name("company"));
        public IWebElement PhoneField => _driver.FindElement(By.Name("phone"));
        public IWebElement SubmitButton => _driver.FindElement(By.CssSelector("[type='submit']"));
        public IWebElement ThanksBlog => _driver.FindElement(By.CssSelector("[class='dm-content']"));


        //Go to learn More Page
        public IWebElement LearnMoreButton => _driver.FindElement(By.CssSelector("a[href*='capabilities']"));
        public IWebElement CaseStudyButton => _driver.FindElement(By.CssSelector("a[href*='record-of-success']"));

        //Login
        public IWebElement NavbarLoginButton => _driver.FindElement(By.Id("menu-item-59"));
        public IWebElement AccountUrlField => _driver.FindElement(By.CssSelector("[class='md-input']"));
        public IWebElement ContinueButton => _driver.FindElement(By.CssSelector("[class='md-ripple']"));
        public IWebElement LoginEmailField => _driver.FindElement(By.Name("email"));
        public IWebElement PasswordField => _driver.FindElement(By.Name("password"));
        public IWebElement LoginButton => _driver.FindElement(By.CssSelector("button[class*='login-button']"));
        public IWebElement LoginErrorMessage => _driver.FindElement(By.CssSelector("[class='alert alert-danger']"));
    }
}