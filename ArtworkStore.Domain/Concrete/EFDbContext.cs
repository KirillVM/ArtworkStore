using ArtworkStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtworkStore.Domain.Concrete
{
     public class EFDbContext : DbContext
    {
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<ArtworkPhoto> ArtworkPhotos { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartArtwork> CartArtworks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }

        public EFDbContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartArtwork>()
                .HasKey(t => new { t.CartId, t.ArtworkId });

            modelBuilder.Entity<CartArtwork>()
                .HasOne(ca => ca.Artwork)
                .WithMany(c => c.CartArtworks)
                .HasForeignKey(ca => ca.ArtworkId);
            modelBuilder.Entity<CartArtwork>()
                .HasOne(ca => ca.Cart)
                .WithMany(c => c.CartArtworks)
                .HasForeignKey(ca => ca.CartId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ArtworkStoredb;Username=postgres;Password=020291");
        }
    }
}
