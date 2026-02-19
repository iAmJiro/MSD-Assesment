using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review
{
    public class Person
    {
        public string Name { get; private set; }
        public DateTimeOffset DOB { get; private set; }

        // Change: Default constructor now represents age 0 (UtcNow)
        public Person(string name) : this(name, DateTimeOffset.UtcNow) { }

        // Change: Use DateTimeOffset for the parameter to match the property
        public Person(string name, DateTimeOffset dob)
        {
            // Safety: Ensure name isn't null
            Name = name ?? throw new ArgumentNullException(nameof(name));
            DOB = dob;
        }
    }

    public class BirthingUnit
    {
        /// <summary>
        /// MaxItemsToRetrieve
        /// </summary>
        private List<Person> _person = new List<Person>();
        /// <summary>
        /// GetPeoples
        /// </summary>
        /// <param name="j"></param>
        /// <returns>List<object></returns>
        private static readonly Random _random = new Random();
        public List<Person> GetPeople(int count)
        {
            for (int j = 0; j < count; j++)
        {
            try
            {
                // Fix: 0 or 1 is now possible because the max (2) is exclusive.
                string name = _random.Next(0, 2) == 0 ? "Bob" : "Betty";
                
                // Fix: Use 365 days. 
                int ageInYears = _random.Next(18, 85);
                var dob = DateTimeOffset.UtcNow.AddDays(-(ageInYears * 365));

                _person.Add(new Person(name, dob));
            }
            catch (Exception e)
            {
                throw new Exception("Something failed in user creation", e);
            }
        }
            return _person;
        }

        public IEnumerable<Person> GetBobs(bool olderThan30) 
        {
            // Fix: Use <= to find people born in the past (earlier than 30 years ago)
            if (olderThan30)
            {
                // 2026 - 30 years = 1996. We want DOBs of 1995, 1990, etc.
                DateTimeOffset cutoff = DateTimeOffset.UtcNow.AddYears(-30);
                return _person.Where(x => x.Name == "Bob" && x.DOB <= cutoff);
            }
            // Return separated into multiple lines for readability
            return _person.Where(x => x.Name == "Bob");
        }

        public string GetMarried(Person p, string lastName)
        {
            if (lastName.Contains("test"))
            return p.Name;

            string fullName = p.Name + " " + lastName;

            // Fix: You must RETURN the substring result. 
            // Also, (p.Name.Length + lastName).Length was checking the length of the integer!
            if (fullName.Length > 255) {
                return fullName.Substring(0, 255);
            }

        return fullName;
        }
    }
}