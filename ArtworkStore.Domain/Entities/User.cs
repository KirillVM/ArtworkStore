using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtworkStore.Domain.Entities
{
	[Table("user")]
	public class User
    {
		[Column("id")]
		public int Id { get; set; }

		[Column("transport_id")]
		public Guid TransportId { get; set; }

		[Column("first_name")]
		public string FirstName { get; set; }

		[Column("last_name")]
		public string LastName { get; set; }

		[Column("email")]
		public string Email { get; set; }

		[Column("age")]
		public int Age { get; set; }

		[Column("phone")]
		public string Phone { get; set; }

		[Column("gender")]
		public Gender Gender { get; set; }
        public Cart Cart { get; set; }
    }
}
