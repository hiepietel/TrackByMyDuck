using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using TrackByMyDuck.Application.Contracts.Infrastructure;

namespace TrackByMyDuck.Infrastructure.AuthenticationService
{
    public class PasswordService: IPasswordService
    {
        public Tuple<string, byte[]> EncryptPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes

            string hashed = GetHash(password, salt);

            return new Tuple<string, byte[]>(hashed, salt);
        }

        public bool ValidatePassword(string password, string hash, byte[] salt)
        {
            string newHash = GetHash(password, salt);
            return hash == newHash;
        }


        private string GetHash(string password, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
        }
    }
}