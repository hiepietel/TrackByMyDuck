namespace TrackByMyDuck.Domain.Entities
{
    public class Track
    {
        public int Id { get; set; }
        public string SpotifyId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int AlbumId { get; set; }
        public ICollection<Artist> Artists { get; set; }

    }
}