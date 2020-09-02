using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Invoices.Core.Entities;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Xunit;

namespace Invoices.Core.Tests.Repositories
{
    public class InvoiceDbContextTests : DbTests
    {
        [Fact]
        public void SaveChanges_throws_not_supported_exception()
        {
            var dbContext = GetNewDbContext();
            Action action = () => dbContext.SaveChanges();
            action.Should().Throw<NotSupportedException>();
        }

        [Fact]
        public async Task SaveChangesAsync_should_set_createdAt_on_an_entity()
        {
            var dbContext = GetNewDbContext();

            var vat = new Vat()
            {
                Description = "CreatedVat"
            };

            dbContext.Vats.Add(vat);

            await dbContext.SaveChangesAsync();

            var result = await dbContext.Vats.SingleAsync(v => v.Description == "CreatedVat");

            result.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, precision: 1000);
            result.ChangedAt.Should().Be(result.CreatedAt);
        }

        [Fact]
        public async Task SaveChangesAsync_should_set_userId_1_on_added_vat()
        {
            var dbContext = GetNewDbContext();

            var vat = new Vat()
            {
                Description = "CreatedVat"
            };

            dbContext.Vats.Add(vat);

            await dbContext.SaveChangesAsync();

            var result = await dbContext.Vats.SingleAsync(v => v.Description == "CreatedVat");

            result.CreatedById.Should().Be(1);
            result.ChangedById.Should().Be(1);
        }

        [Fact]
        public async Task SaveChangesAsync_should_set_changedAt_on_modified_entity()
        {
            var dbContext = GetNewDbContext();

            var vat = new Vat()
            {
                Description = "CreatedAt"
            };

            dbContext.Vats.Add(vat);

            await dbContext.SaveChangesAsync();

            vat.Description = "ChangedAt";

            await dbContext.SaveChangesAsync();

            var result = await dbContext.Vats.SingleAsync(v => v.Description == "ChangedAt");

            result.ChangedAt.Should().NotBe(result.CreatedAt);

            result.ChangedAt.Should().BeCloseTo(DateTime.UtcNow, precision: 1000);
        }

        [Fact]
        public async Task SaveChangesAsync_should_set_changedBy_two_2_on_modified()
        {
            var dbContext = GetNewDbContext();

            var vat = new Vat()
            {
                Description = "CreatedAt"
            };

            dbContext.Vats.Add(vat);

            await dbContext.SaveChangesAsync();

            vat.Description = "ChangedAt";

            UserIdAccessor.UserId.Returns(2);

            await dbContext.SaveChangesAsync();

            var result = await dbContext.Vats.SingleAsync(v => v.Description == "ChangedAt");

            result.CreatedById.Should().Be(1);
            result.ChangedById.Should().Be(2);

        }
    }
}
