namespace TrackByMyDuck.Domain.Entities
{
    public class Track
    {
        public int Id { get; set; }
        public string SpotifyId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? PreviewUrl { get; set; }
        public int AlbumId { get; set; }
        public int TrackArtistId { get; set; }
        //public IReadOnlyCollection<List<Artist>> Artists { get; set; }
        public virtual Album Album { get; set; }
        public virtual List<TrackArtist> TrackArtists { get; set; }
    }
}