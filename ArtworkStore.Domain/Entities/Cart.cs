using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtworkStore.Domain.Entities
{
    [Table("cart")]
    public class Cart
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
        public List<CartArtwork> CartArtworks { get; set; }

        public Cart()
        {
            CartArtworks = new List<CartArtwork>();
        }

    }
}
