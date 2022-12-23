namespace TrackByMyDuck.Domain.Entities
{
    public class Track
    {
        public int Id { get; set; }
        public string SpotifyId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}