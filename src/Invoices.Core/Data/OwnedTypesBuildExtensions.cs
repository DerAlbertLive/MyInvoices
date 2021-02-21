using System;
using System.Linq.Expressions;
using Invoices.Core.Entities;
using Invoices.Core.ValueObjects;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoices.Core.Data
{
    public static class OwnedTypesBuildExtensions
    {
        public static void OwnsOnePersonName<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, PersonName>> navigationExpression, string? prefix = null) where T : class
        {
            if (prefix == null)
            {
                prefix = GetNavigationName(navigationExpression);
            }

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

        public static void OwnsOneCompanyName<T>(
            this EntityTypeBuilder<T> builder,
            Expression<Func<T, CompanyName>> navigationExpression,
            string? prefix = null) where T : class
        {
            if (prefix == null)
            {
                prefix = GetNavigationName(navigationExpression);
            }

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

        public static void OwnsOneAddress<T>(
            this EntityTypeBuilder<T> builder,
            Expression<Func<T, Address>> navigationExpression,
            string? prefix = null) where T : class
        {
            if (prefix == null)
            {
                prefix = GetNavigationName(navigationExpression);
            }

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

        public static void OwnsOneMoney<T>(
            this EntityTypeBuilder<T> builder,
            Expression<Func<T, Money>> navigationExpression,
            string? prefix = null) where T : class
        {
            var converter = new CurrencyValueConverter();

            if (prefix == null)
            {
                prefix = GetNavigationName(navigationExpression);
            }

            builder.OwnsOne(navigationExpression, p =>
            {
                p.Property(pp => pp.Amount)
                    .IsRequired()
                    .HasColumnName($"{prefix}_{nameof(Money.Amount)}");
                p.Property(pp => pp.Currency)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasConversion(converter)
                    .HasColumnName($"{prefix}_{nameof(Money.Currency)}");
            });
        }

        public static void OwnsOneEMail<T>(
            this EntityTypeBuilder<T> builder,
            Expression<Func<T, EMail>> navigationExpression,
            string? columnName = null) where T : class
        {
            if (columnName == null)
            {
                columnName = GetNavigationName(navigationExpression);
            }

            builder.OwnsOne(navigationExpression, b =>
            {
                b.Property(p => p.Value)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName($"{columnName}");
            });
        }

        public static void OwnsOneShortDescription<T>(
            this EntityTypeBuilder<T> builder,
            Expression<Func<T, Designation>> navigationExpression,
            string? columnName = null) where T : class
        {
            if (columnName == null)
            {
                columnName = GetNavigationName(navigationExpression);
            }

            builder.OwnsOne(navigationExpression, b =>
            {
                b.Property(pp => pp.Value)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName($"{columnName}");
            });
        }

        public static void OwnsOnePercent<T>(
            this EntityTypeBuilder<T> builder,
            Expression<Func<T, Percent>> navigationExpression,
            string? columnName = null) where T : class
        {
            if (columnName == null)
            {
                columnName = GetNavigationName(navigationExpression);
            }

            builder.OwnsOne(navigationExpression, b =>
            {
                b.Property(pp => pp.Value)
                    .IsRequired()
                    .HasColumnName($"{columnName}");
            });
        }

        static string GetNavigationName<T, T2>([NotNull] Expression<Func<T, T2>> expression) where T : class
        {
            if (expression.Body is MemberExpression member)
            {
                return member.Member.Name;
            }

            throw new ArgumentException("Action must be a member expression.");
        }

        public static PropertyBuilder<T> WithCustomKeyType<T>(this PropertyBuilder<T> builder)
            where T : EntityId<T>
        {
            builder.HasConversion(new EntityIdValueConverter<T>())
                .Metadata.SetValueComparer(new EntityIdValueComparer<T>());
            return builder;
        }
    }
}
