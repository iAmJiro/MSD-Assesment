using Xunit;
using Review; // This links to your main code
using System;
using System.Linq;

namespace Exercise2.Tests
{
    public class BirthingUnitTests
    {
        [Fact]
        public void Person_Constructor_DefaultsToUtcNow()
        {
            // ARRANGE & ACT
            var person = new Person("Newborn");
            
            // ASSERT: Checks if DOB is basically 'now'
            Assert.True(DateTimeOffset.UtcNow.Subtract(person.DOB).TotalSeconds < 5);
        }
        [Fact]
        public void GetMarried_ShouldTruncateTo255Characters()
        {
            // ARRANGE
            var birthingUnit = new BirthingUnit();
            var person = new Person("Bob");
            string veryLongLastName = new string('z', 300); // 300 characters

            var result = birthingUnit.GetMarried(person, veryLongLastName);

            // This should be exactly 255
            Assert.Equal(255, result.Length);
        }
        [Fact]
        public void GetBobs_OlderThan30_ReturnsPeopleBorn30YearsAgoOrMore()
        {
            //ARRANGE
            var unit = new BirthingUnit();
            unit.GetPeople(50); // Generate some test data

            //ACT
            var olderBobs = unit.GetBobs(olderThan30: true);

            //ASSERT
            // To be older than 30 in 2026, you must be born in 1996 or earlier.
            // The current code is using >=, this will fail because this is checking for younger than 30.
            Assert.All(olderBobs, b => Assert.True(b.DOB.Year <= 1996, 
            $"Failed: Bob born in {b.DOB.Year} is younger than 30"));
        }
    }
}