using SocLeader_REST.Domain.Entities;

namespace SocLeader_REST.Services.Preference
{
    public interface IPreferenceChanger
    {
        void Change(ref AppUser user, IEnumerable<Tag> tags);
    }
}
