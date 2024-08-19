using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SocLeader_REST.MediatR.User.Accounts.SignUp
{
    public class SignUpRequest : IRequest<IActionResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
