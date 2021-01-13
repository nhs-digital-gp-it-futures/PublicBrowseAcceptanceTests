using Bogus;

namespace NHSDPublicBrowseAcceptanceTests.TestData.Solutions
{
    public static class CreateContactDetails
    {
        public static SolutionContactDetails NewContactDetail()
        {
            // en_GB esures UK format Phone Number
            var contact = new Faker<SolutionContactDetails>("en_GB")
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.ContactName))
                .RuleFor(c => c.Department, f => f.Name.JobTitle())
                .Generate();

            return contact;
        }
    }
}
