using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Invoices.Core.Entities;
using Invoices.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
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

            var query = db.Users.Where(u => u.Name.Family == "Bueller");

            _outputHelper.WriteLine(query.ToQueryString());

            var result = await query.SingleAsync();

            result.Should().NotBeSameAs(user);

            result.Name.Given.Should().Be("Ferris");
            result.Name.Middle.Should().Be("M");
            result.Name.Family.Should().Be("Bueller");

            result.EMail.Value.Should().Be("info@der-albert.com");

        }

        [Fact]
        public async Task Customer_can_be_stored_and_loaded()
        {
            var company = new Customer(new CompanyName("Reinland Seifen", "Line2"), new PersonName("Jutta", string.Empty, "Westphal"));
            using (var storeContext = GetNewDbContext())
            {
                storeContext.Customers.Add(company);
                await storeContext.SaveChangesAsync();
            }

            var db = GetNewDbContext();

            var query = db.Customers.Where(u => u.CompanyName.Name1 == "Reinland Seifen");

            _outputHelper.WriteLine(query.ToQueryString());

            var result = await query.SingleOrDefaultAsync();

            result.CompanyName.Name2.Should().Be("Line2");
            result.Name.Given.Should().Be("Jutta");
            result.Name.Family.Should().Be("Westphal");
        }
    }
}
