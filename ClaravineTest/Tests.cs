using System;
using Claravine.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ClaravineTest
{
    [TestClass]
    public class Test
    {
        IWebDriver Driver;
        WebDriverWait Wait;

        [TestInitialize]
        public void Setup()
        {
            Driver = new ChromeDriver(@"/Users/vernkofford/Projects/Claravine");
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        [TestMethod]
        public void User_can_request_demo_from_navbar()
        {
            Driver.Navigate().GoToUrl("https://www.claravine.com/");

            var demo = new ClaravineHomePage(Driver, Wait);
            demo.WaitForPageLoad();
            demo.RequestDemoFromNavbar("Jordan", "Arnold", "support@bottega.tech", "Fakers Inc", "4356090002");

            Assert.IsTrue(demo.Map.ThanksBlog.Displayed);
        }

        [TestMethod]
        public void User_can_go_to_learn_more_page()
        {
            Driver.Navigate().GoToUrl("https://www.claravine.com/");

            var learn = new ClaravineHomePage(Driver, Wait);
            learn.Map.LearnMoreButton.Click();
            learn.WaitForLearnMorePageLoad();

            Assert.IsTrue(learn.Map.CaseStudyButton.Displayed);
        }

        [TestMethod]
        public void User_cant_login_without_valid_credentials()
        {
            Driver.Navigate().GoToUrl("https://www.claravine.com/");


            var login = new ClaravineHomePage(Driver, Wait);
            login.WaitForPageLoad();
            login.Login("joefake", "support@bottega.tech", "Fake1234!");

            Assert.IsTrue(login.Map.LoginErrorMessage.Displayed);
        }
    }
}
