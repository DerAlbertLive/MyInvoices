using System;
using System.Linq;
using Invoices.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoices.Core.Data
{
    internal static class DbContextContextExtensions
    {
        public static void UpdateBaseEntityProperties(this DbContext dbContext,
            ICurrentUserIdAccessor currentUserIdAccessor)
        {
            var entries = dbContext.ChangeTracker.Entries().ToArray();
            foreach (var entry in entries)
            {
                if (entry.Entity is IEntityChangedAt timeEntity)
                {
                    UpdateChangeTime(timeEntity, entry.State);
                }

                if (entry.Entity is IEntityChangedBy userEntity)
                {
                    UpdateChangeUser(userEntity, entry.State, currentUserIdAccessor);
                }
            }
        }

        static void UpdateChangeUser(IEntityChangedBy entity, EntityState entityState,
            ICurrentUserIdAccessor currentUserIdAccessor)
        {
            if (entityState == EntityState.Added)
            {
                entity.CreatedById = currentUserIdAccessor.UserId;
                entity.ChangedById = entity.CreatedById;
            }

            if (entityState == EntityState.Modified)
            {
                entity.ChangedById = currentUserIdAccessor.UserId;
            }
        }

        static void UpdateChangeTime(IEntityChangedAt entity, EntityState entityState)
        {
            if (entityState == EntityState.Added)
            {
                entity.CreatedAt = DateTime.UtcNow;
                entity.ChangedAt = entity.CreatedAt;
            }

            if (entityState == EntityState.Modified)
            {
                entity.ChangedAt = DateTime.UtcNow;
            }
        }
    }
}
