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
            message: $"Invalid email.",
            succesed: false
        );

        public static ActionMessage EmailNotFound(string email) => new ActionMessage
        (
            message: $"User with Email '{email}' not found.",
            succesed: false
        );

        public static readonly ActionMessage PasswordReqirement = new ActionMessage
        (
            message: "Password must contain uppercase and lowercase letters, one symbol and a number.",
            succesed: false
        );

        public static readonly ActionMessage FailedCreateUser = new ActionMessage
        (
            message: "Failed to create user.",
            succesed: false
        );

        public static readonly ActionMessage UserCreated = new ActionMessage
        (
            message: "User created.",
            succesed: true
        );

        public static readonly ActionMessage WrongPassword = new ActionMessage
        (
            message: "Wrong password.",
            succesed: false
        );

        public static readonly ActionMessage GatheringNotFound = new ActionMessage
        (
            message: "Gathering notfound.",
            succesed: false
        );

        public static readonly ActionMessage GatheringDeleted = new ActionMessage
        (
            message: "Gathering deleted.",
            succesed: true
        );

        public static ActionMessage UserNotOwner(Guid id) => new ActionMessage
        (
            message: $"U are not owner for gathering with id {id}.",
            succesed: false
        );

        public static ActionMessage UserNotFound = new ActionMessage
        (
            message: "User not foun.",
            succesed: false
        );

        public static ActionMessage OwnerCantFollow = new ActionMessage
        (
            message: "The owner cannot subscribe to his gathering.",
            succesed: false
        );

        public static ActionMessage GatheringCreated = new ActionMessage
        (
            message: "Gathering created",
            succesed: true
        );

        public static ActionMessage Viewed = new ActionMessage
        (
            message: "Viewed",
            succesed: true
        );

        public static ActionMessage UserFollowed(Guid userId, Guid gatheringId) => new ActionMessage
        (
            message: $"User {userId} followed {gatheringId} gathering.",
            succesed: true
        );
    }

    [Serializable]
    public class ActionMessage
    {
        public string Message { get; set; }
        public bool Succesed { get; set; }

        public ActionMessage(string message, bool succesed)
        {
            Message = message;
            Succesed = succesed;
        }
    }
}
