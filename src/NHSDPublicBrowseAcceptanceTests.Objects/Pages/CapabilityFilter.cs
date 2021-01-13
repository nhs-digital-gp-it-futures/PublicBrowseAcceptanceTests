using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    public class CapabilityFilter
    {
        public By Capabilities => By.ClassName("nhsuk-checkboxes__item");

        public By ApplyCapabilityFilter => By.CssSelector("form button.nhsuk-button--secondary");
    }
}
