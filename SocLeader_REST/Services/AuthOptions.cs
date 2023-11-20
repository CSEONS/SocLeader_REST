using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SocLeader_REST.Services
{
    public class AuthOptions
    {
        public const string ISSUER = "CSEON";
        public const string AUDIENCE = "VolgaItClients";
        private const string KEY = "UltimasecretKeyFor123_111!@#----12sadOHijidbsajKJBNDkjbsadkjabsdkjBJHDBjsbdkajdbkJBDjsbdkj^*7687264";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() => new (Encoding.UTF8.GetBytes(KEY));
    }
}
