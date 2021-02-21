using System;
using System.Data.Common;
using Invoices.Core.Data;
using Invoices.Core.Entities;
using Invoices.Core.ValueObjects;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Xunit.Abstractions;

namespace Invoices.Core.Tests.Repositories
{
    public abstract class DbTests : IDisposable
    {
        readonly DbConnection _dbConnection;

        protected UserId UserId1 = UserId.None;
        protected UserId UserId2 = UserId.None;

        protected DbTests()
        {
            _dbConnection = new SqliteConnection("datasource=:memory:");
            _dbConnection.Open();

            UserIdAccessor = Substitute.For<ICurrentUserIdAccessor>();
        }

        public ICurrentUserIdAccessor UserIdAccessor { get; }

        /// <summary>
        /// Gets a new DbContext with the shared InMemory DbContext
        /// </summary>
        /// <param name="testOutputHelper"></param>
        /// <returns></returns>
        protected InvoicesDbContext GetNewDbContext(ITestOutputHelper testOutputHelper = null!)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InvoicesDbContext>().UseSqlite(_dbConnection);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
            if (testOutputHelper != null)
            {
                optionsBuilder.LogTo(message => testOutputHelper.WriteLine(message));
            }

            var options = optionsBuilder.Options;
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
                new User(new PersonName("Albert", string.Empty, "Weinert"), EMail.None),
                new User(new PersonName("Awimba", string.Empty, "Weh"), EMail.None)
            };

            dbContext.Users.Add(users[0]);
            dbContext.SaveChangesAsync().GetAwaiter().GetResult();
            dbContext.Users.Add(users[1]);
            dbContext.SaveChangesAsync().GetAwaiter().GetResult();

            UserId1 = users[0].Id;
            UserId2 = users[1].Id;
            UserIdAccessor.UserId.Returns(users[0].Id);
        }

        public void Dispose()
        {
            _dbConnection?.Dispose();
        }
    }
}
