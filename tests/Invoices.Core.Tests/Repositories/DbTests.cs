using System;
using System.Data.Common;
using Invoices.Core.Data;
using Invoices.Core.Entities;
using Invoices.Core.ValueObjects;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace Invoices.Core.Tests.Repositories
{
    public abstract class DbTests : IDisposable
    {
        DbConnection _dbConnection;

        public DbTests()
        {
            _dbConnection = new SqliteConnection("datasource=:memory:");
            _dbConnection.Open();

            UserIdAccessor = Substitute.For<ICurrentUserIdAccessor>();
        }

        public ICurrentUserIdAccessor UserIdAccessor { get; }

        /// <summary>
        /// Gets a new DbContext with the shared InMemory DbContext
        /// </summary>
        /// <returns></returns>
        protected InvoicesDbContext GetNewDbContext()
        {
            var options = new DbContextOptionsBuilder<InvoicesDbContext>().UseSqlite(_dbConnection).Options;
            var dbContext = new InvoicesDbContext(options, UserIdAccessor);
            if (dbContext.Database.EnsureCreated())
            {
                CreateTestUsers(dbContext);
            }

            return dbContext;
        }

        void CreateTestUsers(InvoicesDbContext dbContext)
        {
            var users = new[]
            {
                new User(new PersonName("Albert", string.Empty, "Weinert"), EMail.Empty()),
                new User(new PersonName("Awimba", string.Empty, "Weh"), EMail.Empty())            };

            dbContext.Users.AddRange(users);
            dbContext.SaveChangesAsync().GetAwaiter().GetResult();

            UserIdAccessor.UserId.Returns(users[0].Id);

        }

        public void Dispose()
        {
            _dbConnection?.Dispose();
        }
    }
}
