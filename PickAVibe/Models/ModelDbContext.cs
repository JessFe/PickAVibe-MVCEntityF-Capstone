using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PickAVibe.Models
{
    public partial class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=ModelDbContext")
        {
        }

        public virtual DbSet<Moods> Moods { get; set; }
        public virtual DbSet<MoodsVibes> MoodsVibes { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<MoviesVibes> MoviesVibes { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vibes> Vibes { get; set; }
        public virtual DbSet<Watched> Watched { get; set; }
        public virtual DbSet<Watchlist> Watchlist { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moods>()
                .HasMany(e => e.MoodsVibes)
                .WithOptional(e => e.Moods)
                .HasForeignKey(e => e.FK_MoodID);

            modelBuilder.Entity<Movies>()
                .HasMany(e => e.MoviesVibes)
                .WithOptional(e => e.Movies)
                .HasForeignKey(e => e.FK_MovieID);

            modelBuilder.Entity<Movies>()
                .HasMany(e => e.Watched)
                .WithOptional(e => e.Movies)
                .HasForeignKey(e => e.FK_MovieID);

            modelBuilder.Entity<Movies>()
                .HasMany(e => e.Watchlist)
                .WithOptional(e => e.Movies)
                .HasForeignKey(e => e.FK_MovieID);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Watched)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.FK_UserID);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Watchlist)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.FK_UserID);

            modelBuilder.Entity<Vibes>()
                .HasMany(e => e.MoodsVibes)
                .WithOptional(e => e.Vibes)
                .HasForeignKey(e => e.FK_VibeID);

            modelBuilder.Entity<Vibes>()
                .HasMany(e => e.MoviesVibes)
                .WithOptional(e => e.Vibes)
                .HasForeignKey(e => e.FK_VibeID);
        }
    }
}
