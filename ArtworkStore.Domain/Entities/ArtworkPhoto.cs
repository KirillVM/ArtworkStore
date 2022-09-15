using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtworkStore.Domain.Entities
{
    [Table("artwork_photo")]
    public class ArtworkPhoto
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("transport_id")]
        public Guid TransportId { get; set; }

        [Column("url")]
        public string URL { get; set; }

        [Column("artwork_id")]
        public int ArtworkId { get; set; }
        public Artwork Artwork { get; set; }
    }
}
