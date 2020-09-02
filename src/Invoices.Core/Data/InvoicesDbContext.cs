using System;
using System.Threading;
using System.Threading.Tasks;
using Invoices.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoices.Core.Data
{
    public sealed class InvoicesDbContext : DbContext
    {
        readonly ICurrentUserIdAccessor _userIdAccessor;

        public InvoicesDbContext(DbContextOptions options, ICurrentUserIdAccessor userIdAccessor) : base(options)
        {
            _userIdAccessor = userIdAccessor;
            Users = Set<User>();
            Vats = Set<Vat>();
            Customers = Set<Customer>();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vat> Vats { get; set; }

        /// <summary>
        /// Synchronous SaveChanges is not allowed for this application, go all async
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            throw new NotSupportedException(
                "Synchronous Call of SaveChanges() is not allows, you must use SaveChangesAsync()");
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            DbContextContextExtensions.UpdateBaseEntityProperties(this, _userIdAccessor);

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new InvoicesDbContextModelBuilder(modelBuilder).Build();
        }
    };
}
