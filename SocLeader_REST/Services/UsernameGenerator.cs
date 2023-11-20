namespace SocLeader_REST.Services
{
    public class UsernameGenerator
    {
        public string Generate()
        {
            var username = $"{Config.DefaultUsername}-{Guid.NewGuid()}";

            return username;
        }
    }
}
