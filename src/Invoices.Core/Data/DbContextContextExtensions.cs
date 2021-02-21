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
            // C# 9 record types appears in references, and are always added, because they are new instances on each changed
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
                switch (entry.Entity)
                {
                    case IEntityChangedBy userEntity:
                        UpdateChangeUser(userEntity, entry, currentUserIdAccessor);
                        break;
                    case IEntityChanged timeEntity:
                        UpdateChangeTime(timeEntity, entry);
                        break;
                }
            }
        }

        static void UpdateChangeUser(IEntityChangedBy entity, EntityEntry entityEntry,
            ICurrentUserIdAccessor currentUserIdAccessor)
        {
            if (entityEntry.State == EntityState.Added)
            {
                entity.Created(currentUserIdAccessor.UserId);

            }
            else if (IsAddedOrModified(entityEntry))
            {
                entity.Changed(currentUserIdAccessor.UserId);
            }
        }

        static void UpdateChangeTime(IEntityChanged entity, EntityEntry entityEntry)
        {
            if (entityEntry.State == EntityState.Added)
            {
                entity.Created();
            }
            else if (IsAddedOrModified(entityEntry))
            {
                entity.Changed();
            }
        }
    }
}
