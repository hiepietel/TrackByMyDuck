namespace TrackByMyDuck.Application.Features.Users.Commands.LogUser
{
    public class LogInUserVm
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
    }
}