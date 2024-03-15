using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.Price).HasColumnType("decimal(18,2)"); // 18 digits, 2 decimals
        builder.Property(p => p.PhotoUrl).IsRequired();
        builder.HasOne(b => b.ProductBrand).WithMany()
            .HasForeignKey(p => p.ProductBrandId);
        builder.HasOne(b => b.ProductType).WithMany()
            .HasForeignKey(p => p.ProductTypeId);
    }
}
