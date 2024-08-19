using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocLeader_REST.Domain.Entities;
using SocLeader_REST.Services;
using SocLeader_REST.Services.Interfaces;

namespace SocLeader_REST.MediatR.User.Accounts.SignIn
{
    public class SignInRequestHandler : IRequestHandler<SignInRequest, IActionResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtGenerator _jwtGenerator;

        public SignInRequestHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<IActionResult> Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
                return new BadRequestObjectResult(ActionMessages.EmailNotFound(request.Email).Message);

            if (await _userManager.CheckPasswordAsync(user, request.Password) is false)
                return new BadRequestObjectResult(ActionMessages.WrongPassword.Message);

            var tokens = new
            {
                accessToken = _jwtGenerator.Generate(user, TimeSpan.FromMinutes(Config.AccesTokenExpiredTimePerMinute)),
                refreshToken = _jwtGenerator.Generate(user, TimeSpan.FromDays(Config.RefreshTokenExpiredTimePerDay))
            };

            await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            return new OkObjectResult(tokens);
        }
    }
}
