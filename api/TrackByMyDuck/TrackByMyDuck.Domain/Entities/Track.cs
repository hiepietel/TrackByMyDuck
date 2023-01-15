namespace TrackByMyDuck.Domain.Entities
{
    public class Track
    {
        public int Id { get; set; }
        public string SpotifyId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int AlbumId { get; set; }
        //public IReadOnlyCollection<List<Artist>> Artists { get; set; }
        public virtual Album Album { get; set; }
        public virtual List<TrackArtist> TrackArtists { get; set; }
        public virtual List<Artist> Artists { get; set; }
    }
}