using Invoices.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoices.Core.Data
{
    internal class InvoicesDbContextModelBuilder
    {
        readonly ModelBuilder _modelBuilder;

        public InvoicesDbContextModelBuilder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Build()
        {
            BuildCustomer(_modelBuilder.Entity<Customer>());
            BuildProduct(_modelBuilder.Entity<Product>());
            BuildProductPrice(_modelBuilder.Entity<ProductPrice>());
            BuildProject(_modelBuilder.Entity<Project>());
            BuildProductType(_modelBuilder.Entity<ProductType>());
            BuildProjectPrice(_modelBuilder.Entity<ProjectRate>());
            BuildUnitOfQuantity(_modelBuilder.Entity<UnitOfQuantity>());
            BuildVat(_modelBuilder.Entity<Vat>());
            BuildUser(_modelBuilder.Entity<User>());
        }

        void BuildCustomer(EntityTypeBuilder<Customer> builder)
        {
            BuildEntity(builder);

            builder.Property(p => p.Id).WithCustomKeyType();

            builder.OwnsOnePersonName(p => p.ContactName);

            builder.OwnsOneCompanyName(p => p.Name);

            builder.OwnsOneAddress(p => p.MainAddress);
        }

        void BuildProductType(EntityTypeBuilder<ProductType> builder)
        {
            BuildEntity(builder);
            builder.Property(p => p.Id).WithCustomKeyType();
            builder.OwnsOneShortDescription(e => e.Designation);
        }

        void BuildUnitOfQuantity(EntityTypeBuilder<UnitOfQuantity> builder)
        {
            BuildEntity(builder);
            builder.Property(p => p.Id).WithCustomKeyType();
            builder.Property(e => e.IsoCode).HasMaxLength(6);
            builder.Property(e => e.Abbreviation).HasMaxLength(6);
            builder.OwnsOneShortDescription(e => e.Designation);
        }

        void BuildProject(EntityTypeBuilder<Project> builder)
        {
            BuildEntity(builder);
            builder.Property(p => p.Id).WithCustomKeyType();
            builder.OwnsOneShortDescription(e => e.Designation);
            builder.Property(e => e.BeginOfProject);
            builder.Property(e => e.EndOfProject);
        }

        void BuildProjectPrice(EntityTypeBuilder<ProjectRate> builder)
        {
            BuildEntity(builder);
            builder.Property(p => p.Id).WithCustomKeyType();
            builder.Property(p => p.ProductPriceId).HasConversion(p => p.Id, p => new ProductPriceId(p));
            builder.Property(p => p.ProjectId).HasConversion(p => p.Id, p => new ProjectId(p));

            builder.HasOne<ProductPrice>()
                .WithMany()
                .HasForeignKey(e => e.ProductPriceId);

            builder.HasOne<Project>()
                .WithMany()
                .HasForeignKey(e => e.ProjectId);

            builder.OwnsOneMoney(p => p.Price);
        }

        void BuildProductPrice(EntityTypeBuilder<ProductPrice> builder)
        {
            BuildEntity(builder);
            builder.Property(p => p.Id).WithCustomKeyType();
            builder.Property(p => p.VatId).HasConversion(p => p.Id, p => new VatId(p));
            builder.Property(p => p.ProductId).HasConversion(p => p.Id, p => new ProductId(p));

            builder.HasOne<Vat>()
                .WithMany()
                .HasForeignKey(e => e.VatId);

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(e => e.ProductId);

            builder.OwnsOneMoney(p => p.Price);
        }

        void BuildProduct(EntityTypeBuilder<Product> builder)
        {
            BuildEntity(builder);
            builder.Property(p => p.Id).WithCustomKeyType();
            builder.Property(p => p.UnitOfQuantityId).HasConversion(p => p.Id, p => new UnitOfQuantityId(p));
            builder.Property(p => p.ProductTypeId).HasConversion(p => p.Id, p => new ProductTypeId(p));

            builder.OwnsOneShortDescription(p => p.Designation);
            builder.HasOne<UnitOfQuantity>()
                .WithMany()
                .HasForeignKey(p => p.UnitOfQuantityId);

            builder.HasOne<ProductType>()
                .WithMany()
                .HasForeignKey(p => p.ProductTypeId);
        }

        void BuildUser(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(nameof(User.Id));
            builder.Property(e => e.Id).WithCustomKeyType();

            builder.OwnsOneEMail(p => p.EMail);
            builder.OwnsOnePersonName(p => p.Name);
        }

        void BuildVat(EntityTypeBuilder<Vat> builder)
        {
            BuildEntity(builder);
            builder.Property(p => p.Id).WithCustomKeyType();
            builder.OwnsOnePercent(p => p.Percent);
            builder.OwnsOneShortDescription(p => p.Designation);
        }

        void BuildEntity<T>(EntityTypeBuilder<T> builder) where T : class, IEntityChangedBy
        {
            builder.HasKey("Id");

            builder.Property(e => e.ChangedById).HasConversion(p => p.Id, p => new UserId(p));
            builder.Property(e => e.CreatedById).HasConversion(p => p.Id, p => new UserId(p));

            builder.HasOne(typeof(User))
                .WithMany()
                .HasForeignKey(nameof(IEntityChangedBy.ChangedById));

            builder.HasOne(typeof(User))
                .WithMany()
                .HasForeignKey(nameof(IEntityChangedBy.CreatedById));
        }
    }
}
