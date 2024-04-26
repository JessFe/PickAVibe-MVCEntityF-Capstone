namespace PickAVibe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MoodsVibes
    {
        [Key]
        public int MoodVibeID { get; set; }

        public int? FK_MoodID { get; set; }

        public int? FK_VibeID { get; set; }

        public virtual Moods Moods { get; set; }

        public virtual Vibes Vibes { get; set; }
    }
}
