using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserCustomFilter.Persistence.Entity;

namespace UserCustomFilter.Persistence.EntityMapping;

public class CustomFilterGroupMapping : IEntityTypeConfiguration<CustomFilterGroup>
{
    public void Configure(EntityTypeBuilder<CustomFilterGroup> builder)
    {
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Created).IsRequired();
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.FilterGroupName).IsRequired();
        builder.Property(x => x.FilterGroupPicture).IsRequired();

        builder.HasMany(x => x.Filters)
                .WithOne(x => x.FilterGroup)
                .HasForeignKey(x => x.FilterGroupId);
    }
}