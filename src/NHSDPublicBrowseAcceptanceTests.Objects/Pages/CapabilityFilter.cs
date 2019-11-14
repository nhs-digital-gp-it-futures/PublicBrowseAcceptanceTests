using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    public class CapabilityFilter
    {
        public By Capabilities => By.ClassName("nhsuk-checkboxes__item");

        public By ApplyFilter => By.CssSelector("form button:not(.nhsuk-button--secondary)");

        public By ApplyFoundationFilter => By.CssSelector("form button.nhsuk-button--secondary");
    }
}