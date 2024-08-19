using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocLeader_REST.Services;
using System.Xml;

namespace SocLeader_REST.DbConfiguration.EF
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            var rolesNames = AppUserRoles.Roles.Select(r => r.Value).ToList();
            var roles = new List<IdentityRole<Guid>>(rolesNames.Count());

            foreach (var roleName in rolesNames)
            {
                IdentityRole<Guid> role = new IdentityRole<Guid>()
                {
                    Id = Guid.NewGuid(),
                    Name = roleName,
                    NormalizedName = roleName.ToUpper(),
                };

                roles.Add(role);
            }

            builder.HasData(roles);
        }
    }
}
