using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SocLeader_REST.MediatR.User.Accounts.SignIn
{
    public class SignInRequest : IRequest<IActionResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
