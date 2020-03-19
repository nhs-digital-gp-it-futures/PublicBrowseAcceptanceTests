using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    public sealed class Login
    {
        public By Username => By.Id("EmailAddress");
        public By Password => By.Id("Password");
        public By LoginButton => By.CssSelector("button[type=submit]");
    }
}
