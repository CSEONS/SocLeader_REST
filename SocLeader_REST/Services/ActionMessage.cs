using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace SocLeader_REST.Services
{
    public class ActionMessages
    {
        public static ActionMessage Empty  = new ActionMessage
        (
            message: string.Empty,
            succesed: false
        );

        public static ActionMessage EmailTaked(string email) => new ActionMessage
        (
            message: $"User with email {email} exist.", 
            succesed: false
        );

        public static ActionMessage InvalidEmail(string email) => new ActionMessage
        (
            message: $"Invalid email",
            succesed: false
        );

        public static ActionMessage EmailNotFound(string email) => new ActionMessage
        (
            message: $"User with Email '{email}' not found.",
            succesed: false
        );

        public static readonly ActionMessage PasswordReqirement = new ActionMessage
        (
            message: "Password must contain uppercase and lowercase letters, one symbol and a number",
            succesed: false
        );

        public static readonly ActionMessage FailedCreateUser = new ActionMessage
        (
            message: "Failed to create user",
            succesed: false
        );

        public static readonly ActionMessage UserCreated = new ActionMessage
        (
            message: "User created.",
            succesed: true
        );

        public static readonly ActionMessage WrongPassword = new ActionMessage
        (
            message: "Wrong password",
            succesed: false
        );
    }

    public class ActionMessage
    {
        public readonly string Message;
        public readonly bool Succesed;

        public ActionMessage(string message, bool succesed)
        {
            Message = message;
            Succesed = succesed;
        }
    }
}
