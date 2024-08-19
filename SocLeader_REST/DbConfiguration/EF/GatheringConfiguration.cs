using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocLeader_REST.Domain.Entities;

namespace SocLeader_REST.DbConfiguration.EF
{
    public class GatheringConfiguration : IEntityTypeConfiguration<Gathering>
    {
        public void Configure(EntityTypeBuilder<Gathering> builder)
        {
            builder
                .HasMany(g => g.Participants)
                .WithMany(u => u.FollowedGatherings);

            builder
                .HasMany(g => g.Tags)
                .WithMany();
        }
    }
}
