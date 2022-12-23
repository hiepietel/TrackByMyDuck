namespace TrackByMyDuck.Application.Features.Tracks.Queries.GetShowTrack
{
    public class ShowTrackVm
    {
        public int Id { get; set; }
        public Guid SpotifyId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}