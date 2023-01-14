using TrackByMyDuck.Application.Services;

namespace TrackByMyDuck.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var spotifyService = new SpotifyService(null);
            var result = await spotifyService.GetTracksFromPlaylist(Configuration.SpotifyToken, Configuration.SpotifyPlaylistId);

            Assert.Pass();
        }
    }
}