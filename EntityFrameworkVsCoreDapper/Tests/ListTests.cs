using Bogus;
using System;
using System.Collections.Generic;

namespace EntityFrameworkVsCoreDapper.Tests
{
    public class ListTests
    {
        public List<Product> ObtenirListProductsAleatoire(int interactions, Guid? customerId)
        {
            var faker = new Faker();

            var list = new List<Product>();
            for (var i = 0; i < interactions; i++)
            {
                var productId = Guid.NewGuid();
                list.Add(new Product
                {
                    Id = productId,
                    Name = faker.Commerce.ProductName(),
                    Description = faker.Lorem.Paragraph(),
                    Brand = faker.Commerce.ProductAdjective(),
                    Price = faker.Random.Decimal(2M, 15000M),
                    OldPrice = faker.Random.Decimal(2M, 15000M),
                    CustomerId = customerId
                }
                );
            }

            return list;
        }
        public List<Customer> ObtenirListCustomersAleatoire(int interactions)
        {
            var list = new List<Customer>();
            for (var i = 0; i < interactions; i++)
            {
                var faker = new Faker();
                var idAddress = Guid.NewGuid();
                var idCustomer = Guid.NewGuid();

                list.Add(new Customer
                {
                    Id = idCustomer,
                    FirstName = faker.Name.FirstName(),
                    LastName = faker.Name.LastName(),
                    Email = faker.Person.Email,
                    BirthDate = faker.Person.DateOfBirth,
                    Status = faker.Person.Gender.ToString(),
                    AddressId = idAddress,
                    Address = new Address
                    {
                        Id = idAddress,
                        Number = faker.Address.BuildingNumber(),
                        Street = faker.Address.StreetName(),
                        City = faker.Address.City(),
                        Country = faker.Address.Country(),
                        ZipCode = faker.Address.ZipCode(),
                        AdministrativeRegion = faker.Address.CountryCode()
                    },
                    Products = List5Products(idCustomer)
                });
            }

            return list;
        }

        private List<Product> List5Products(Guid customerId)
        {
            var list = new List<Product>();
            for (var i = 0; i < 5; i++)
            {
                var faker = new Faker();
                var productId = Guid.NewGuid();
                var pageId = Guid.NewGuid();
                list.Add(new Product
                {
                    Id = productId,
                    Name = faker.Commerce.ProductName(),
                    Description = faker.Lorem.Paragraph(),
                    Brand = faker.Commerce.ProductAdjective(),
                    Price = faker.Random.Decimal(2M, 15000M),
                    OldPrice = faker.Random.Decimal(2M, 15000M),
                    CustomerId = customerId,
                    ProductPageId = pageId,
                    ProductPage = new ProductPage
                    {
                        Id = pageId,
                        Title = faker.Lorem.Letter(25),
                        FullDescription = faker.Lorem.Letter(35),
                        ImageLink = faker.Lorem.Letter(45),
                        SmallDescription = faker.Lorem.Letter(34)
                    }
                }
                );
            }
            return list;
        }
    }
}
