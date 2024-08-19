using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocLeader_REST.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {

        public virtual ICollection<PreferencesTagWeight> PreferencesWeight { get; set; }
        public virtual ICollection<Gathering> CreatedGatherings { get; set; }
        public virtual ICollection<Gathering> FollowedGatherings { get; set; }
    }
}
