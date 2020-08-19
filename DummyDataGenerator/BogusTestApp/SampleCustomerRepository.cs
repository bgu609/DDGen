﻿using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BogusTestApp
{
    public class SampleCustomerRepository
    {
        public IEnumerable<Customer> GetCustomers()
        {
            Randomizer.Seed = new Random(123456);

            var ordergenerator = new Faker<Order>()
                .RuleFor(o => o.ID, Guid.NewGuid)
                .RuleFor(o => o.Date, f => f.Date.Past(3))
                .RuleFor(o => o.OrderValue, f => f.Finance.Amount(5000, 150000))
                .RuleFor(o => o.Shipped, f => f.Random.Bool(0.9f));

            var customerGenerator = new Faker<Customer>()
                .RuleFor(c => c.ID, Guid.NewGuid)
                .RuleFor(c => c.Name, f => f.Company.CompanyName())
                .RuleFor(c => c.Address, f => f.Address.FullAddress())
                .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber("010-####-####"))
                .RuleFor(c => c.ContactName, (f, c) => f.Name.FullName())
                .RuleFor(c => c.Orders, f => ordergenerator.Generate(f.Random.Number(1, 5)).ToList());

            return customerGenerator.Generate(100);
        }
    }
}
