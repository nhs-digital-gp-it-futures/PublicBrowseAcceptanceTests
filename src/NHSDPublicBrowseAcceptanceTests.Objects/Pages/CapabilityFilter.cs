using OpenQA.Selenium;

namespace NHSDPublicBrowseAcceptanceTests.Objects.Pages
{
    public class CapabilityFilter
    {
        public static By Capabilities => By.ClassName("nhsuk-checkboxes__item");

        public static By ApplyCapabilityFilter => By.CssSelector("form button.nhsuk-button--secondary");
    }
}
