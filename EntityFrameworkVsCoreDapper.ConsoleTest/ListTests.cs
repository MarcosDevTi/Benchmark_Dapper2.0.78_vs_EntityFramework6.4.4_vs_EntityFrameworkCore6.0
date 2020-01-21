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
                var idAddress = Guid.NewGuid();
                var idCustomer = Guid.NewGuid();

                var orderId1 = Guid.NewGuid();
                var orderId2 = Guid.NewGuid();
                var orderId3 = Guid.NewGuid();
                var orderId4 = Guid.NewGuid();
                var orderId5 = Guid.NewGuid();

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
                    Orders = new List<Order>
                    {
                        
                        new Order
                        {
                            Id =orderId1,
                            OrderItems = List20OrderItems(orderId1),
                            CustomerId = idCustomer
                        },
                        new Order
                        {
                            Id =orderId2,
                            OrderItems = List20OrderItems(orderId2),
                            CustomerId = idCustomer
                        },
                        new Order
                        {
                            Id = orderId3,
                            OrderItems = List20OrderItems(orderId3),
                            CustomerId = idCustomer
                        },
                        new Order
                        {
                            Id = orderId4,
                            OrderItems = List20OrderItems(orderId4),
                            CustomerId = idCustomer
                        },
                        new Order
                        {
                            Id = orderId5,
                            OrderItems = List20OrderItems(orderId5),
                            CustomerId = idCustomer
                        }
                    }
                });
            }

            return list;
        }

        private List<OrderItem> List20OrderItems(Guid orderId)
        {
            var faker = new Faker();

            var list = new List<OrderItem>();
            for(var i = 0; i < 20; i++)
            {
                var productId = Guid.NewGuid();
                list.Add(
                    new OrderItem
                    {
                        Id = Guid.NewGuid(),
                        Product = new Product
                        {
                            Id = productId,
                            Name = faker.Commerce.ProductName(),
                            Description = faker.Lorem.Paragraph(),
                            Brand = faker.Commerce.ProductAdjective(),
                            Price = faker.Random.Decimal(2M, 15000M),
                            OldPrice = faker.Random.Decimal(2M, 15000M),
                        },
                        OrderId = orderId,
                        ProductId = productId
                    }
                );
            }

            return list;
        }
    }
}
