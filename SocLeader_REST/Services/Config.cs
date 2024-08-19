namespace SocLeader_REST.Services
{
    public class Config
    {
        public static string ConnectionString { get; set; }
        public static int AccesTokenExpiredTimePerMinute { get; set; }
        public static int RefreshTokenExpiredTimePerDay { get; set; }
        public static string DefaultUsername { get; set; }
        public static int TagDefaultWeight { get; internal set; }
        public static int CountOfDeleteUnchangedTag { get; internal set; }
    }
}
