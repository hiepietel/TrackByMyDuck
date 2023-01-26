namespace TrackByMyDuck.Application.Features.Users.Commands.LogUser
{
    public class UserVm
    {
        public int FacebookId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
    }
}