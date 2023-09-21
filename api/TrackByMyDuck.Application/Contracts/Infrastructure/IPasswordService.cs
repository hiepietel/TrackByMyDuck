namespace TrackByMyDuck.Application.Contracts.Infrastructure
{
    public interface IPasswordService
    {
        Tuple<string, byte[]> EncryptPassword(string password);
        bool ValidatePassword(string password, string hash, byte[] salt);
    }
}