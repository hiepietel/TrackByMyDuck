namespace TrackByMyDuck.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string SpotifyId { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
    }
}