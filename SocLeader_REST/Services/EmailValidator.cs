using SocLeader_REST.Services.Interfaces;
using System.Text.RegularExpressions;

namespace SocLeader_REST.Services
{
    public class EmailValidator : IEmailValidator
    {
        private readonly string _pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        public bool IsValidEmail(string email)
        {
            Match match = Regex.Match(email, _pattern);

            return match.Success;
        }
    }
}
