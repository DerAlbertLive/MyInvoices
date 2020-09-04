using System;
using System.Linq;
using Invoices.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Invoices.Core.Data
{
    internal static class DbContextContextExtensions
    {
        static bool IsAddedOrModified(EntityEntry entry) =>
            // Filters for Added or Modified Entities, also looks for updated Owned ValueObjects
            // based on https://stackoverflow.com/questions/51416721/ef-core-owned-property-state-propagation-to-parent-entity
            entry.State == EntityState.Added ||
            entry.State == EntityState.Modified ||
            entry.References.Any(r =>
                r.TargetEntry != null && r.TargetEntry.Metadata.IsOwned() && IsAddedOrModified(r.TargetEntry));

        public static void UpdateBaseEntityProperties(this DbContext dbContext,
            ICurrentUserIdAccessor currentUserIdAccessor)
        {
            var entries = dbContext.ChangeTracker.Entries().Where(IsAddedOrModified).ToArray();

            foreach (var entry in entries)
            {
                if (entry.Entity is IEntityChangedAt timeEntity)
                {
                    UpdateChangeTime(timeEntity, entry);
                }

                if (entry.Entity is IEntityChangedBy userEntity)
                {
                    UpdateChangeUser(userEntity, entry, currentUserIdAccessor);
                }
            }
        }

        static void UpdateChangeUser(IEntityChangedBy entity, EntityEntry entityEntry,
            ICurrentUserIdAccessor currentUserIdAccessor)
        {
            if (entityEntry.State == EntityState.Added)
            {
                entity.CreatedById = currentUserIdAccessor.UserId;
                entity.ChangedById = entity.CreatedById;
            }
            else if (entity.ChangedById != UserId.Zero)
            {
                entity.ChangedById = currentUserIdAccessor.UserId;
            }
        }

        static void UpdateChangeTime(IEntityChangedAt entity, EntityEntry entityEntry)
        {
            if (entityEntry.IsKeySet)
            if (entityEntry.State == EntityState.Added)
            {
                entity.CreatedAt = DateTime.UtcNow;
                entity.ChangedAt = entity.CreatedAt;
            }
            else if (entity.ChangedAt != DateTime.MinValue)
            {
                entity.ChangedAt = DateTime.UtcNow;
            }
        }
    }
}
