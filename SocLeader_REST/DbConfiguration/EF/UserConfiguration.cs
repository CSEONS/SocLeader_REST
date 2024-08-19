using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocLeader_REST.Domain.Entities;

namespace SocLeader_REST.DbConfiguration.EF
{
    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
                .HasMany(u => u.CreatedGatherings)
                .WithOne(g => g.Owner)
                .HasForeignKey(g => g.OwnerId);

            builder
                .HasMany(u => u.PreferencesWeight)
                .WithOne(w => w.Owner)
                .HasForeignKey(w => w.Id);
        }
    }
}
