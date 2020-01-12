using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkVsCoreDapper.ConsoleTest
{
    public class ListTests
    {
        public List<Customer> ObtenirListCustomersAleatoire(int interactions)
        {
            var faker = new Faker();
            var list = new List<Customer>();
            for (var i = 0; i < interactions; i++)
            {
                list.Add(new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = faker.Name.LastName(),
                    Email = faker.Person.Email,
                    City = faker.Address.City(),
                    Country = faker.Address.Country(),
                    Number = faker.Random.Long().ToString(),
                    Street = faker.Address.StreetName()

                });
            }

            return list;
        }
    }
}
