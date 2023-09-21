using TrackByMyDuck.Application.Services;
using TrackByMyDuck.Infrastructure.AuthenticationService;

namespace TrackByMyDuck.UnitTests
{
    public class PasswordServiceTests
    {

        [Test]
        public async Task Test()
        {
            var passwordService = new PasswordService();
            var result = passwordService.EncryptPassword("test");
        }
    }


    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var spotifyService = new SpotifyService(null, null, null, null, null);
            //var result = await spotifyService.GetTracksFromPlaylist(Configuration.SpotifyToken, Configuration.SpotifyPlaylistId);

            Assert.Pass();
        }
    }
}