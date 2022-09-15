using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtworkStore.Domain.Entities
{
    [Table("artworks")]
    public class Artwork
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("transport_id")]
        public Guid TransportId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("descriprion")]
        public string Description { get; set; }

        [Column("creation_date")]
        public Int64 CreationDate { get; set; }

        [Column("format")]
        public string Format { get; set; }

        [Column("technic")]
        public string Technic { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("author_id")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public List<ArtworkPhoto> ArtworkPhotos { get; set; }

        public  List<CartArtwork> CartArtworks { get; set; }
        public Artwork()
        {
            CartArtworks = new List<CartArtwork>();
        }

    }
}
