using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtworkStore.Domain.Entities
{
    [Table("cart_artwork")]
    public class CartArtwork
    {
        [Column("cart_id")]
        public int CartId { get; set; }

        public Cart Cart { get; set; }

        [Column("artwork_id")]
        public int ArtworkId { get; set; }
        public Artwork Artwork { get; set; }
    }
}
