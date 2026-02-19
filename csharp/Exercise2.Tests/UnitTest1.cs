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
        public void GetPeople_GeneratesBothBobsAndBetties()
        {
            // ARRANGE
            var unit = new BirthingUnit();
            
            // ACT
            var result = unit.GetPeople(20);

            // ASSERT
            Assert.Contains(result, p => p.Name == "Bob");
            Assert.Contains(result, p => p.Name == "Betty");
        }
    }
}