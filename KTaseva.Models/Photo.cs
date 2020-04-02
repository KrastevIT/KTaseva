﻿namespace KTaseva.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
