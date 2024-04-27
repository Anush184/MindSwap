namespace MindSwap.Application.Features.UserFeature.Shared
{
    public abstract class BaseUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; } = string.Empty;

    }
}
