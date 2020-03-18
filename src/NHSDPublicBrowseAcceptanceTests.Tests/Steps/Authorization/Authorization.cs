using FluentAssertions;
using NHSDPublicBrowseAcceptanceTests.Tests.Utils;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace NHSDPublicBrowseAcceptanceTests.Tests.Steps.Authorization
{
    [Binding]
    public class Authorization
    {
        private readonly ScenarioContext _context;
        private readonly UITest _test;

        public Authorization(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }
        
        [Given(@"that a User is not logged in")]
        public void GivenThatAUserIsNotLoggedIn()
        {
            var builder = new UriBuilder(_test.Driver.Url)
            {
                Host = "docker.for.win.localhost"
            };
            _test.Driver.Navigate().GoToUrl(builder.Uri.ToString());

            _test.Pages.Homepage.ClickLoginButton();
        }
        
        [Given(@"the User logged in")]
        public void GivenTheUserLoggedIn()
        {
            _context.Pending();
        }
        
        [Given(@"the duration of the session is equal to or greater than the maximum session duration")]
        public void GivenTheDurationOfTheSessionIsEqualToOrGreaterThanTheMaximumSessionDuration()
        {
            _context.Pending();
        }

        [When(@"a User provides a (true|false) username")]
        public void WhenAUserProvidesATrueUsername(bool usernameCorrect)
        {
            if (usernameCorrect)
            {
                var user = EnvironmentVariables.AdminUser();
                _test.Pages.Authorization.EnterUsername(user.Username);
            }
        }

        [When(@"a User provides a (true|false) password")]
        public void WhenAUserProvidesATruePassword(bool passwordCorrect)
        {
            if (passwordCorrect)
            {
                var user = EnvironmentVariables.AdminUser();
                _test.Pages.Authorization.EnterPassword(user.Password);
            }
        }

        [When(@"a User provides recognised authentication details to login locally")]
        public void WhenAUserProvidesRecognisedAuthenticationDetailsToLoginLocally()
        {
            var user = EnvironmentVariables.AdminUser();
            _test.Pages.Authorization.EnterUsername(user.Username);
            _test.Pages.Authorization.EnterPassword(user.Password);
            _test.Pages.Authorization.Login();
        }
        
        [When(@"a User provides unrecognised authentication details to login locally")]
        public void WhenAUserProvidesUnrecognisedAuthenticationDetailsToLoginLocally()
        {
            _context.Pending();
        }
        
        [When(@"they attempt to access the application")]
        public void WhenTheyAttemptToAccessTheApplication()
        {
            _context.Pending();
        }
        
        [Then(@"the User will be logged in")]
        public void ThenTheUserWillBeLoggedIn()
        {
            _test.Pages.Homepage.LoginLogoutLinkText().Should().Be("Log out");
        }
        
        [Then(@"the User will not be logged in")]
        public void ThenTheUserWillNotBeLoggedIn()
        {
            _test.Pages.Authorization.Login();
        }

        [Then(@"the User will be informed the login attempt was unsuccessful Email (.*), password (.*)")]
        public void ThenTheUserWillBeInformedTheLoginAttemptWasUnsuccessful(bool email, bool password)
        {
            if (!email)
            {
                _test.Driver.FindElement(By.CssSelector("[data-valmsg-for=EmailAddress]")).Displayed.Should().BeTrue();
            }

            if (!password)
            {
                _test.Driver.FindElement(By.CssSelector("[data-valmsg-for=Password]")).Displayed.Should().BeTrue();
            }
        }
        
        [Then(@"they are redirected to login again")]
        public void ThenTheyAreRedirectedToLoginAgain()
        {
            _test.Driver.Title.Should().Contain("Login");
        }
    }
}
