using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserCustomFilter.Persistence.Entity;

namespace UserCustomFilter.Persistence.EntityMapping;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Created).IsRequired();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.Stock).IsRequired();
    }
}