using System;
using System.Threading.Tasks;
using FluentAssertions;
using Invoices.Core.Entities;
using Invoices.Core.ValueObjects;
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

            var vat = new Vat(new Percent(16.0m), new ShortDescription("CreatedVat"));

            dbContext.Vats.Add(vat);

            await dbContext.SaveChangesAsync();

            var result = await dbContext.Vats.SingleAsync(v => v.Id == vat.Id);

            result.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, precision: 1000);
            result.ChangedAt.Should().Be(result.CreatedAt);
        }

        [Fact]
        public async Task SaveChangesAsync_should_set_userId_1_on_added_vat()
        {
            var dbContext = GetNewDbContext();

            UserIdAccessor.UserId.Returns(UserId1);

            var vat = new Vat(new Percent(16.0m),  new ShortDescription("CreatedVat"));

            dbContext.Vats.Add(vat);

            await dbContext.SaveChangesAsync();

            var result = await dbContext.Vats.SingleAsync(v => v.Id == vat.Id);

            result.CreatedById.Should().Be(UserId1);
            result.ChangedById.Should().Be(UserId1);
        }

        [Fact]
        public async Task SaveChangesAsync_should_set_changedAt_on_modified_entity()
        {
            var dbContext = GetNewDbContext();

            var vat = new Vat(new Percent(16.0m), new ShortDescription("CreatedAt"));

            dbContext.Vats.Add(vat);

            await dbContext.SaveChangesAsync();

            await Task.Delay(200);

            vat.ChangeDescription(new ShortDescription("ChangedAt"));

            var count = await dbContext.SaveChangesAsync();

            var result = await dbContext.Vats.SingleAsync(v => v.Id == vat.Id);

            result.ChangedAt.Should().NotBe(result.CreatedAt);

            result.ChangedAt.Should().BeCloseTo(DateTime.UtcNow, precision: 1000);
        }

        [Fact]
        public async Task SaveChangesAsync_should_set_changedBy_two_2_on_modified()
        {
            var dbContext = GetNewDbContext();

            var vat = new Vat(new Percent(16.0m), new ShortDescription("CreatedAt"));

            dbContext.Vats.Add(vat);

            await dbContext.SaveChangesAsync();

            vat.ChangeDescription(new ShortDescription("ChangedAt"));

            UserIdAccessor.UserId.Returns(UserId2);

            await dbContext.SaveChangesAsync();

            var result = await dbContext.Vats.SingleAsync(v => v.Description.Value == "ChangedAt");

            result.CreatedById.Should().Be(UserId1);
            result.ChangedById.Should().Be(UserId2);

        }
    }
}
