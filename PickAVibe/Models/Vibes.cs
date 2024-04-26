namespace PickAVibe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vibes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vibes()
        {
            MoodsVibes = new HashSet<MoodsVibes>();
            MoviesVibes = new HashSet<MoviesVibes>();
        }

        [Key]
        public int VibeID { get; set; }

        [Required]
        [StringLength(100)]
        public string VibeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MoodsVibes> MoodsVibes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MoviesVibes> MoviesVibes { get; set; }
    }
}
