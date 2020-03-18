using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Actions.Pages
{
    public sealed class Authorization : Interactions
    {
        public Authorization(IWebDriver driver) : base(driver)
        {
        }

        public void EnterPassword(string password)
        {
            driver.FindElement(pages.Login.Password).SendKeys(password);
        }

        public void EnterUsername(string username)
        {
            driver.FindElement(pages.Login.Username).SendKeys(username);
        }

        public void Login()
        {
            driver.FindElement(pages.Login.LoginButton).Submit();
        }
    }
}
