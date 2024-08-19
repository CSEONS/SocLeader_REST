using Microsoft.AspNetCore.Identity;
using SocLeader_REST.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocLeader_REST.Services
{
    public class AppUserRoles
    {
        [NotMapped]
        public static readonly Dictionary<UserRoles, string> Roles = new Dictionary<UserRoles, string>()
        {
            { UserRoles.Admin, "Admin" },
            { UserRoles.User, "User" },
            { UserRoles.PremiumUser, "PremiumUser" }
        };

        public enum UserRoles
        {
            Admin,
            User,
            PremiumUser
        }
    }
}
