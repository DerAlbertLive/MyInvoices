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
            BuildProduct(_modelBuilder.Entity<Product>());
            BuildProductRate(_modelBuilder.Entity<ProductPrice>());
            BuildProject(_modelBuilder.Entity<Project>());
            BuildProductType(_modelBuilder.Entity<ProductType>());
            BuildProjectRate(_modelBuilder.Entity<ProjectPrice>());
            BuildUnitOfQuantity(_modelBuilder.Entity<UnitOfQuantity>());
            BuildVat(_modelBuilder.Entity<Vat>());
            BuildUser(_modelBuilder.Entity<User>());
            BuildCustomer(_modelBuilder.Entity<Customer>());
        }

        void BuildCustomer(EntityTypeBuilder<Customer> builder)
        {
            BuildEntity(builder);

            builder.OwnsOnePersonName(p => p.ContactName);

            builder.OwnsOneCompanyName(p => p.Name);

            builder.OwnsOneAddress(p => p.MainAddress);
        }

        void BuildProductType(EntityTypeBuilder<ProductType> entity)
        {
            BuildEntity(entity);
            entity.OwnsOneShortDescription(e => e.Description);
        }

        void BuildUnitOfQuantity(EntityTypeBuilder<UnitOfQuantity> entity)
        {
            BuildEntity(entity);
            entity.Property(e => e.IsoCode).HasMaxLength(6);
            entity.Property(e => e.Short).HasMaxLength(6);
            entity.OwnsOneShortDescription(e => e.Description);
        }

        void BuildProject(EntityTypeBuilder<Project> entity)
        {
            BuildEntity(entity);
            entity.OwnsOneShortDescription(e => e.Description);
            entity.Property(e => e.BeginOfProject);
            entity.Property(e => e.EndOfProject);
        }

        void BuildProjectRate(EntityTypeBuilder<ProjectPrice> entity)
        {
            BuildEntity(entity);
            entity.HasOne<ProjectPrice>()
                .WithMany()
                .HasForeignKey(e => e.ProductPriceId);

            entity.HasOne<Project>()
                .WithMany()
                .HasForeignKey(e => e.ProjectId);

            entity.OwnsOneMoney(p => p.Price);
        }

        void BuildProductRate(EntityTypeBuilder<ProductPrice> entity)
        {
            BuildEntity(entity);

            entity.HasOne<Vat>()
                .WithMany()
                .HasForeignKey(e => e.VatId);

            entity.HasOne<Product>()
                .WithMany()
                .HasForeignKey(e => e.ProductId);

            entity.OwnsOneShortDescription(p => p.Description);
            entity.OwnsOneMoney(p => p.Price);
        }

        void BuildProduct(EntityTypeBuilder<Product> builder)
        {
            BuildEntity(builder);

            builder.OwnsOneShortDescription(p => p.Description);
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
            builder.OwnsOneEMail(p => p.EMail);
            builder.OwnsOnePersonName(p => p.Name);
        }

        void BuildVat(EntityTypeBuilder<Vat> vat)
        {
            BuildEntity(vat);
            vat.OwnsOnePercent(p => p.Percent);
            vat.OwnsOneShortDescription(p => p.Description);
        }

        void BuildEntity(EntityTypeBuilder builder)
        {
            builder.HasKey(nameof(Entity.Id));

            builder.HasOne(typeof(User))
                .WithMany()
                .HasForeignKey(nameof(IEntityChangedBy.ChangedById));

            builder.HasOne(typeof(User))
                .WithMany()
                .HasForeignKey(nameof(IEntityChangedBy.CreatedById));
        }
    }
}
