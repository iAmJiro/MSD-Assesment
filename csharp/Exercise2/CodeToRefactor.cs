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

        private IEnumerable<Person> GetBobs(bool olderThan30) {
            return olderThan30 ? _person.Where(x => x.Name == "Bob" && x.DOB >= DateTimeOffset.UtcNow.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _person.Where(x => x.Name == "Bob");
        }

        public string GetMarried(Person p, string lastName)
        {
            if (lastName.Contains("test"))
                return p.Name;
            if ((p.Name.Length + lastName).Length > 255) {
                (p.Name + " " + lastName).Substring(0, 255);
            }

            return p.Name + " " + lastName;
        }
    }
}