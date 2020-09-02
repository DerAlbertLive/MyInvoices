using Invoices.Core.Entities;
using Invoices.Core.ValueObjects;
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
            BuildProduct(_modelBuilder.Entity<Product>());
            BuildProductRate(_modelBuilder.Entity<ProductRate>());
            BuildProject(_modelBuilder.Entity<Project>());
            BuildProjectType(_modelBuilder.Entity<ProductType>());
            BuildProjectRate(_modelBuilder.Entity<ProjectRate>());
            BuildUnitOfQuantity(_modelBuilder.Entity<UnitOfQuantity>());
            BuildVat(_modelBuilder.Entity<Vat>());
            BuildUser(_modelBuilder.Entity<User>());
            BuildCustomer(_modelBuilder.Entity<Customer>());
        }

        void BuildCustomer(EntityTypeBuilder<Customer> builder)
        {
            BuildEntity(builder);
            builder.OwnsOnePersonName(p=>p.Name);

            builder.OwnsOneCompanyName(p=>p.CompanyName);

            builder.OwnsOneAddress(p=>p.MainAddress, "Main");
        }

        void BuildProjectType(EntityTypeBuilder<ProductType> entity)
        {
            BuildEntity(entity);
            entity.Property(e => e.Description).HasMaxLength(32);
        }

        void BuildUnitOfQuantity(EntityTypeBuilder<UnitOfQuantity> entity)
        {
            BuildEntity(entity);
            entity.Property(e => e.IsoCode).HasMaxLength(6);
            entity.Property(e => e.Short).HasMaxLength(6);
            entity.Property(e => e.Description).HasMaxLength(32);
        }

        void BuildProject(EntityTypeBuilder<Project> entity)
        {
            BuildEntity(entity);
            entity.Property(e => e.Description).HasMaxLength(128);
        }

        void BuildProjectRate(EntityTypeBuilder<ProjectRate> entity)
        {
            BuildEntity(entity);
            entity.HasOne<ProjectRate>()
                .WithMany()
                .HasForeignKey(e => e.ProductRateId);
            entity.HasOne<Project>()
                .WithMany()
                .HasForeignKey(e => e.ProjectId);
        }

        void BuildProductRate(EntityTypeBuilder<ProductRate> entity)
        {
            BuildEntity(entity);

            entity.HasOne<Vat>()
                .WithMany()
                .HasForeignKey(e => e.VatId);

            entity.HasOne<Product>()
                .WithMany()
                .HasForeignKey(e => e.ProductId);
        }

        void BuildProduct(EntityTypeBuilder<Product> entity)
        {
            BuildEntity(entity);
            entity.HasOne<UnitOfQuantity>()
                .WithMany()
                .HasForeignKey(p => p.UnitOfQuantityId);

            entity.HasOne<ProductType>()
                .WithMany()
                .HasForeignKey(p => p.ProductTypeId);
        }

        void BuildUser(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.EMail)
                .HasConversion(p => p.Value, p => new EMail(p));

            builder.OwnsOnePersonName(p=>p.Name);
        }

        void BuildVat(EntityTypeBuilder<Vat> vat)
        {
            BuildEntity(vat);
        }

        void BuildEntity(EntityTypeBuilder entity)
        {
            entity.HasKey(nameof(Entity.Id));

            entity.HasOne(typeof(User))
                .WithMany()
                .HasForeignKey(nameof(IEntityChangedBy.ChangedById));

            entity.HasOne(typeof(User))
                .WithMany()
                .HasForeignKey(nameof(IEntityChangedBy.CreatedById));
        }
    }
}
