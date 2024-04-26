namespace PickAVibe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Watched")]
    public partial class Watched
    {
        public int WatchedID { get; set; }

        public int? FK_UserID { get; set; }

        public int? FK_MovieID { get; set; }

        public int? Rating { get; set; }

        public virtual Movies Movies { get; set; }

        public virtual Users Users { get; set; }
    }
}
