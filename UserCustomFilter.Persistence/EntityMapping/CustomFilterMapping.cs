using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserCustomFilter.Persistence.Entity;

namespace UserCustomFilter.Persistence.EntityMapping;

public class CustomFilterMapping : IEntityTypeConfiguration<CustomFilter>
{
    public void Configure(EntityTypeBuilder<CustomFilter> builder)
    {
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Created).IsRequired();
        builder.Property(x => x.FilterName).IsRequired();
        builder.Property(x => x.FilterPicture).IsRequired();
        builder.Property(x => x.FilterType).IsRequired();
        builder.Property(x => x.FilterGroupId).IsRequired();
        builder.Property(x => x.FirstFilterValue).IsRequired();
        builder.Property(x => x.SecondFilterValue).IsRequired();
    }
}