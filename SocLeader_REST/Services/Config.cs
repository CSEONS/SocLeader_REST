﻿namespace SocLeader_REST.Services
{
    public class Config
    {
        public static string ConnectionString { get; set; }
        public static int AccesTokenExpiredTimePerMinute { get; set; }
        public static int RefreshTokenExpiredTimePerDay { get; set; }
        public static string DefaultUsername { get; set; }
    }
}
