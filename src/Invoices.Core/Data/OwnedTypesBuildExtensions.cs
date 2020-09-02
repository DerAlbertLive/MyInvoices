using System;
using System.Linq.Expressions;
using Invoices.Core.Entities;
using Invoices.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoices.Core.Data
{
    public static class OwnedTypesBuildExtensions
    {
        public static void OwnsOnePersonName<T>(this EntityTypeBuilder<T> builder, Expression<Func<T, PersonName>> navigationExpression, string prefix="Name") where T : class
        {
            builder.OwnsOne(navigationExpression, p =>
            {
                p.Property(pp => pp.Given)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName($"{prefix}_{nameof(PersonName.Given)}");
                p.Property(pp => pp.Middle)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName($"{prefix}_{nameof(PersonName.Middle)}");
                p.Property(pp => pp.Family)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName($"{prefix}_{nameof(PersonName.Family)}");
            });
        }

        public static void OwnsOneCompanyName<T>(this EntityTypeBuilder<T> builder, Expression<Func<T, CompanyName>> navigationExpression, string prefix="Company") where T : class
        {
            builder.OwnsOne(navigationExpression, p =>
            {
                p.Property(pp => pp.Name1)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName($"{prefix}_{nameof(CompanyName.Name1)}");
                p.Property(pp => pp.Name2)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName($"{prefix}_{nameof(CompanyName.Name2)}");
            });
        }

        public static void OwnsOneAddress<T>(this EntityTypeBuilder<T> builder, Expression<Func<T, Address>> navigationExpression, string prefix) where T : class
        {
            builder.OwnsOne(navigationExpression, p =>
            {
                p.Property(pp => pp.Street)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName($"{prefix}_{nameof(Address.Street)}");
                p.Property(pp => pp.City)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName($"{prefix}_{nameof(Address.City)}");
                p.Property(pp => pp.ZipCode)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName($"{prefix}_{nameof(Address.ZipCode)}");
            });
        }
    }
}
