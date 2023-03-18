namespace TrackByMyDuck.Application.Features.Users.Queries.GetUserInfo
{
    public class UserInfoVm
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string? ImgHref { get; set; }
    }
}
