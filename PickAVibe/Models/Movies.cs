namespace PickAVibe.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Movies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movies()
        {
            MoviesVibes = new HashSet<MoviesVibes>();
            Watched = new HashSet<Watched>();
            Watchlist = new HashSet<Watchlist>();
        }

        [Key]
        public int MovieID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(4)]
        public string Year { get; set; }

        public int Duration { get; set; }

        [Required]
        public string Description { get; set; }

        public string PosterImg { get; set; }

        public string TrailerURL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MoviesVibes> MoviesVibes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Watched> Watched { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Watchlist> Watchlist { get; set; }



        [NotMapped] // Questo impedisce a EF di cercare di mappare queste proprietà sul database
        public string IMDbRating { get; set; }

        [NotMapped]
        public string RottenTomatoesRating { get; set; }

    }
}
