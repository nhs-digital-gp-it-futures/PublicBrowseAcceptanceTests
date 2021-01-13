using System.Collections.Generic;
using Bogus;

namespace NHSDPublicBrowseAcceptanceTests.TestData.Information
{
    public static class RandomInformation
    {
        public static string RandomInformationText(int numWords = 10)
        {
            var faker = new Faker();

            return string.Join(" ", faker.Lorem.Words(numWords));
        }

        public static string RandomString(int count)
        {
            var faker = new Faker("en_GB");
            return string.Join("", faker.Random.Chars('0', 'z', count));
        }

        public static T GetRandomItem<T>(IEnumerable<T> items)
        {
            var faker = new Faker();

            return faker.PickRandom(items);
        }
    }
}
