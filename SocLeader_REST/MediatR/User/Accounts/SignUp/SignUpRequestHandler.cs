using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocLeader_REST.Domain.Entities;
using SocLeader_REST.MediatR.User.Accounts.SignUp;
using SocLeader_REST.Services;
using SocLeader_REST.Services.Interfaces;

namespace SocLeader_REST.MediatR.Account.SignUp
{
    public class SignUpRequestHandler : IRequestHandler<SignUpRequest, IActionResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppUser> _roleManager;
        private readonly IDatabaseService _databaseService;

        public SignUpRequestHandler(UserManager<AppUser> userManager, IDatabaseService databaseService)
        {
            _userManager = userManager;
            _databaseService = databaseService;
        }

        public async Task<IActionResult> Handle(SignUpRequest request, CancellationToken cancellationToken)
        {
            var actionMessage = await _userManager.CreateWithEmail(request.Email, request.Password, _databaseService);

            if (actionMessage.Succesed is false)
                return new BadRequestObjectResult(actionMessage.Message);

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
                return new BadRequestObjectResult(ActionMessages.UserNotFound);

            var value = await _userManager.AddToRoleAsync(user, AppUserRoles.Roles[AppUserRoles.UserRoles.User]);

            return new OkObjectResult(actionMessage.Message);
        }
    }
}