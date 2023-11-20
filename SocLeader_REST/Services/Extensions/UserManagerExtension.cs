using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using SocLeader_REST.Domain.Entities;
using SocLeader_REST.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SocLeader_REST.Services 
{ 
    public static class UserManagerExtension
    {
        public static async Task<ActionMessage> CreateWithEmail(this UserManager<AppUser> userManager, string email, string password, IDatabaseService databaseService)
        {
            var usernameGenerator = new UsernameGenerator();

            var emailValidator = new EmailValidator();
            if (emailValidator.IsValidEmail(email) is false)
                return ActionMessages.InvalidEmail(email);

            var user = await userManager.FindByEmailAsync(email);
            if (user is not null)
                return ActionMessages.EmailTaked(email);

            if (string.IsNullOrEmpty(password))
                return ActionMessages.PasswordReqirement;


            ActionMessage actionMessage = ActionMessages.Empty;

            try
            {
                await databaseService.BeginTransactionAsync();

                user = new AppUser()
                {
                    Id = Guid.NewGuid(),
                    UserName = usernameGenerator.Generate()
                };

                var createUserResult = await userManager.CreateAsync(user);
                if (createUserResult.Succeeded is false)
                {
                    actionMessage = ActionMessages.FailedCreateUser;
                    throw new Exception();
                }

                var setEmailResult = await userManager.SetEmailAsync(user, email);
                if (setEmailResult.Succeeded is false)
                {
                    actionMessage = ActionMessages.InvalidEmail(email);
                    throw new Exception();
                }

                var addPasswordResult = await userManager.AddPasswordAsync(user, password);
                if (addPasswordResult.Succeeded is false)
                {
                    actionMessage = ActionMessages.PasswordReqirement;
                    throw new Exception();
                }

                actionMessage = ActionMessages.UserCreated;

                await databaseService.CommitAsync();
                
                return actionMessage;
            }
            catch (Exception)
            {
                await databaseService.RollbackAsync();

                return actionMessage;
            }
        }
    }
}
