using Xunit;
using Review;
using System;
using System.Linq;

namespace Exercise2.Tests
{
    [Fact]
    public void Person_Constructor_DefaultsToUtcNow()
    {
        // This test ensures a new person (newborn) is age 0 by default
        var person = new Person("Newborn");
    
        // Check if the DOB is within a few seconds of 'Now'
        Assert.True(DateTimeOffset.UtcNow.Subtract(person.DOB).TotalSeconds < 5);
    }
}