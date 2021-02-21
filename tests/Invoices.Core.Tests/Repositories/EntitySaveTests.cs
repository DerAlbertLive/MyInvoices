using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Invoices.Core.Entities;
using Invoices.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace Invoices.Core.Tests.Repositories
{
    public class EntitySaveTests : DbTests
    {
        readonly ITestOutputHelper _outputHelper;

        public EntitySaveTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public async Task User_can_be_stored_and_loaded()
        {
            var user = new User(new PersonName("Ferris", "M", "Bueller"), new EMail("info@der-albert.com"));
            await using (var dbContext = GetNewDbContext(_outputHelper))
            {
                dbContext.Users.Add(user);
                await dbContext.SaveChangesAsync();
            }

            var db = GetNewDbContext();

            var userId = user.Id;
            var query = db.Users.Where(u => u.Id == userId);

            var result = await query.SingleAsync();

            result.Should().NotBeSameAs(user);

            result.Id.Should().Be(user.Id);

            result.EMail.Value.Should().Be("info@der-albert.com");

            result.Name.Given.Should().Be("Ferris");
            result.Name.Middle.Should().Be("M");
            result.Name.Family.Should().Be("Bueller");
        }

        [Fact]
        public async Task Customer_can_be_stored_and_loaded()
        {
            var customer = new Customer(new CompanyName("Reinland Seifen", "Line2"),
                new PersonName("Jutta", string.Empty, "Westphal"));

            await using (var storeContext = GetNewDbContext())
            {
                storeContext.Customers.Add(customer);
                await storeContext.SaveChangesAsync();
            }

            var db = GetNewDbContext();

            var query = db.Customers.Where(u => u.Name.Name1 == "Reinland Seifen");

            var result = await query.SingleOrDefaultAsync();

            result.Name.Name2.Should().Be("Line2");
            result.ContactName.Given.Should().Be("Jutta");
            result.ContactName.Family.Should().Be("Westphal");
        }

        [Fact]
        public async Task Customer_can_be_stored_and_sub_queried()
        {
            var company = new Customer(new CompanyName("Reinland Seifen", "Line2"),
                new PersonName("Jutta", string.Empty, "Westphal"));
            await using (var storeContext = GetNewDbContext())
            {
                storeContext.Customers.Add(company);
                await storeContext.SaveChangesAsync();
            }

            var db = GetNewDbContext();

            var query = from c in db.Customers
                where c.Name.Name1 == "Reinland Seifen"
                select new
                {
                    c.Name.Name1,
                    c.Name.Name2,
                    c.ContactName.Given,
                    c.ContactName.Family
                };

            var result = await query.SingleOrDefaultAsync();

            result.Name2.Should().Be("Line2");
            result.Given.Should().Be("Jutta");
            result.Family.Should().Be("Westphal");
        }

        [Fact]
        public async Task Product_can_be_stored_and_loaded()
        {
            await using (var storeContext = GetNewDbContext())
            {
                var unit = new UnitOfQuantity("M", "m", new Designation("minuten"));
                var productType = new ProductType(new Designation("Dinge"));
                storeContext.Units.AddRange(unit);
                storeContext.ProductTypes.AddRange(productType);
                await storeContext.SaveChangesAsync();

                var product = new Product(new Designation("Hello"), unit.Id, productType.Id, true);
                storeContext.Products.Add(product);
                await storeContext.SaveChangesAsync();
            }

            var db = GetNewDbContext();

            var query = from c in db.Products
                where c.Designation.Value == "Hello"
                select new
                {
                    c.Designation.Value
                };

            var result = await query.SingleOrDefaultAsync();

            result.Value.Should().Be("Hello");
        }

        [Fact]
        public async Task UnitOfQuantity_can_be_stored_and_loaded()
        {
            await using (var storeContext = GetNewDbContext())
            {
                var unit = new UnitOfQuantity("M", "m", new Designation("minuten"));
                storeContext.Units.AddRange(unit);
                await storeContext.SaveChangesAsync();
            }

            var db = GetNewDbContext();

            var query = from c in db.Units
                where c.Designation.Value == "minuten"
                select new
                {
                    c.IsoCode,
                    Short = c.Abbreviation,
                    c.Designation.Value
                };

            var result = await query.SingleOrDefaultAsync();

            result.Value.Should().Be("minuten");
            result.Short.Should().Be("m");
            result.IsoCode.Should().Be("M");
        }

        [Fact]
        public async Task ProductType_can_be_stored_and_loaded()
        {
            await using (var storeContext = GetNewDbContext())
            {
                var productType = new ProductType(new Designation("Dings"));
                storeContext.ProductTypes.AddRange(productType);
                await storeContext.SaveChangesAsync();
            }

            var db = GetNewDbContext();

            var query = from c in db.ProductTypes
                where c.Designation.Value == "Dings"
                select new
                {
                    c.Designation.Value
                };

            var result = await query.SingleOrDefaultAsync();

            result.Value.Should().Be("Dings");
        }

        [Fact]
        public async Task ProductPrice_can_be_stored_and_loaded()
        {
            await using (var storeContext = GetNewDbContext())
            {
                var unit = new UnitOfQuantity("M", "m", new Designation("minuten"));
                var productType = new ProductType(new Designation("Dinge"));
                storeContext.Units.AddRange(unit);
                await storeContext.SaveChangesAsync();

                storeContext.ProductTypes.AddRange(productType);

                await storeContext.SaveChangesAsync();
                var product = new Product(new Designation("Hello"), unit.Id, productType.Id, true);
                storeContext.Products.Add(product);
                await storeContext.SaveChangesAsync();

                var vat = new Vat(new Percent(16.0m), new Designation("Standard"));
                storeContext.Vats.AddRange(vat);
                await storeContext.SaveChangesAsync();


                var rate = new ProductPrice(new Money("EUR", 50.0m), vat.Id, product.Id,
                    false);

                storeContext.ProductPrices.AddRange(rate);
                await storeContext.SaveChangesAsync();
            }

            var db = GetNewDbContext();
            var query = from pr in db.ProductPrices
                where pr.Price.Amount == 50.0m
                select new
                {
                    pr.Price.Amount,
                    pr.Price.Currency,
                    pr.ProductId,
                };

            var result = await query.SingleOrDefaultAsync();

            result.Amount.Should().Be(50.0m);
            result.Currency.Should().Be("EUR");
        }

        [Fact]
        public async Task Vat_can_be_stored_and_loaded()
        {
            await using (var storeContext = GetNewDbContext())
            {
                var vat = new Vat(new Percent(16.0m), new Designation("V"));
                storeContext.Vats.AddRange(vat);
                await storeContext.SaveChangesAsync();
            }

            var db = GetNewDbContext();

            var query = from c in db.Vats
                where c.Designation.Value == "V"
                select new
                {
                    Percent = c.Percent.Value,
                    Description = c.Designation.Value
                };

            var result = await query.SingleOrDefaultAsync();

            result.Percent.Should().Be(16.0m);
            result.Description.Should().Be("V");
        }

        [Fact]
        public async Task Project_can_be_stored_and_loaded()
        {
            await using (var storeContext = GetNewDbContext())
            {
                var project = new Project(new Designation("PRJ1"), DateTimeOffset.Now,
                    DateTimeOffset.Now.AddDays(10));
                storeContext.Projects.AddRange(project);
                await storeContext.SaveChangesAsync();
            }

            var db = GetNewDbContext();
            var query = from p in db.Projects
                where p.Designation.Value == "PRJ1"
                select new
                {
                    Description = p.Designation.Value,
                    p.BeginOfProject,
                    p.EndOfProject
                };

            var result = await query.SingleOrDefaultAsync();

            result.Description.Should().Be("PRJ1");
            result.BeginOfProject.Should().BeCloseTo(DateTimeOffset.Now, 1000);
            result.EndOfProject.Should().BeCloseTo(DateTimeOffset.Now.AddDays(10), 1000);
        }

        [Fact]
        public async Task ProjectPrice_can_be_stored_and_loaded()
        {
            await using (var storeContext = GetNewDbContext())
            {
                var unit = new UnitOfQuantity("M", "m", new Designation("minuten"));
                var productType = new ProductType(new Designation("Dinge"));
                storeContext.Units.AddRange(unit);
                storeContext.ProductTypes.AddRange(productType);
                await storeContext.SaveChangesAsync();
                var product = new Product(new Designation("Hello"), unit.Id, productType.Id, true);
                storeContext.Products.Add(product);
                await storeContext.SaveChangesAsync();

                var vat = new Vat(new Percent(16.0m), new Designation("Standard"));
                storeContext.Vats.AddRange(vat);
                await storeContext.SaveChangesAsync();

                var project = new Project(new Designation("PRJ1"), DateTimeOffset.Now,
                    DateTimeOffset.Now.AddDays(10));
                storeContext.Projects.AddRange(project);
                await storeContext.SaveChangesAsync();


                var productRate = new ProductPrice(new Money("EUR", 50.0m), vat.Id,
                    product.Id, false);

                storeContext.ProductPrices.AddRange(productRate);
                await storeContext.SaveChangesAsync();

                var projectRate = new ProjectRate(new Money("USD", 45.0m), productRate.Id, project.Id, false);

                storeContext.ProjectPrices.Add(projectRate);

                await storeContext.SaveChangesAsync();
            }

            var db = GetNewDbContext();
            var query = from pp in db.ProjectPrices
                where pp.Price.Amount == 45.0m
                select new
                {
                    pp.Price.Amount,
                    pp.Price.Currency
                };

            var result = await query.SingleOrDefaultAsync();

            result.Amount.Should().Be(45.0m);
            result.Currency.Should().Be("USD");
        }
    }
}
