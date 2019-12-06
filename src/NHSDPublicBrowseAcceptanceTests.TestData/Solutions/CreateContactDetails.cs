using Bogus;

namespace NHSDPublicBrowseAcceptanceTests.TestData.Solutions
{
    public static class CreateContactDetails
    {
        public static SolutionContactDetails NewContactDetail()
        {
            // en_GB esures UK format Phone Number
            SolutionContactDetails contact = new Faker<SolutionContactDetails>("en_GB")
                .StrictMode(true)
                .RuleFor(c => c.ContactName, f => f.Name.FullName())
                .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.ContactName))
                .RuleFor(c => c.Department, f => f.Name.JobTitle())
                .Generate();

            return contact;
        }
    }
}
