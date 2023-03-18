namespace TrackByMyDuck.Application.Contracts.Infrastructure
{
    public interface IAuthService
    {
        Task<string> CreateToken(string name, string id, string email);
        Task<bool> ValidateFacebookToken(string accessToken);
        Task<string> GetUserInfo();
    }
}