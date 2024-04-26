using System.Collections.Generic;

namespace PickAVibe.Models
{
    public class BackofficeVM
    {
        public int TotalMovies { get; set; }
        public List<VibeInfo> Vibes { get; set; }
    }

    public class VibeInfo
    {
        public int VibeID { get; set; }
        public string VibeName { get; set; }
        public int MoviesCount { get; set; }
    }
}