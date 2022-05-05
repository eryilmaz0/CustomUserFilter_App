using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserCustomFilter.Persistence.Entity;

namespace UserCustomFilter.Persistence.EntityMapping;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Created).IsRequired();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.LastName).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Password).IsRequired();

        builder.HasMany(x => x.CustomFilters)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
    }
}