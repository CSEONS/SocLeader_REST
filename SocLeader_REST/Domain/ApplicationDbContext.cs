using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocLeader_REST.Areas.User;
using SocLeader_REST.DbConfiguration.EF;
using SocLeader_REST.Domain.Entities;

namespace SocLeader_REST.Domain
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Gathering> Gatherings { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PreferencesTagWeight> TagWeghtt { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<AppUser>(new UserConfiguration());
            builder.ApplyConfiguration<Gathering>(new GatheringConfiguration());
            builder.ApplyConfiguration<IdentityRole<Guid>>(new RoleConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
