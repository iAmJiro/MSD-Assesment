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
    }
}