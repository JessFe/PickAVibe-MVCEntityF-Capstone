namespace PickAVibe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MoviesVibes
    {
        [Key]
        public int MovieVibeID { get; set; }

        public int? FK_MovieID { get; set; }

        public int? FK_VibeID { get; set; }

        public virtual Movies Movies { get; set; }

        public virtual Vibes Vibes { get; set; }
    }
}
