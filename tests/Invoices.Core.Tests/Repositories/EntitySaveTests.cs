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
            using (var dbContext = GetNewDbContext())
            {
                dbContext.Users.Add(user);
                await dbContext.SaveChangesAsync();
            }

            var db = GetNewDbContext();

            var userId = user.Id;
            var query = db.Users.Where(u => u.Id == userId);

//            _outputHelper.WriteLine(query.ToQueryString());

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
            using (var storeContext = GetNewDbContext())
            {
                storeContext.Customers.Add(customer);
                await storeContext.SaveChangesAsync();
            }

            var db = GetNewDbContext();

            var query = db.Customers.Where(u => u.Name.Name1 == "Reinland Seifen");

//            _outputHelper.WriteLine(query.ToQueryString());

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
            using (var storeContext = GetNewDbContext())
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

     //       _outputHelper.WriteLine(query.ToQueryString());

            var result = await query.SingleOrDefaultAsync();

            result.Name2.Should().Be("Line2");
            result.Given.Should().Be("Jutta");
            result.Family.Should().Be("Westphal");
        }

        [Fact]
        public async Task Product_can_be_stored_and_loaded()
        {
            using (var storeContext = GetNewDbContext())
            {
                var unit = new UnitOfQuantity("M", "m", new ShortDescription("minuten"));
                var productType = new ProductType(new ShortDescription("Dinge"));
                storeContext.Units.AddRange(unit);
                storeContext.ProductTypes.AddRange(productType);
                await storeContext.SaveChangesAsync();

                var product = new Product(new ShortDescription("Hello"), unit.Id, productType.Id, true);
                storeContext.Products.Add(product);
                await storeContext.SaveChangesAsync();
            }

            var db = GetNewDbContext();

            var query = from c in db.Products
                where c.Description.Value == "Hello"
                select new
                {
                    c.Description.Value
                };

            var result = await query.SingleOrDefaultAsync();

            result.Value.Should().Be("Hello");
        }

        [Fact]
        public async Task UnitOfQuantity_can_be_stored_and_loaded()
        {
            using (var storeContext = GetNewDbContext())
            {
                var unit = new UnitOfQuantity("M", "m", new ShortDescription("minuten"));
                storeContext.Units.AddRange(unit);
                await storeContext.SaveChangesAsync();
            }

            var db = GetNewDbContext();

            var query = from c in db.Units
                where c.Description.Value == "minuten"
                select new
                {
                    c.IsoCode,
                    c.Short,
                    c.Description.Value
                };

            var result = await query.SingleOrDefaultAsync();

            result.Value.Should().Be("minuten");
            result.Short.Should().Be("m");
            result.IsoCode.Should().Be("M");
        }

        [Fact]
        public async Task ProductType_can_be_stored_and_loaded()
        {
            using (var storeContext = GetNewDbContext())
            {
                var productType = new ProductType(new ShortDescription("Dings"));
                storeContext.ProductTypes.AddRange(productType);
                await storeContext.SaveChangesAsync();
            }

            var db = GetNewDbContext();

            var query = from c in db.ProductTypes
                where c.Description.Value == "Dings"
                select new
                {
                    c.Description.Value
                };

            var result = await query.SingleOrDefaultAsync();

            result.Value.Should().Be("Dings");
        }

        [Fact]
        public async Task ProductPrice_can_be_stored_and_loaded()
        {
            using (var storeContext = GetNewDbContext())
            {
                var unit = new UnitOfQuantity("M", "m", new ShortDescription("minuten"));
                var productType = new ProductType(new ShortDescription("Dinge"));
                storeContext.Units.AddRange(unit);
                await storeContext.SaveChangesAsync();

                storeContext.ProductTypes.AddRange(productType);

                await storeContext.SaveChangesAsync();
                var product = new Product(new ShortDescription("Hello"), unit.Id, productType.Id, true);
                storeContext.Products.Add(product);
                await storeContext.SaveChangesAsync();

                var vat = new Vat(new Percent(16.0m), new ShortDescription("Standard"));
                storeContext.Vats.AddRange(vat);
                await storeContext.SaveChangesAsync();


                var rate = new ProductPrice(new ShortDescription("PR"), new Money("EUR", 50.0m), vat.Id, product.Id,
                    false);

                storeContext.ProductPrices.AddRange(rate);
                await storeContext.SaveChangesAsync();
            }

            var db = GetNewDbContext();
            var query = from pr in db.ProductPrices
                where pr.Description.Value == "PR"
                select new
                {
                    pr.Description.Value,
                    pr.Price.Amount,
                    pr.Price.Currency,
                };

            var result = await query.SingleOrDefaultAsync();

            result.Value.Should().Be("PR");
            result.Amount.Should().Be(50.0m);
            result.Currency.Should().Be("EUR");
        }

        [Fact]
        public async Task Vat_can_be_stored_and_loaded()
        {
            using (var storeContext = GetNewDbContext())
            {
                var vat = new Vat(new Percent(16.0m), new ShortDescription("V"));
                storeContext.Vats.AddRange(vat);
                await storeContext.SaveChangesAsync();
            }

            var db = GetNewDbContext();

            var query = from c in db.Vats
                where c.Description.Value == "V"
                select new
                {
                    Percent = c.Percent.Value,
                    Description = c.Description.Value
                };

            var result = await query.SingleOrDefaultAsync();

            result.Percent.Should().Be(16.0m);
            result.Description.Should().Be("V");
        }

        [Fact]
        public async Task Project_can_be_stored_and_loaded()
        {
            using (var storeContext = GetNewDbContext())
            {
                var project = new Project(new ShortDescription("PRJ1"), DateTimeOffset.Now,
                    DateTimeOffset.Now.AddDays(10));
                storeContext.Projects.AddRange(project);
                await storeContext.SaveChangesAsync();
            }

            var db = GetNewDbContext();
            var query = from p in db.Projects
                where p.Description.Value == "PRJ1"
                select new
                {
                    Description = p.Description.Value,
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
            using (var storeContext = GetNewDbContext())
            {
                var unit = new UnitOfQuantity("M", "m", new ShortDescription("minuten"));
                var productType = new ProductType(new ShortDescription("Dinge"));
                storeContext.Units.AddRange(unit);
                storeContext.ProductTypes.AddRange(productType);
                await storeContext.SaveChangesAsync();
                var product = new Product(new ShortDescription("Hello"), unit.Id, productType.Id, true);
                storeContext.Products.Add(product);
                await storeContext.SaveChangesAsync();

                var vat = new Vat(new Percent(16.0m), new ShortDescription("Standard"));
                storeContext.Vats.AddRange(vat);
                await storeContext.SaveChangesAsync();

                var project = new Project(new ShortDescription("PRJ1"), DateTimeOffset.Now,
                    DateTimeOffset.Now.AddDays(10));
                storeContext.Projects.AddRange(project);
                await storeContext.SaveChangesAsync();


                var productRate = new ProductPrice(new ShortDescription("PR"), new Money("EUR", 50.0m), vat.Id,
                    product.Id, false);

                storeContext.ProductPrices.AddRange(productRate);
                await storeContext.SaveChangesAsync();

                var projectRate = new ProjectPrice(new Money("USD", 45.0m), productRate.Id, project.Id, false);

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

        //    _outputHelper.WriteLine(query.ToQueryString());
            var result = await query.SingleOrDefaultAsync();

            result.Amount.Should().Be(45.0m);
            result.Currency.Should().Be("USD");
        }
    }
}
