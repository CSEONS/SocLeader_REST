using SocLeader_REST.Domain.Entities;

namespace SocLeader_REST.Services.Interfaces
{
    public interface IJwtGenerator
    {
        string Generate(AppUser user, TimeSpan timeSpan);
    }
}
