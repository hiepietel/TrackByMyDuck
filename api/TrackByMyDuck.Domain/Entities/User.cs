﻿namespace TrackByMyDuck.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int FacebookId { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? ImgHref { get; set; }

        public string Hash { get; set; }
        public byte[] Salt { get; set; }
    }
}